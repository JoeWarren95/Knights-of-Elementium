using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootKnight : EnemyBase
{
    public RK_idleState idleState { get; private set; }
    public RK_moveState moveState { get; private set; }

    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_MoveState moveStateData;

    public override void Start()
    {
        base.Start();

        moveState = new RK_moveState(this, stateMachine, "move", moveStateData, this);
        idleState = new RK_idleState(this, stateMachine, "idle", idleStateData, this);

        //this line starts the root knight in the move state
        stateMachine.Initialize(moveState);


    }
}
