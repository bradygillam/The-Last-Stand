using System.Linq;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private float ENEMY_START_CASH = 100f;
    [SerializeField] private float wavesStart = 1f;
    [SerializeField] private float waveRepeat = 3f;
    private float MAX_Y_SPAWN = 9.6f;
    private float MAX_X_SPAWN = 1.5f;
    private float cashToSpend;

    void Start()
    {
        cashToSpend = ENEMY_START_CASH;        
        InvokeRepeating("spawnWave", wavesStart, waveRepeat);
    }

    private void spawnWave()
    {
        cashToSpend += 10 * GlobalVariables.waveNumber;
        
        while (cashToSpend >= 100f)
        {
            spawnEnemy();
        }
        
        GlobalVariables.waveNumber++;
    }

    private void spawnEnemy()
    {
        Vector3 spawnPosition = new Vector3(transform.position.x + Random.value * MAX_X_SPAWN, 
                                        Random.value * MAX_Y_SPAWN, 
                                        transform.position.z);
        GameObject newEnemy = Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPosition, Quaternion.identity);
        GlobalVariables.enemies.Add(newEnemy);
        cashToSpend -= 50f;
    }
}
