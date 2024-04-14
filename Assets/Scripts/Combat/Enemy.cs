using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "StevenTypes/EnemyData", order = 1)]
public class Enemy : ScriptableObject
{
    public GameObject prefab;
    public int hitPoints;
    public int speed;
    public Vector3 spawnPoint;
    public float playerStunTime;
    public float pushBackAmount;
}
