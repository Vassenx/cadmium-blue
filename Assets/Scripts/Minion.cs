using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour
{
    [SerializeField] private Enemy enemyData;
    [SerializeField] private int hitPoints;
    [SerializeField] int speed;
    [SerializeField] Vector3 spawnPoint;
    [SerializeField] float playerStunTime;
    [SerializeField] float pushBackAmount;
    [SerializeField] private bool canDie;
    [SerializeField] private Animator enemyAnimator;


    public EnemyActionController enemyActionController;
    // Start is called before the first frame update
    void Start()
    {
        canDie = false;
        hitPoints = enemyData.hitPoints;
        speed = enemyData.speed;
        spawnPoint = enemyData.spawnPoint;
        playerStunTime = enemyData.playerStunTime;
        pushBackAmount = enemyData.pushBackAmount;
    }

    public void GetHurt()
    {
        if (hitPoints > 0)
        {
            hitPoints--;
        }
        else
        {
            canDie = true;
        }
    }

    void Die()
    {
        //play some animation
        
    }

    private void Update()
    {
       // Debug.Log(        enemyActionController.ReturnAngle());
       //enemyActionController.MoveEnemy();
    }
}
