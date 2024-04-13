using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    //waves 
    // Spawn in 
    // FightMobs
    // Go back when time is up

    public Wave wave;
    int enemyCount;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyCount = wave.enemyListToSpawn.Count;
        SpawnWave();
    }
    
    void SpawnWave() {
        foreach (var enemy in wave.enemyListToSpawn) {
            Instantiate(enemy, enemy.spawnPoint, Quaternion.identity);
        }
    }
}
