using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyState : MonoBehaviour
{
    [SerializeField] private EnemyActionController enemyActionController;
    public virtual void Enter()
    {
        
    }

    public virtual void Tick()
    {
        enemyActionController.MoveEnemy();
    }

    public virtual void Exit()
    {
    }
}
