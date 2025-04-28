using UnityEngine;

public class EnemyTargetSelectionHandler : MonoBehaviour
{
    private EnemyUnitStats unitStats;
    
    void Start()
    {
        unitStats = GetComponent<EnemyUnitStats>();
    }

    void FixedUpdate()
    {
        selectTarget();
    }

    private void selectTarget()
    {
        if (unitStats.target == null && GlobalVariables.friendlies.Count > 0)
        {
            unitStats.target = (GameObject)GlobalVariables.friendlies[Random.Range(0, GlobalVariables.friendlies.Count)];
        }
    }
}