using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    [SerializeField] private Animator entityAnimator;
    //TODO weapon should be based in the initial player data might have to modify later
    [SerializeField] private Weapons playerWeapon;
    [SerializeField] private GameObject weaponObject;
    [SerializeField] private PlayerMovement playerMovement;

    [SerializeField] private Vector2 mousePosition;
    
    void PlayAttackAnimation()
    {
        //entityAnimator.Play();
    }

    void TakeDamage()
    {
        //player will lose time
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
    
    //add as animation events
    public void EnableWeaponCollider()
    {
       
    }

    public void DisableWeaponCollider()
    {
       
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
}
