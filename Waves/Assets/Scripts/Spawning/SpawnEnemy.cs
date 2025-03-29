using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    private Vector3 spawnPosition;
    private float minSpawnY = 5;
    private float maxSpawnY = 1075;
    private float minSpawnX = -5;
    private float maxSpawnX = -50;

    public void spawnUnit(GameObject unit)
    {
        Quaternion spawnRotation = Quaternion.identity;
        spawnRotation.eulerAngles = new Vector3(0,0,270);
        spawnPosition = new Vector3(Random.Range(minSpawnX, maxSpawnX), Random.Range(minSpawnY, maxSpawnY), transform.position.z);
        Instantiate(unit, spawnPosition, spawnRotation);
    }
}