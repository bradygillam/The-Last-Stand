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
    private float waveNumber;

    void Start()
    {
        cashToSpend = ENEMY_START_CASH;        
        waveNumber = 0;
        InvokeRepeating("spawnWave", wavesStart, waveRepeat);
    }

    private void spawnWave()
    {
        cashToSpend += 50 * waveNumber;
        
        while (cashToSpend >= 100f)
        {
            spawnEnemy();
        }
        
        waveNumber++;
    }

    private void spawnEnemy()
    {
        Vector3 spawnPosition = new Vector3(transform.position.x + Random.value * MAX_X_SPAWN, 
                                        Random.value * MAX_Y_SPAWN, 
                                        transform.position.z);
        Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPosition, Quaternion.identity);
        cashToSpend -= 50f;
    }
}
