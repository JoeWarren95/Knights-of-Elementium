using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_behavior : MonoBehaviour
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

        void Update() 
    {

        if (!attackMode)
        {
            StartCoroutine(Move());
        }

        if(!InsideofLimits() && !inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("Nymph_Attack") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Gas_Attack"))
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

            if(distance > attackDistance)
        {
            StopAttack();
        }
        else if(attackDistance >= distance && cooling == false && closeattackDistance <= distance) // swing attack being determined by outer radius
        {
            StartCoroutine(Attack());
        }
        
        else if(closeattackDistance >= distance && cooling == false) // gas attack being determined by inner radius
        {
            StartCoroutine(GasAttack());
        }
       
            if (cooling)
        {
            Cooldown();
            anim.SetBool("Attack", false);
            anim.SetBool("GasAttack", false);
        }
    }

    IEnumerator Move()
        {
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Nymph_Attack") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Nymph_Gas")) // if not playing attack animation
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
    IEnumerator GasAttack()
    {
        attackMode = true; // To check if Enemy can still attack or not
        CantDamage = false;
        anim.SetBool("canWalk", false);
        anim.SetBool("GasAttack", true); // Plays Enemy Slam Attack Animation that carries collider
        yield return new WaitForSeconds(0f);
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
    }

        void StopAttack()
        {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Nymph_Attack"))
            {
            cooling = false;
            attackMode = false;
            anim.SetBool("Attack", false);
            anim.SetBool("GasAttack", false);
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
        }
            else
            {
                rotation.y = 0f;         
            }

            transform.eulerAngles = rotation;
        }

            IEnumerator DamageCool()
        {
            yield return new WaitForSeconds(3f);
        }
}

