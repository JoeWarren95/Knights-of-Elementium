using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight_Behavior : MonoBehaviour
{
    #region Public Variables
    public float attackDistance; //Within this range, enemy will attack player
    public float closeattackDistance; //Within this range, enemy will slam player
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
    public Rigidbody2D rb;
    public float KnightDashSpeed;
    public int direction;
    public float AttackCooldown = 3;
    public bool JustAttacked;
    #endregion

    #region Private Variables
    public Animator anim;
    public float distance; //Store the distance btwn enemy and player
    public bool attackMode;
    public bool cooling; //Check if Enemy is cooling after attack
    public float intTimer;
    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Awake()
    {
        SelectTarget();
        intTimer = timer; //Store the initial value of timer
        anim = GetComponent<Animator>();
    }

        void Update() 
    {
        if (JustAttacked == true)
        {
            AttackCooldown -= 1 * Time.deltaTime;
        }
        if (AttackCooldown <= 0)
        {
            AttackCooldown = 3;
            JustAttacked = false;
        }
            if (!attackMode)
        {
            StartCoroutine(Move());
        }

        if(!InsideofLimits() && !inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("RootKnight_Attack1") && !anim.GetCurrentAnimatorStateInfo(0).IsName("RootKnight_RotNova"))
        {
            SelectTarget();
        }

        if (inRange)
        {
            EnemyLogic();
        }

        if(distance > attackDistance) // stop chasing & resume patrolling if Player is beyond attack distance
        {
            StopAttack();
        }
    }
        void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.position);
        
        if(attackDistance > distance && JustAttacked == false && closeattackDistance < distance)
        {
            StartCoroutine(Attack());
        }
        else if(closeattackDistance > distance && attackDistance > distance)
        {
            RotNova();
        }
       
            if (cooling)
        {
            Cooldown();
            anim.SetBool("Attack", false);
            anim.SetBool("RotNova", false);
        }
    }

    IEnumerator Move()
        {
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("RootKnight_Attack1") && !anim.GetCurrentAnimatorStateInfo(0).IsName("RootKnight_RotNova")) // if not playing attack animation
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
            anim.SetBool("canWalk", false);
            anim.SetBool("Attack", true); // Plays Enemy Attack Animation that carries collider
            yield return new WaitForSeconds(0f);
        }
    }
    public void RotNova()
    {
        CantDamage = false;
        anim.SetBool("canWalk", false);
        anim.SetBool("RotNova", true); // Plays Enemy Slam Attack Animation that carries collider
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
            anim.SetBool("RotNova", false);
    }

        void StopAttack()
        {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("RootKnight_Attack1"))
            {
            cooling = false;
            attackMode = false;
            anim.SetBool("Attack", false);
            anim.SetBool("RotNova", false);
        }
        }
        void StopAOEAttack()
        {
            cooling = false;
            attackMode = false;
            anim.SetBool("RotNova", false);
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

        if (distanceToLeft > distanceToRight)
        {
            target = leftLimit;
            direction = 2;
        }
        else
        {
            target = rightLimit;
            direction = 1;
        }
        
        Flip();
    }
        public void Flip()
        {
            Vector3 rotation = transform.eulerAngles;
            if(transform.position.x < target.position.x)
            {
                rotation.y = 180f;
                direction = 1;
            }
            else
            {
                direction = 2;
                rotation.y = 0f;         
            }
            transform.eulerAngles = rotation;
        }

            IEnumerator DamageCool()
        {
            yield return new WaitForSeconds(3f);
        }

        public void AttackDash()
    {
        if (direction == 2)
        {
            rb.velocity = Vector2.left * KnightDashSpeed;
            Debug.Log("Dash to left!");
        }
        if (direction == 1)
        {
            rb.velocity = Vector2.right * KnightDashSpeed;
            Debug.Log("Dash to left!");
        }
    }
}

