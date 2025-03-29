using UnityEngine;

public class SpawnSoldier : MonoBehaviour
{
    [SerializeField] private GameObject friendlySpawnPoint;
    [SerializeField] private GameObject soldierPrefab;
    [SerializeField] private float soldierCost = 100f;
    private float minSpawnY = 5;
    private float maxSpawnY = 1075;


    public void spawnSoldier()
    {
        if (Global.playerCash >= soldierCost)
        {
            Vector3 spawnLocation = new Vector3(
                friendlySpawnPoint.transform.position.x,
                Random.Range(minSpawnY, maxSpawnY),
                friendlySpawnPoint.transform.position.z);
            
            Global.playerCash -= soldierCost;
            Quaternion spawnRotation = Quaternion.identity;
            spawnRotation.eulerAngles = new Vector3(0,0,90);
            Instantiate(soldierPrefab, spawnLocation, spawnRotation);
        }
    }
}
