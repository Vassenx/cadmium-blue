using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerStateMachine playerStateMachine;

    public PlayerStateMachine GetStateMachine()
    {
        return playerStateMachine;
    }
}
