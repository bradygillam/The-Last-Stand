
using UnityEngine;

public class EnemyState_OffScreen : EnemyState
{
    private float MIN_X = -8.6f;

    public override void Enter()
    {
        isComplete = false;
    }
    
    public override void Do() { }

    public override void FixedDo()
    {
        parent.transform.position = Vector3.MoveTowards(parent.transform.position, parent.transform.position + Vector3.right, Time.deltaTime * stats.speed);
        if (parent.transform.position.x > MIN_X)
        {
            isComplete = true;
        }
    }
    
    public override void Exit() { }
}