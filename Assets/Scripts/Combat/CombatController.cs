using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    [SerializeField] private Animator entityAnimator;
    //TODO weapon should be based in the initial player data might have to modify later
    [SerializeField] private Weapons playerWeapon;
    [SerializeField] private GameObject weaponObject;
    [SerializeField] private PlayerMovement playerMovement;

    [SerializeField] private Vector2 mousePosition;
    [SerializeField] private GameObject[] weaponColliders;

    public bool isAttacking;
    public bool inAttackingMotion;
    public bool isHurt;
    [SerializeField] private float hurtTime;

    private void Awake()
    {
        isAttacking = false;
        inAttackingMotion = false;
    }

    public void Attack()
    {
        if (Input.GetMouseButtonDown(0) && !inAttackingMotion)
        {
            //Debug.Log(GetMouseOrientation());
            float angle = GetMouseOrientation();
            if (angle < 40 && angle > -20)
            {
                entityAnimator.Play("ATTACK_N");
                // ensure it retains last orientation edit: it dont work, i cry, i dont care no more
                
            }
            else if (angle >= 40 && angle < 120)
            {
                entityAnimator.Play("ATTACK_W");
                SetAnimParamFloat(1, "LastX");
                SetAnimParamFloat(0, "LastY");
            }   
            else if (angle >= 121 && angle < 260)
            {
                entityAnimator.Play("ATTACK_S");
                SetAnimParamFloat(0, "LastX");
                SetAnimParamFloat(-1, "LastY");
            }
            else
            {
                entityAnimator.Play("ATTACK_E");
                SetAnimParamFloat(-1, "LastX");
                SetAnimParamFloat(0, "LastY");
            }
        }
    }

    public void TakeDamage()
    {
        //player will lose time
        isHurt = true;
        StartCoroutine(WaitForFlinch(hurtTime));
    }

    IEnumerator WaitForFlinch(float wait)
    {
        yield return new WaitForSeconds(wait);
        isHurt = false;
        yield return wait;
    }

    public float GetMouseOrientation()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 rot = mousePosition - new Vector2(transform.position.x, transform.position.y);
        var angleDeg = Mathf.Atan2(rot.y, rot.x) * Mathf.Rad2Deg;
        if (angleDeg < 0)
        {
            angleDeg += 360;
        }

        return angleDeg - 90;
    }
    
    /* TODO debug on scren no need until play build
    void OnGUI()
    {
        Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        GUI.Label(new Rect(10, 10, 100, 20), "PlayerPos" + mousePos.X + " " + mousePos.Y);
    }
    */
    
    /* Dictate Animator */
    public void SetAnimParamFloat(float value, string param)
    {
        entityAnimator.SetFloat(param, value);
    }

    public void EnableAttack()
    {
        inAttackingMotion = true;
        isAttacking = true;
    }

    public void DisableAttack()
    {
        isAttacking = false;
        inAttackingMotion = false;
    }

    public void EnableWeaponCollider(int dir)
    {
        weaponColliders[dir].gameObject.SetActive(true);
    }

    public void DisableWeaponCollider(int dir)
    {
        weaponColliders[dir].gameObject.SetActive(false);
    }
    
}
