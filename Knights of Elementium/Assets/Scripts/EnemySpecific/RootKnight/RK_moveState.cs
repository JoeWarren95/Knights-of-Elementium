using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RK_moveState : MoveState
{
    private RootKnight knight;

    public RK_moveState(EnemyBase enemy, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData, RootKnight knight) : base(enemy, stateMachine, animBoolName, stateData)
    {
        this.knight = knight;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isPlayerInMinAgroRange)
        {
            //accessing the base root knight script
            stateMachine.ChangeState(knight.playerDetectedState);
        }
        else if(isDetectingWall || !isDetectingLedge)
        {
            knight.idleState.setFlipAfterIdle(true);
            stateMachine.ChangeState(knight.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
