
using UnityEngine;

public class EnemyPrefabCostPair
{
    public GameObject enemyPrefab;
    public float cost;
    
    public EnemyPrefabCostPair(GameObject prefab, float _cost)
    {
        enemyPrefab = prefab;
        cost = _cost;
    }
    
}