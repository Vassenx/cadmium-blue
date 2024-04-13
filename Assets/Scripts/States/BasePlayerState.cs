using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayerState : MonoBehaviour
{
    [SerializeField] protected string stateName;
    
    /* Summoning logic */    
    protected Meal currentMeal;
    protected List<float> timesForSummons;
    
    private float startTime;
    private float curTime;

    private void Awake()
    {
        timesForSummons = new List<float>();
    }

    public string GetStateName()
    {
        return stateName;
    }

    public virtual void Enter()
    {
        Debug.Log(stateName);
        
        if (timesForSummons.Count == 0) // if not just coming back from summons and still in same state or meal as before
        {
            currentMeal = GlobalManager.Instance.Menu[GlobalManager.Instance.CompletedMeals.Count];
            startTime = Time.time;
            
            for (int i = 0; i < currentMeal.summonableStates.Count; i++)
            {
                if (currentMeal.summonableStates[i].Equals(stateName))
                {
                    timesForSummons.Add(currentMeal.summonableTimeDuringState[i]);
                }
            }
            timesForSummons.Sort();
        }
    }
    
    public virtual void Tick()
    {
        curTime = Time.time;
        if (timesForSummons.Count > 0)
        {
            if (curTime - startTime >= timesForSummons[0])
            {
                // SUMMON TIMEEEEEE
                GlobalManager.Instance.SummonPlayer();
                timesForSummons.RemoveAt(0);
            }
        }
    }
    
    public virtual void Exit()
    {
        if (timesForSummons.Count == 0)
        {
            startTime = 0;
            curTime = 0;
        }
    }
}
