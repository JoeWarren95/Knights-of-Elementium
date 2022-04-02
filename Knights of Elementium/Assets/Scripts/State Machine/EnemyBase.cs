using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    //this is the base script all enemies will inherit

    #region public variables
    //references to my other scripts
    public FiniteStateMachine stateMachine;
    public D_Enemy enemyData;

    public int facingDirection { get; private set; }

    public Rigidbody2D rb { get; private set; }
    public Animator anim { get; private set; }
    //short for Alive GameObject, GO that's used when enemy is alive
    public GameObject aliveGO { get; private set; }
    #endregion

    #region private variables
    [SerializeField]
    private Transform wallCheck;
    [SerializeField]
    private Transform ledgeCheck;
    [SerializeField]
    private Transform playerCheck;

    //use this whenever we need to create a vector2 somewhere
    private Vector2 velocityWorkSpace;

    #endregion

    public virtual void Start()
    {
        //determines which way the knight faces at the start
        facingDirection = 1;

        //double check the GameObject attached to this enemy is called "Alive"
        //otherwise you'll get a NullReferenceException
        aliveGO = transform.Find("Alive").gameObject;
        rb = aliveGO.GetComponent<Rigidbody2D>();
        anim = aliveGO.GetComponent<Animator>();

        stateMachine = new FiniteStateMachine();
    }

    public virtual void Update()
    {
        stateMachine.currentState.LogicUpdate();
    }

    public virtual void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }

    public virtual void SetVelocity(float velocity)
    {
        velocityWorkSpace.Set(facingDirection * velocity, rb.velocity.y);
        rb.velocity = velocityWorkSpace;
    }

    //right now everything is labeled as a ground, so it's detecting everything as ground 
    public virtual bool CheckWall()
    {
        return Physics2D.Raycast(wallCheck.position, aliveGO.transform.right, enemyData.wallCheckDistance, enemyData.whatIsGround);
    }

    public virtual bool CheckLedge()
    {
        return Physics2D.Raycast(ledgeCheck.position, Vector2.down, enemyData.ledgeCheckDistance, enemyData.whatIsGround);
    }


    //3 agro range functions to determine detection raycast lengths
    public virtual bool CheckPlayerInMinAgroRange()
    {
        return Physics2D.Raycast(playerCheck.position, aliveGO.transform.right, enemyData.minAgroDistance, enemyData.whatIsPlayer);
    }

    public virtual bool CheckPlayerInMidAgroRange()
    {
        return Physics2D.Raycast(playerCheck.position, aliveGO.transform.right, enemyData.midAgroDistance, enemyData.whatIsPlayer);
    }

    public virtual bool CheckPlayerInMaxAgroRange()
    {
        return Physics2D.Raycast(playerCheck.position, aliveGO.transform.right, enemyData.maxAgroDistance, enemyData.whatIsPlayer);
    }

    public virtual void Flip()
    {
        //TODO: May need to check if multiplying by -1 is right
        facingDirection *= -1;
        aliveGO.transform.Rotate(0f, 180f, 0f);
    }

    public virtual void OnDrawGizmos()
    {
        //this is so we can see the wall/ledge checks
        Gizmos.DrawLine(wallCheck.position, wallCheck.position + (Vector3)(Vector2.right * facingDirection * enemyData.wallCheckDistance));
        Gizmos.DrawLine(ledgeCheck.position, ledgeCheck.position + (Vector3)(Vector2.down * enemyData.ledgeCheckDistance));

        Gizmos.color = Color.red;
        Gizmos.DrawLine(playerCheck.position, playerCheck.position + (Vector3)(Vector2.right * facingDirection * enemyData.maxAgroDistance));

    }
}
