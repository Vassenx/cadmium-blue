using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyWeaponTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            other.GetComponent<CombatController>().TakeDamage();
        }
    }
}
