using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossText : MonoBehaviour
{
    private void Update()
    {
        if (GlobalManager.Instance.GetPlayer().GetStateMachine().currentState.GetStateName() == "Boss")
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            this.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
