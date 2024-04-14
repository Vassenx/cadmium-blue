using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<Minion>().Die();
        }
    }
}
