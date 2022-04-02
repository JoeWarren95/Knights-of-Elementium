using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    protected D_IdleState stateData;

    protected bool flipAfterIdle;
    protected bool isIdleTimeOver;
    //protected bool isPlayerInMaxAgroRange;

    protected bool isPlayerInMinAgroRange;


    protected float idleTime;

    public IdleState(EnemyBase enemy, FiniteStateMachine stateMachine, string animBoolName, D_IdleState stateData) : base(enemy, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();

        enemy.SetVelocity(0f);
        isIdleTimeOver = false;
        //isPlayerInMaxAgroRange = enemy.CheckPlayerInMaxAgroRange();

        isPlayerInMinAgroRange = enemy.CheckPlayerInMinAgroRange();

        setRandomIdleTime();
    }

    public override void Exit()
    {
        base.Exit();

        if (flipAfterIdle)
            enemy.Flip();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(Time.time >= startTime + idleTime)
            isIdleTimeOver = true;
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        //isPlayerInMaxAgroRange = enemy.CheckPlayerInMaxAgroRange();

        isPlayerInMinAgroRange = enemy.CheckPlayerInMinAgroRange();

    }

    public void setFlipAfterIdle(bool flip)
    {
        flipAfterIdle = flip;
    }

    private void setRandomIdleTime()
    {
        idleTime = Random.Range(stateData.minIdleTime, stateData.maxIdleTime);
    }
}
