using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    [SerializeField] private Animator entityAnimator;
    //TODO weapon should be based in the initial player data might have to modify later
    [SerializeField] private Weapons playerWeapon;
    [SerializeField] private Collider weaponCollider;
    
    void PlayAttackAnimation()
    {
        //entityAnimator.Play();
    }

    void TakeDamage()
    {
        //player will lose time
    }

    //add as animation events
    public void EnableWeaponCollider()
    {
        weaponCollider.enabled = true;
    }

    public void DisableWeaponCollider()
    {
        weaponCollider.enabled = false;
    }
    
    

}
