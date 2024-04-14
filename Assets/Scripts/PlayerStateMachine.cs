using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public BasePlayerState currentState { get; private set; }
    public BasePlayerState prevState { get; private set; }

    [SerializeField] public BasePlayerState firstState; // starts with gather state

    public bool PauseState; 
    
    private void Start()
    {
        currentState = firstState;
        prevState = firstState;
        PauseState = false;
        currentState.Enter();
    }

    public void ChangeState(BasePlayerState nextState)
    {
        if (currentState != nextState)
        {
            prevState = currentState;
            currentState.Exit();
            currentState = nextState;
            currentState.Enter();
        }
    }

    private void Update()
    {
        if (PauseState)
        {
            return;
        }
        
        currentState.Tick();
    }
}
