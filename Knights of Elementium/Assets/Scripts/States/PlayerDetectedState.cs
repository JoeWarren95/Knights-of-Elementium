using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectedState : State
{
    /// <summary>
    /// Looking into using HashSets for player detection and other
    /// interactions that may be needed in the future
    /// downside is we'll need to define EVERYTHING that will be detectable
    /// upside is this will be VERY efficient with an O(1) run time
    /// upside is this will be VERY efficient with an O(1) run time
    /// </summary>
    protected D_PlayerDetectedState stateData;

    protected bool isPlayerInMinAgroRange;
    protected bool isPlayerInMidAgroRange;
    protected bool isPlayerInMaxAgroRange;


    public PlayerDetectedState(EnemyBase enemy, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetectedState stateData) : base(enemy, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();

        //FOR TESTING set enemy to stop once player is detected
        enemy.SetVelocity(0f);
        Debug.Log("I can see you now");

        isPlayerInMaxAgroRange = enemy.CheckPlayerInMaxAgroRange();
        isPlayerInMinAgroRange = enemy.CheckPlayerInMinAgroRange();
        isPlayerInMidAgroRange = enemy.CheckPlayerInMidAgroRange();
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

        isPlayerInMaxAgroRange = enemy.CheckPlayerInMaxAgroRange();
        isPlayerInMinAgroRange = enemy.CheckPlayerInMinAgroRange();
        isPlayerInMidAgroRange = enemy.CheckPlayerInMidAgroRange();
    }
}
