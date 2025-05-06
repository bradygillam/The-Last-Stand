using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private List<GameObject> possibleEnemiesToSpawn;
    private List<EnemyPrefabCostPair> enemiesCostPairs;
    private List<GameObject> toSpawn;
    private float MAX_Y_SPAWN = 9.6f;
    private float MAX_X_SPAWN = 1.5f;
    private int DEBUGcount;

    void Start()
    {  
        enemiesCostPairs = new List<EnemyPrefabCostPair>();
        foreach (GameObject enemy in possibleEnemiesToSpawn)
        {
            enemiesCostPairs.Add(new EnemyPrefabCostPair(enemy, enemy.GetComponentInChildren<EnemyStats>()._cost));
        }
        InvokeRepeating("spawnWave", GlobalVariables.waveStartTime, GlobalVariables.waveRepeatTime);
    }

    private void spawnWave()
    {
        float cashToUse = 50 * GlobalVariables.waveNumber;
        toSpawn = new List<GameObject>();
        DEBUGcount = 0;
        while (cashToUse >= 50 && DEBUGcount < 25)
        {
            int randomIndex = Random.Range(0, enemiesCostPairs.Count);
            if (cashToUse >= enemiesCostPairs[randomIndex].cost)
            {
                toSpawn.Add(enemiesCostPairs[randomIndex].enemyPrefab);
                cashToUse -= enemiesCostPairs[randomIndex].cost;
            }
            DEBUGcount++;
        }
        
        spawnEnemies();
        GlobalVariables.waveNumber++;
    }

    private void spawnEnemies()
    {
        foreach (GameObject enemy in toSpawn)
        {
            Vector3 spawnPosition = new Vector3(transform.position.x + Random.value * MAX_X_SPAWN, 
                                            Random.value * MAX_Y_SPAWN, 
                                            transform.position.z);
            GameObject newEnemy = Instantiate(enemy, spawnPosition, Quaternion.identity);
            GlobalVariables.enemies.Add(newEnemy);
        }
    }
}
