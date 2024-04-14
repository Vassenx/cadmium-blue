using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    //waves 
    // Spawn in 
    // FightMobs
    // Go back when time is up

    private Wave curWave;
    int enemyCount;
    private Battle battle;
    private int waveIndex = 0;
    public float timeBetweenWaves = 3f;
    
    void Start()
    {
        var manager = GlobalManager.Instance;
        battle = manager.Menu[manager.CompletedMeals.Count].battles[manager.curBattleIndex];
        enemyCount = battle.waves[waveIndex].enemyListToSpawn.Count;
        SpawnWave();
    }
    
    void SpawnWave()
    {
        if (waveIndex >= battle.waves.Count)
        {
            // done with waves
            GlobalManager.Instance.GetPlayer().GetStateMachine().ChangeState(GlobalManager.Instance.GetStateByName("Boss"));
        }
        
        curWave = battle.waves[waveIndex];
        waveIndex++;
        enemyCount = curWave.enemyListToSpawn.Count;
        
        foreach (var enemy in curWave.enemyListToSpawn)
        {
            Instantiate(enemy, enemy.spawnPoint, Quaternion.identity);
        }
    }

    IEnumerator NextWave()
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        SpawnWave();
    }
    
    public void OnEnemyDeath()
    {
        enemyCount--;
        if (enemyCount <= 0)
        {
            StartCoroutine(NextWave());
        }
    }
}
