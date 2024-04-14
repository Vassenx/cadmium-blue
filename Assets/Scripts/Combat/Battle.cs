using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "StevenTypes/Battle", order = 1)]
public class Battle : ScriptableObject{
    public string summonableState; // states that you can be summoned during
    public float summonableTimeDuringState; // time during state that you will be summoned
    public List<Wave> waves;
}
