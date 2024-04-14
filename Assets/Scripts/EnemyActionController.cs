using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyActionController : MonoBehaviour
{
    [SerializeField] private Vector2 currDir;
    [SerializeField] private Vector2 lastDir;
    [SerializeField] private Animator enemyAnimator;
    [SerializeField] private Minion minionData;
    public bool isAttacking;
    [SerializeField] private GameObject[] weaponColliders;

    private void Awake()
    {
        isAttacking = false;
    }

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
    
    // TODO for jack: replace these with the attack animations
    public void PlayAttackAnimation()
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

        StartCoroutine(WaitForFlinch(2f));
    }
    
    IEnumerator WaitForFlinch(float wait)
    {
        yield return new WaitForSeconds(wait);
        isAttacking = false;
        yield return wait;
    }

    public void MoveEnemy()
    {
        float minDist = 0.2f;
        GameObject player = GameObject.FindWithTag("Player");
        float dist = Vector2.Distance(transform.position, player.transform.position);
        if (dist > minDist)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, Time.deltaTime * minionData.GetSpeed());
        }
    }

    public void CheckRange()
    {
        GameObject player = GameObject.FindWithTag("Player");
        float dist = Vector2.Distance(transform.position, player.transform.position);
        if (dist < 1.5f)
        {
            isAttacking = true;
        }
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

    private void Update()
    {
        if (!isAttacking)
        {
            MoveEnemy();
        }
        else
        {
            PlayAttackAnimation();
        }
        CheckRange();
       // MoveEnemy();
    }

    public void EnableWeaponCollider(int dir)
    {
        weaponColliders[dir].SetActive(true);
    }
    
    public void DisableWeaponCollider(int dir)
    {
        weaponColliders[dir].SetActive(false);
    }
}
