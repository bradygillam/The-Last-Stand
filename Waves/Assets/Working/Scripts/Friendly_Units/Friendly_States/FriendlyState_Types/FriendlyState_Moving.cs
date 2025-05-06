using UnityEngine;

public class FriendlyState_Moving : FriendlyState
{
    private Vector3 targetPosition;
    private float MIN_Y = 0;
    private float MAX_Y = 9.6f;
    private float MIN_X = -8.8f;
    private float MAX_X = 8.8f;
    
    public override void Enter()
    {
        isComplete = false;
        checkInbounds();
        rotateTowardsTarget();
    }
    public override void Do() { }

    public override void FixedDo()
    {
        parent.transform.position = Vector3.MoveTowards(parent.transform.position, targetPosition, Time.deltaTime * stats._speed);
        if (parent.transform.position == targetPosition)
        {
            isComplete = true;
        }
    }
    public override void Exit() { }

    private void checkInbounds()
    {
        if (targetPosition.y < MIN_Y)
        { 
            targetPosition.y = MIN_Y;
        } else if (targetPosition.y > MAX_Y)
        {
            targetPosition.y = MAX_Y;
        } else if (targetPosition.x < MIN_X)
        {
            targetPosition.x = MIN_X;
        } else if (targetPosition.x > MAX_X)
        {
            targetPosition.x = MAX_X;
        }
    }
    private void rotateTowardsTarget()
    {
        Vector2 direction = targetPosition - parent.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        parent.transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void setTargetPosition(Vector2 targetPosition)
    {
        this.targetPosition = targetPosition;
    }
}