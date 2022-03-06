using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    protected D_MoveState stateData;

    protected bool isDetectingWall;
    protected bool isDetectingLedge;
    protected bool isPlayerInMinAgroRange;

    // This is the base script for enemy movement
    public MoveState(EnemyBase enemy, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData) : base(enemy, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
        enemy.SetVelocity(stateData.movementSpeed);

        isDetectingLedge = enemy.CheckLedge();
        isDetectingWall = enemy.CheckWall();
        isPlayerInMinAgroRange = enemy.CheckPlayerInMinAgroRange();
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

        isDetectingLedge = enemy.CheckLedge();
        isDetectingWall = enemy.CheckWall();
        isPlayerInMinAgroRange = enemy.CheckPlayerInMinAgroRange();

    }
}
