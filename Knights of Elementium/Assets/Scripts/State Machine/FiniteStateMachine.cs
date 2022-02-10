using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// bc this script won't be attached to a physical gameobject, no need for Monobehaviour
public class FiniteStateMachine
{
    // keeps track of what state the enemy is currently in
   
    public State currentState { get; private set; }

    public void Initialize (State startingState)
    {
        currentState = startingState;
        currentState.Enter();
    }

    public void ChangeState(State newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
}
