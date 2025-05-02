
using UnityEngine;

public class FriendlyState_OffScreen : FriendlyState
{
    private float MAX_X = 8.6f;

    public override void Enter()
    {
        isComplete = false;
        parent.transform.rotation = Quaternion.Euler(0, 0, 180);
    }
    
    public override void Do() { }

    public override void FixedDo()
    {
        parent.transform.position = Vector3.MoveTowards(parent.transform.position, parent.transform.position + Vector3.left, Time.deltaTime * stats.speed);
        if (parent.transform.position.x < MAX_X)
        {
            isComplete = true;
        }
    }
    
    public override void Exit() { }
}