using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_behavior : MonoBehaviour
{
    #region Public Variables
    public float closeattackDistance; //Within this range, enemy will aoe gas player
    public float attackDistance; //Within this range, enemy will swing arm at player
    public float LongattackDistance; // Within this range, enemy will fire projectile at player
    public float moveSpeed;
    public float timer; //Timer for cooldown btwn attacks
    public Transform leftLimit;
    public Transform rightLimit;
    [HideInInspector] public Transform target;
    [HideInInspector] public bool inRange; //Check if the player is in range
    public GameObject hotZone;
    public GameObject triggerArea;
    public LayerMask playerLayers;
    public GameObject MainPlayer;
    public GameObject ParentEnemy;
    public bool CantDamage;
    public int EnemyDamage;
    public int StaggerPower;
    //Enemy Spellcasting
    public Transform CastPoint;
    public GameObject EnemyEarthBall;
    public int direction;
    public float RangedCooldown;
    public bool JustUsedRanged;
    public Rigidbody2D rb;
    #endregion

    #region Private Variables
    public Animator anim;
    public float distance; //Store the distance btwn enemy and player
    public bool attackMode;
    public bool cooling; //Check if Enemy is cooling after attack
    public float intTimer;
    #endregion

    void Awake()
    {
        SelectTarget();
        intTimer = timer; //Store the initial value of timer
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        direction = 2;
        RangedCooldown = 3;
        rb = GetComponent<Rigidbody2D>();
    }

        void Update() 
    {
        if (JustUsedRanged == true)
        {
            RangedCooldown -= 1 * Time.deltaTime;
        }

        if (RangedCooldown <= 0)
        {
            RangedCooldown = 3;
            JustUsedRanged = false;
        }
        if (!attackMode)
        {
            StartCoroutine(Move());
        }

        if(!InsideofLimits() && !inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("Nymph_Attack") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Gas_Attack") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Projectile_Attack"))
        {
            SelectTarget();
        }

        if (inRange)
        {
            EnemyLogic();
        }

        if (distance > LongattackDistance) // stop chasing & resume patrolling if Player is beyond attack distance
        {
            StopAttack();
        }
    }
        void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.position);

            if(distance > LongattackDistance)
        {
            StopAttack();
        }
            else if (distance > closeattackDistance && anim.GetCurrentAnimatorStateInfo(0).IsName("Nymph_Gas"))
        {
            StopGasAttack();
        }
        
        else if(attackDistance > distance && cooling == false && closeattackDistance < distance) // swing attack being determined by outer radius
        {
            StartCoroutine(Attack());
        }
        
        else if(closeattackDistance > distance && cooling == false) // gas attack being determined by inner radius
        {
            StartCoroutine(GasAttack());
        }

        else if (distance > attackDistance && distance < LongattackDistance && JustUsedRanged == false && distance > closeattackDistance) // Fire Projectile Attack!
        {
            StartCoroutine(ProjectileAttack());
        }

        if (cooling)
        {
            Cooldown();
            anim.SetBool("Attack", false);
            anim.SetBool("GasAttack", false);
            anim.SetBool("Projectile", false);
        }
    }

    IEnumerator Move()
        {
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Nymph_Attack") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Nymph_Gas") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Projectile")) // if not playing attack animation
            {
                anim.SetBool("canWalk", true); // set true that enemy can walk
                
                Vector2 targetPosition = new Vector2(target.position.x, transform.position.y); // target new position to move to

                transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime); // physically move unit to target position

                yield return new WaitForSeconds(0f); // wait time before next update
 
            }
        }

    IEnumerator Attack()
    {
        {
            attackMode = true; // To check if Enemy can still attack or not
            CantDamage = false;
            anim.SetBool("Attack", true); // Plays Enemy Attack Animation that carries collider
            yield return new WaitForSeconds(0f);
        }
    }
    
    IEnumerator GasAttack()
    {
        attackMode = true; // To check if Enemy can still attack or not
        CantDamage = false;
        anim.SetBool("GasAttack", true); // Plays Enemy Slam Attack Animation that carries collider
        yield return new WaitForSeconds(0f);
    }

    IEnumerator ProjectileAttack()
    {
        attackMode = true; // To check if Enemy can still attack or not
        CantDamage = false;
        JustUsedRanged = true;
        anim.SetBool("Projectile", true); // Plays Enemy Projectile Launch Animation
        yield return new WaitForSeconds(0f);
    }

    public void LaunchProjectile()
    {
        Instantiate(EnemyEarthBall, CastPoint.position, CastPoint.rotation);
    }
    public void CantMove ()
    {
        moveSpeed = 0f;
        anim.SetBool("canWalk", false);
    }
    public void PlayerKnockback()
    {
        if (MainPlayer.GetComponent<DashMove>().direction == 1)
        {
            rb.velocity = Vector2.left * (0.40f * MainPlayer.GetComponent<PlayerAttributes>().Strength - ParentEnemy.GetComponent<EnemyHealth>().Weight);
            Debug.Log("Dash to left!");
        }
        if (MainPlayer.GetComponent<DashMove>().direction == 2)
        {
            rb.velocity = Vector2.right * (0.40f * MainPlayer.GetComponent<PlayerAttributes>().Strength - ParentEnemy.GetComponent<EnemyHealth>().Weight);
            Debug.Log("Dash to right!");
        }
    }
    public void CanMove ()
    {
        moveSpeed = 3f;
        anim.SetBool("canWalk", true);
    }

    void Cooldown()
        {
            timer -= Time.deltaTime;

            if(timer <= 0 && cooling && attackMode)
            {
                cooling = false;
                timer = intTimer;
            }
        }

        public void ForceStopAttack()
        {
            cooling = false;
            attackMode = false;
            anim.SetBool("Attack", false);
            anim.SetBool("GasAttack", false);
            anim.SetBool("Projectile", false);
            anim.SetBool("canWalk", true);
    }

        void StopAttack()
        {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Nymph_Attack"))
            {
            cooling = false;
            attackMode = false;
            anim.SetBool("Attack", false);
            anim.SetBool("GasAttack", false);
            anim.SetBool("Projectile", false);
        }
        }
        void StopGasAttack()
        {
            cooling = false;
            attackMode = false;
            anim.SetBool("GasAttack", false);
        }
        

        public void TriggerCooling()
        {
            cooling = true;
        }

        private bool InsideofLimits()
        {
            return transform.position.x > leftLimit.position.x && transform.position.x < rightLimit.position.x;
        }

        public void SelectTarget()
        {
            float distanceToLeft = Vector2.Distance(transform.position, leftLimit.position);
            float distanceToRight = Vector2.Distance(transform.position, rightLimit.position);

            if(distanceToLeft > distanceToRight)
            {
                target = leftLimit;
            }
            else
            {
                target = rightLimit;
            }

            Flip();
        }
        public void Flip()
        {
            Vector3 rotation = transform.eulerAngles;
            if(transform.position.x < target.position.x)
            {
            rotation.y = 180f;
            direction = 2;
            }
            else
            {
            rotation.y = 0f;
            direction = 1;
            }

            transform.eulerAngles = rotation;
        }

            IEnumerator DamageCool()
        {
            yield return new WaitForSeconds(3f);
        }
}

