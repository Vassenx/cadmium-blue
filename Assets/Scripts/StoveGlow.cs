using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StoveGlow : MonoBehaviour
{
    public string[] ActiveStates;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ActiveStates.Contains(GlobalManager.Instance.GetPlayer().GetStateMachine().currentState.GetStateName()))
        {
                transform.GetChild(0).gameObject.SetActive(true);
        }
        else {
            transform.GetChild(0).gameObject.SetActive(false);
        }

    }
}
