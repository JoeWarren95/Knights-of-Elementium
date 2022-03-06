using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RK_playerDectedState : PlayerDetectedState
{
    private RootKnight knight;

    public RK_playerDectedState(EnemyBase enemy, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetectedState stateData, RootKnight knight) : base(enemy, stateMachine, animBoolName, stateData)
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
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
