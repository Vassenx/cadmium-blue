using System;
using System.Collections;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public BasePlayerState currentState { get; private set; }
    public BasePlayerState prevState { get; private set; }
    
    [SerializeField] public BasePlayerState firstState; // starts with gather state
    
    private void Start()
    {
        currentState = firstState;
        prevState = firstState;
        currentState.Enter();
    }

    public void ChangeState(BasePlayerState nextState)
    {
        if (currentState != nextState)
        {
            currentState.Exit();
            currentState = nextState;
            currentState.Enter();
        }
    }

    private void Update()
    {
        currentState.Tick();
    }
}
