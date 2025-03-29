using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class TargetPickingHandler
{
    
    public Object chooseTarget(Vector3 from, ArrayList candidates)
    {
        Object target = null;
        float closest = Mathf.Infinity;

        foreach (Object enemy in candidates)
        {
            EnemyBaseUnit candidateEnemy = enemy.GetComponent<EnemyBaseUnit>();

            float distanceFromMe = (candidateEnemy.transform.position - from).magnitude;

            if (distanceFromMe < closest)
            {
                closest = distanceFromMe;
                target = candidateEnemy;
            }
        }
        
        return target;
    }
}