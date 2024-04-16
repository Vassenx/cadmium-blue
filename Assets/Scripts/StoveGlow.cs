using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveGlow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalManager.Instance.GetPlayer().GetStateMachine().currentState.GetStateName() 
            == "Cook" || 
        GlobalManager.Instance.GetPlayer().GetStateMachine().currentState.GetStateName()
            == "FinishMeal") {
                transform.GetChild(0).gameObject.SetActive(true);
        }
        else {
            transform.GetChild(0).gameObject.SetActive(false);
        }

    }
}
