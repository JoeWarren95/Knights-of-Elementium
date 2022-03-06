using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RK_playerDetectedState : PlayerDetectedState
{
    private RootKnight knight;

    public RK_playerDetectedState(EnemyBase enemy, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetectedState stateData, RootKnight knight) : base(enemy, stateMachine, animBoolName, stateData)
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

        if (!isPlayerInMaxAgroRange)
        {
            knight.idleState.setFlipAfterIdle(false);
            stateMachine.ChangeState(knight.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
