using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "StevenTypes/WaveData", order = 1)]
public class Wave : ScriptableObject
{
    public List<Enemy> enemyListToSpawn;
}
