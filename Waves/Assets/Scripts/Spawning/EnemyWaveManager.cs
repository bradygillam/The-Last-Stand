using UnityEngine;

public class EnemyWaveManager : MonoBehaviour
{
    [SerializeField] float waveStartTime = 5;
    [SerializeField] float waveRepeatTime = 5;
    private EnemyDelegator spawner;
    private int waveNumber;
    
    void Start()
    {
        waveNumber = 0;
        spawner = gameObject.GetComponent<EnemyDelegator>();
        InvokeRepeating("spawnWave",waveStartTime, waveRepeatTime);
    }

    void spawnWave()
    {
        waveNumber++;
        spawner.delegateCash(waveNumber);
    }
}
