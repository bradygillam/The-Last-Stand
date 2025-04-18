using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    private float MAX_Y_SPAWN = 9.6f;

    void Start()
    {
    }
    
    void Update()
    {
        Vector3 spawnPosition = new Vector3(transform.position.x, Random.value * MAX_Y_SPAWN, transform.position.z);
        Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPosition, Quaternion.identity);
    }
}
