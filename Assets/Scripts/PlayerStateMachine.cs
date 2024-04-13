using System;
using System.Collections;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public BasePlayerState currentState;

    [SerializeField] public GatherState gatherState;

    private void Start()
    {
        currentState = gatherState;
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
