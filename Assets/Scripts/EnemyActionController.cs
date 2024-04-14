using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyActionController : MonoBehaviour
{
    [SerializeField] private Vector2 currDir;
    [SerializeField] private Vector2 lastDir;
    [SerializeField] private Animator enemyAnimator;
    
    // up down left right
    public void PlayMoveAnimation()
    {
        //janky but acceptable for a gamejam
        float angle = ReturnAngle();
        int direction;

        if (angle <= 220 && angle > 100)
        {
            enemyAnimator.Play("EWalk_N");
        }
        else if (angle > 20 && angle <= 120)
        {
            enemyAnimator.Play("EWalk_W");
        }
        else if (angle <= 60 && angle > -61)
        {
            enemyAnimator.Play("EWalk_S");
        }
        else
        {
            enemyAnimator.Play("EWalk_E");
        }

    }

    public void MoveEnemy()
    {
        GameObject player = GameObject.FindWithTag("Player");
        GetComponent<NavMeshAgent>().destination = player.transform.position;
        

    }

    public float ReturnAngle()
    {
        GameObject player = GameObject.FindWithTag("Player");
        Vector2 diff =
            new Vector2(transform.position.x, transform.position.y) -
            new Vector2(player.transform.position.x, player.transform.position.y);
        var angleDeg = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        if (angleDeg < 0)
        {
            angleDeg += 360;
        }
        return angleDeg - 90;
    }
}
