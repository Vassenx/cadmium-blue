using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Data", menuName = "StevenTypes/Meal", order = 1)]
public class Meal : ScriptableObject{
    public string dishName;
    public UnityEngine.Vector2 gatherLocation;
    public UnityEngine.Vector2 prepLocation;
    public float cookTime;
    public float greatThreshold;
    public float goodThreshold;
    public int breakPoint;

    // this is a "Unity dictionary"
    public List<string> summonableStates; // states that you can be summoned during
    public List<float> summonableTimeDuringState; // time during state that you will be summoned
    
}

