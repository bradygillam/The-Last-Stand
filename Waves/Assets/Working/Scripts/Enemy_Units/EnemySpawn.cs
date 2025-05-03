using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private List<GameObject> toSpawn;
    private float MAX_Y_SPAWN = 9.6f;
    private float MAX_X_SPAWN = 1.5f;

    void Start()
    {  
        InvokeRepeating("spawnWave", GlobalVariables.waveStartTime, GlobalVariables.waveRepeatTime);
    }

    private void spawnWave()
    {
        Debug.Log("Wave number: " + GlobalVariables.waveNumber);
        float cashToUse = 50 * GlobalVariables.waveNumber;
        toSpawn = new List<GameObject>();
        
        while (cashToUse >= 50)
        {
            int randomIndex = Random.Range(0, GlobalVariables.enemyPrefabCostPairs.Count);
            if (cashToUse >= GlobalVariables.enemyPrefabCostPairs[randomIndex].cost)
            {
                toSpawn.Add(GlobalVariables.enemyPrefabCostPairs[randomIndex].enemyPrefab);
                cashToUse -= GlobalVariables.enemyPrefabCostPairs[randomIndex].cost;
            }
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
