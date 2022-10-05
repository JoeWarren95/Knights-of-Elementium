using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight_Behavior : MonoBehaviour
{
    #region Public Variables
    public float longattackDistance; // Within this range, enemy will jump after player
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
    public int AttackCh;
    public float Attack1Cooldown;
    public float Attack2Cooldown;
    public float Attack3Cooldown;
    public float Attack4Cooldown;
    public float Attack5Cooldown;
    public float Attack6Cooldown;
    public GameObject RMP;
    public GameObject RotGeyser;
    public Transform CastPoint;
    public Transform Player;
    public AudioSource MaceSmash;
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
        moveSpeed = 0;
    }

    public void AttackChoice()
    {
        AttackCh = Random.Range(0, 2);
    }

    public void Awaken()
    {
        anim.SetBool("Inactive", false);
        anim.SetBool("canWalk", true);
        anim.SetBool("idle", true);
    }

    void Awake()
    {
        SelectTarget();
        intTimer = timer; //Store the initial value of timer
        anim = GetComponent<Animator>();
    }

    void Update()
    { 
        if (Attack1Cooldown > 0)
        {
            Attack1Cooldown -= Time.deltaTime;
            anim.SetBool("Attack", false);
        }
        if (Attack2Cooldown > 0)
        {
            Attack2Cooldown -= Time.deltaTime;
            anim.SetBool("GeyserAttack", false);
        }
        if (Attack3Cooldown > 0)
        {
            Attack3Cooldown -= Time.deltaTime;
            anim.SetBool("SpinAttack", false);
        }
        if (Attack4Cooldown > 0)
        {
            Attack4Cooldown -= Time.deltaTime;
            anim.SetBool("RotMissile", false);
        }
        if (Attack5Cooldown > 0)
        {
            Attack5Cooldown -= Time.deltaTime;
            anim.SetBool("RotNova", false);
        }
        if (Attack6Cooldown > 0)
        {
            Attack6Cooldown -= Time.deltaTime;
            anim.SetBool("Attack2", false);
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("RootKnightJumpAttack"))
        {
            anim.SetBool("Attack2", false);
            anim.SetBool("Attack", false);
            anim.SetBool("RotNova", false);
            anim.SetBool("SpinAttack", false);
            anim.SetBool("GeyserAttack", false);
            anim.SetBool("RotMissile", false);
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("RootKnight_Attack1"))
        {
            anim.SetBool("Attack2", false);
            anim.SetBool("Attack", false);
            anim.SetBool("RotNova", false);
            anim.SetBool("SpinAttack", false);
            anim.SetBool("GeyserAttack", false);
            anim.SetBool("RotMissile", false);
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("RootKnight_RotNova"))
        {
            anim.SetBool("Attack2", false);
            anim.SetBool("Attack", false);
            anim.SetBool("RotNova", false);
            anim.SetBool("SpinAttack", false);
            anim.SetBool("GeyserAttack", false);
            anim.SetBool("RotMissile", false);
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("RootKnight_SpinAttack"))
        {
            anim.SetBool("Attack2", false);
            anim.SetBool("Attack", false);
            anim.SetBool("RotNova", false);
            anim.SetBool("SpinAttack", false);
            anim.SetBool("GeyserAttack", false);
            anim.SetBool("RotMissile", false);
        }
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

        if(!InsideofLimits() && !inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("RootKnight_Attack1") && !anim.GetCurrentAnimatorStateInfo(0).IsName("RootKnight_RotNova") && !anim.GetCurrentAnimatorStateInfo(0).IsName("RootKnight_JumpAttack"))
        {
            SelectTarget();
        }

        if (inRange)
        {
            EnemyLogic();
        }

        if(distance > longattackDistance) // stop chasing & resume patrolling if Player is beyond attack distance
        {
            StopAttack();
        }
    }
        void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.position);

        if (attackDistance > distance && closeattackDistance < distance && !anim.GetCurrentAnimatorStateInfo(0).IsName("RootKnightJumpAttack"))
        {
            AttackChoice();
            {
                if (AttackCh == 0 && Attack2Cooldown <= 0)
                {
                    GeyserAttack();
                }
                else if (AttackCh == 1 && Attack1Cooldown <= 0)
                {
                    StartCoroutine(Attack());
                }
            }
        }
        if (closeattackDistance > distance && !anim.GetCurrentAnimatorStateInfo(0).IsName("RootKnight_Attack1"))
        {
            AttackChoice();
            {
                if (AttackCh == 0 && Attack5Cooldown <= 0)
                {
                    RotNova();
                }
                else if (AttackCh == 1 && Attack3Cooldown <= 0)
                {
                    SpinAttack();
                }
            }
        }
        if (distance > attackDistance && !anim.GetCurrentAnimatorStateInfo(0).IsName("RootKnight_RotNova") && !anim.GetCurrentAnimatorStateInfo(0).IsName("RootKnight_Attack1") && !anim.GetCurrentAnimatorStateInfo(0).IsName("RootKnightJumpAttack"))
        {
            AttackChoice();
            {
                if (AttackCh == 0 && Attack4Cooldown <= 0)
                {
                    RotMissile();
                }
                else if (AttackCh == 1 && Attack6Cooldown <= 0)
                {
                    JumpingAttack();
                }
            }
        }
            if (cooling)
        {
            Cooldown();
            anim.SetBool("Attack", false);
            anim.SetBool("RotNova", false);
            anim.SetBool("Attack2", false);
        }
    }

    IEnumerator Move()
        {
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("RootKnight_Attack1") && !anim.GetCurrentAnimatorStateInfo(0).IsName("RootKnight_RotNova") && !anim.GetCurrentAnimatorStateInfo(0).IsName("RootKnightJumpAttack")) // if not playing attack animation
            {
                anim.SetBool("canWalk", true); // set true that enemy can walk
                
                Vector2 targetPosition = new Vector2(target.position.x, transform.position.y); // target new position to move to

                transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime); // physically move unit to target position

                yield return new WaitForSeconds(0f); // wait time before next update
 
            }
        }

    public void Attack1CooldownTrigger()
    {
        Attack1Cooldown = 5;
    }

    public void Attack2CooldownTrigger()
    {
        Attack2Cooldown = 5;
    }

    public void Attack3CooldownTrigger()
    {
        Attack3Cooldown = 5;
    }

    public void Attack4CooldownTrigger()
    {
        Attack4Cooldown = 5;
    }

    public void Attack5CooldownTrigger()
    {
        Attack5Cooldown = 5;
    }

    public void Attack6CooldownTrigger()
    {
        Attack6Cooldown = 5;
    }
    IEnumerator Attack()
    {
            attackMode = true; // To check if Enemy can still attack or not
            CantDamage = false;
            anim.SetBool("canWalk", false);
            anim.SetBool("Attack", true); // Plays Enemy Attack Animation that carries collider
            anim.SetBool("Attack2", false);
            anim.SetBool("RotNova", false);
            anim.SetBool("SpinAttack", false);
            anim.SetBool("GeyserAttack", false);
            anim.SetBool("RotMissile", false);
            yield return new WaitForSeconds(0f);
    }
    public void RotNova()
    {
        attackMode = true; // To check if Enemy can still attack or not
        CantDamage = false;
        anim.SetBool("Attack", false);
        anim.SetBool("canWalk", false);
        anim.SetBool("RotNova", true);
        anim.SetBool("Attack2", false);
        anim.SetBool("SpinAttack", false);
        anim.SetBool("GeyserAttack", false);
        anim.SetBool("RotMissile", false);
    }

    public void RotMissile()
    {
        attackMode = true; // To check if Enemy can still attack or not
        CantDamage = false;
        anim.SetBool("Attack", false);
        anim.SetBool("RotNova", false);
        anim.SetBool("Attack2", false);
        anim.SetBool("canWalk", false);
        anim.SetBool("SpinAttack", false);
        anim.SetBool("GeyserAttack", false);
        anim.SetBool("RotMissile", true);
    }

    public void RotMissileProjectile()
    {
        Instantiate(RMP, CastPoint.position, CastPoint.rotation);
    }

    public void GeyserAttack()
    {
        attackMode = true; // To check if Enemy can still attack or not
        CantDamage = false;
        anim.SetBool("canWalk", false);
        anim.SetBool("Attack", false);
        anim.SetBool("GeyserAttack", true);
        anim.SetBool("Attack2", false);
        anim.SetBool("SpinAttack", false);
        anim.SetBool("RotNova", false);
        anim.SetBool("RotMissile", false);
    }

    public void SpinAttack()
    {
        attackMode = true; // To check if Enemy can still attack or not
        CantDamage = false;
        anim.SetBool("SpinAttack", true);
        anim.SetBool("canWalk", false);
        anim.SetBool("RotNova", false);
        anim.SetBool("Attack2", false);
        anim.SetBool("Attack", false);
        anim.SetBool("GeyserAttack", false);
        anim.SetBool("RotMissile", false);
    }

    public void JumpingAttack()
    {
        { 
            attackMode = true; // To check if Enemy can still attack or not
            CantDamage = false;
            anim.SetBool("Attack", false);
            anim.SetBool("RotNova", false);
            anim.SetBool("Attack2", true);
            anim.SetBool("canWalk", false);
            anim.SetBool("SpinAttack", false);
            anim.SetBool("GeyserAttack", false);
            anim.SetBool("RotMissile", false);
        }
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
            anim.SetBool("Attack2", false);
            anim.SetBool("SpinAttack", false);
            anim.SetBool("GeyserAttack", false);
    }

        void StopAttack()
        {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("RootKnight_Attack1"))
            {
            cooling = false;
            attackMode = false;
            anim.SetBool("Attack", false);
            anim.SetBool("RotNova", false);
            anim.SetBool("Attack2", false);
            anim.SetBool("SpinAttack", false);
             anim.SetBool("GeyserAttack", false);
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
            if (transform.position.x < target.position.x && !anim.GetCurrentAnimatorStateInfo(0).IsName("RootKnight_RotNova") && !anim.GetCurrentAnimatorStateInfo(0).IsName("RootKnight_Attack1") && !anim.GetCurrentAnimatorStateInfo(0).IsName("RootKnight_JumpAttack"))
            {
                rotation.y = 180f;
                direction = 1;
            }
            else if (!anim.GetCurrentAnimatorStateInfo(0).IsName("RootKnight_RotNova") && !anim.GetCurrentAnimatorStateInfo(0).IsName("RootKnight_Attack1") && !anim.GetCurrentAnimatorStateInfo(0).IsName("RootKnight_JumpAttack"))
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
            rb.velocity = Vector2.left * 2 * KnightDashSpeed;
            Debug.Log("Dash to left!");
        }
        if (direction == 1)
        {
            rb.velocity = Vector2.right * 2 * KnightDashSpeed;
            Debug.Log("Dash to left!");
        }
    }
        
    public void MaceSmashSound()
    {
        MaceSmash.Play();
    }

    public void BackDash()
    {
        if (direction == 2)
        {
            rb.velocity = Vector2.right * 1 * KnightDashSpeed;
            Debug.Log("Dash to left!");
        }
        if (direction == 1)
        {
            rb.velocity = Vector2.left * 1 * KnightDashSpeed;
            Debug.Log("Dash to left!");
        }
    }

    public void JumpingDash()
    {
        if (direction == 2 && anim.GetCurrentAnimatorStateInfo(0).IsName("RootKnightJumpAttack"))
        {
            rb.velocity = Vector2.left * 3 * KnightDashSpeed + Vector2.up * 1 * KnightDashSpeed;
            Debug.Log("Dash to left!");
        }
        else if (direction == 1 && anim.GetCurrentAnimatorStateInfo(0).IsName("RootKnightJumpAttack"))
        {
            rb.velocity = Vector2.right * 3 * KnightDashSpeed + Vector2.up * 1 * KnightDashSpeed;
            Debug.Log("Dash to left!");
        }
    }

    public void StandStill()
    {
            rb.velocity = Vector2.left * 0 * KnightDashSpeed;
            rb.velocity = Vector2.right * 0 * KnightDashSpeed;
    }

    public void GeyserSpawn()
    {
        Instantiate(RotGeyser, new Vector2(Player.transform.position.x, 15.70f), Player.rotation);
    }
}
