using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawning : MonoBehaviour
{
    [SerializeField] float waveStartTime = 5;
    [SerializeField] float waveRepeatTime = 5;
    private int waveNumber;
    
    [SerializeField] private GameObject[] enemyUnitPrefabs;
    private float cashToSpend;
    
    private Vector3 spawnPosition;
    private float minSpawnY = 5;
    private float maxSpawnY = 1075;
    private float minSpawnX = -5;
    private float maxSpawnX = -100;

    private void Start()
    {
        waveNumber = 0;
        InvokeRepeating("spawnWave",waveStartTime, waveRepeatTime);
    }

    
    
    void spawnWave()
    {
        waveNumber++;
        delegateCash(waveNumber);
    }
    
    
    
    public void delegateCash(int waveNumber)
    {
        calculateCashToSpend(waveNumber);
        
        while (cashToSpend >= 100)
        {
            int randomUnitIndex = Random.Range(0, enemyUnitPrefabs.Length);
            GameObject unit = enemyUnitPrefabs[randomUnitIndex];
            cashToSpend -= 100;
            spawnUnit(unit);
        }
    }

    private void calculateCashToSpend(int waveNumber)
    {
        cashToSpend = 200f * waveNumber;
    }

    public float getCashToSpend()
    {
        return cashToSpend;
    }
    
    
    
    
    public void spawnUnit(GameObject unit)
    {
        Quaternion spawnRotation = Quaternion.identity;
        spawnRotation.eulerAngles = new Vector3(0,0,270);
        spawnPosition = new Vector3(Random.Range(minSpawnX, maxSpawnX), Random.Range(minSpawnY, maxSpawnY), transform.position.z);
        Instantiate(unit, spawnPosition, spawnRotation);
    }

}
