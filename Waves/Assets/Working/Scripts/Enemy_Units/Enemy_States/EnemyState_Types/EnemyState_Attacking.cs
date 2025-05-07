using UnityEngine;

public class EnemyState_Attacking : EnemyState
{
    public override void Enter()
    {
        isComplete = false;
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
                stats._enemyTarget.GetComponentInChildren<FriendlyStats>()._health -= stats._atkDamage;
            }
        }
        isComplete = true;
    }
}