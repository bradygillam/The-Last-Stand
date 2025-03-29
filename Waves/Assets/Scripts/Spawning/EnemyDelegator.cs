using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyDelegator : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyUnitPrefabs;
    private float cashToSpend;
    private SpawnEnemy spawn;

    private void Start()
    {
        spawn = gameObject.GetComponent<SpawnEnemy>();
    }

    public void delegateCash(int waveNumber)
    {
        calculateCashToSpend(waveNumber);
        
        while (cashToSpend >= 100)
        {
            int randomUnitIndex = Random.Range(0, enemyUnitPrefabs.Length);
            GameObject unit = enemyUnitPrefabs[randomUnitIndex];
            cashToSpend -= 100;
            spawn.spawnUnit(unit);
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
}