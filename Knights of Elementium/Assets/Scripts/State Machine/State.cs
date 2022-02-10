using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    // This script has all the functions every state should have
    // this means that it will have a state enter/update/physics update/ and exit function

    protected FiniteStateMachine stateMachine;
    protected EnemyBase enemy;

    protected float startTime;

    protected string animBoolName;

    public State(EnemyBase enemy, FiniteStateMachine stateMachine, string animBoolName)
    {
        this.enemy = enemy;
        this.stateMachine = stateMachine;
    }

    public virtual void Enter()
    {
        startTime = Time.time;
        enemy.anim.SetBool(animBoolName, true);
    }

    public virtual void Exit()
    {
        enemy.anim.SetBool(animBoolName, false);

    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {

    }
    
}
