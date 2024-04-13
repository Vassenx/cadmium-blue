using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "StevenTypes/EnemyData", order = 1)]
public class Enemy : ScriptableObject
{
    public int hitPoints;
    public int speed;
}
