using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IntroText : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Destroy(gameObject);
        }
    }
}
