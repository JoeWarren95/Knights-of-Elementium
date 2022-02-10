using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RK_idleState : IdleState
{
    //get reference to individual enemy
    private RootKnight knight;

    public RK_idleState(EnemyBase enemy, FiniteStateMachine stateMachine, string animBoolName, D_IdleState stateData, RootKnight knight) : base(enemy, stateMachine, animBoolName, stateData)
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

        if (isIdleTimeOver)
            stateMachine.ChangeState(knight.moveState);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
