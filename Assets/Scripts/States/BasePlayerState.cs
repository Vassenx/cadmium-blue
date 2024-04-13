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
    protected Meal lastMeal; // this is for when done with summoning for this state and meal. Please ignore this. Im sorry
    
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
        
        currentMeal = GlobalManager.Instance.Menu[GlobalManager.Instance.CompletedMeals.Count];

        if (lastMeal != currentMeal && timesForSummons.Count == 0) // if not just coming back from summons and still in same state or meal as before
        {
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
        if (lastMeal != currentMeal && timesForSummons.Count > 0)
        {
            if (curTime - startTime >= timesForSummons[0])
            {
                timesForSummons.RemoveAt(0);
                
                // Im tired, please excuse this
                // done with summoning during this state for this meal
                if (timesForSummons.Count == 0)
                {
                    lastMeal = currentMeal;
                }
                
                // SUMMON TIMEEEEEE
                GlobalManager.Instance.SummonPlayer();
            }
        }
    }
    
    public virtual void Exit()
    {
        if (lastMeal == currentMeal)
        {
            startTime = 0;
            curTime = 0;
        }
    }
}
