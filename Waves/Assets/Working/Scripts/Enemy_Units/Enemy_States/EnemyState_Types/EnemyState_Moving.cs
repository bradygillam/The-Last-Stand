
using UnityEngine;

public class EnemyState_Moving : EnemyState
{
    private Vector3 targetPosition;
    private float MIN_Y = 0;
    private float MAX_Y = 9.6f;
    private float MIN_Y_RETRY = 8.6f;
    private float MAX_MOVE_OFFSET = 5f;
    private float DEATH_PLANE = 8.7f;

    public override void Enter()
    {
        isComplete = false;
        selectTargetLocation();
        rotateTowardsTarget();
    }
    
    public override void Do() { }

    public override void FixedDo()
    {
        parent.transform.position = Vector3.MoveTowards(parent.transform.position, targetPosition, Time.deltaTime * stats._speed);
        if (parent.transform.position.x > DEATH_PLANE)
        {
            Destroy(parent);
        }
        else if (parent.transform.position == targetPosition)
        {
            isComplete = true;
        }
    }
    
    public override void Exit() { }

    private void selectTargetLocation()
    {
        Vector3 newPosition = new Vector3(transform.position.x + Random.value * MAX_MOVE_OFFSET, 
            transform.position.y - MAX_MOVE_OFFSET/2 + Random.value * MAX_MOVE_OFFSET, 
            transform.position.z);

        while (newPosition.y < MIN_Y)
        {
            newPosition.y = Random.value;
        } 
        while (newPosition.y > MAX_Y)
        {
            newPosition.y = Random.value + MIN_Y_RETRY;
        }
            
        targetPosition = newPosition;
    }
    
    private void rotateTowardsTarget()
    {
        Vector2 direction = targetPosition - parent.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        parent.transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}