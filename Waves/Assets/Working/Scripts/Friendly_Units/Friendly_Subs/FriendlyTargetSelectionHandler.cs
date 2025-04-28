using UnityEngine;

public class FriendlyTargetSelectionHandler : MonoBehaviour
{
    private FriendlyUnitStats unitStats;
    
    void Start()
    {
        unitStats = GetComponent<FriendlyUnitStats>();
    }

    void FixedUpdate()
    {
        selectTarget();
    }

    private void selectTarget()
    {
        if (unitStats.target == null && GlobalVariables.enemies.Count > 0)
        {
            unitStats.target = (GameObject)GlobalVariables.enemies[Random.Range(0, GlobalVariables.enemies.Count)];
        }
    }
}