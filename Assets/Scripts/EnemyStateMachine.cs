using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    public BaseEnemyState currentState { get; private set; }
    public BaseEnemyState prevState { get; private set; }
    
    [SerializeField] public BaseEnemyState firstState; // starts with gather state
    
    private void Start()
    {
        currentState = firstState;
        prevState = firstState;
        currentState.Enter();
    }

    public void ChangeState(BaseEnemyState nextState)
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
