using Unity.VisualScripting;
using UnityEngine;

public class TurretAiming : MonoBehaviour
{
    private EnemyBaseUnit target;

    private float directionAngle;
    private float enemyAngle;
    private float damage = 25;

    private void FixedUpdate()
    {
        chooseTargetEnemy();

        if (target != null)
        {
            attack();
        }

        direction();
    }

    private void chooseTargetEnemy()
    {
        float closestToMe = Mathf.Infinity;

        foreach (Object enemy in Global.ENEMIES)
        {
            EnemyBaseUnit candidateEnemy = enemy.GetComponent<EnemyBaseUnit>();

            float distanceFromMe = (candidateEnemy.transform.position - transform.position).magnitude;

            if (distanceFromMe < closestToMe)
            {
                closestToMe = distanceFromMe;
                target = candidateEnemy;
            }
        }

        if (target != null)
        {
            Vector2 direction = target.transform.position - transform.position;
            enemyAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        }
    }

    private void direction()
    {
        if (target != null)
        {
            transform.rotation = Quaternion.Euler(0, 0, enemyAngle - 90);
        }
    }
    
    private void attack()
    {
        if (Random.value < 0.01f)
        {
            target.setHealth( target.getHealth() - damage);
        }
    }
}
