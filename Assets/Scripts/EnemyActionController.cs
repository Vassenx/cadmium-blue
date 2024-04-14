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
        

        if (angle <= 225 && angle > 135)
        {
            enemyAnimator.Play("EWalk_N");
        }
        else if (angle > 45 && angle <= 135)
        {
            enemyAnimator.Play("EWalk_E");
        }
        else if (angle <= 45 && angle > -45)
        {
            enemyAnimator.Play("EWalk_S");
        }
        else
        {
            enemyAnimator.Play("EWalk_W");
        }
    }
    
    // TODO for jack: replace these with the attack animations
    public void PlayAttackAnimation()
    {
        //isAttacking = true;
        //janky but acceptable for a gamejam
        float angle = ReturnAngle();
        //Debug.Log(angle);

        if (angle <= 225 && angle > 135)
        {
            enemyAnimator.Play("EAttack_N");
        }
        else if (angle > 45 && angle <= 135)
        {
            enemyAnimator.Play("EAttack_E");
        }
        else if (angle <= 45 && angle > -45)
        {
            enemyAnimator.Play("EAttack_S");
        }
        else
        {
            enemyAnimator.Play("EAttack_W");
        }

        //StartCoroutine(WaitForFlinch(0.5f));
    }
    
    IEnumerator WaitForFlinch(float wait)
    {
        yield return new WaitForSeconds(wait);

        for (int i = 0; i<weaponColliders.Length; i++)
        {
            weaponColliders[i].SetActive(false);
        }

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
            PlayMoveAnimation();
        }
    }

    public void CheckRange()
    {
        GameObject player = GameObject.FindWithTag("Player");
        float dist = Vector2.Distance(transform.position, player.transform.position);
        //Debug.Log(dist);
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
        StartCoroutine(WaitForFlinch(0.5f));
    }
}
