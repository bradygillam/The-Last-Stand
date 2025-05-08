using UnityEngine;

public class FriendlyState_Attacking : FriendlyState
{
    public override void Enter()
    {
        isComplete = false;
        rotateTowardsTarget();
        Invoke(nameof(attackTarget), stats._atkTime);
    }
    public override void Do() { }

    public override void FixedDo()
    {
    }

    public override void Exit()
    {
        CancelInvoke(nameof(attackTarget));
    }

    private void attackTarget()
    {
        if (stats._enemyTarget != null)
        {
            if (Random.value < stats._atkSkill)
            {
                stats._enemyTarget.GetComponentInChildren<EnemyStats>()._health -= stats._atkDamage;
            }
        }
        isComplete = true;
    }
    
    private void rotateTowardsTarget()
    {
        Vector2 direction = stats._enemyTarget.transform.position - parent.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        parent.transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}