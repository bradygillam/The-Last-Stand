using UnityEngine;

public class RotationHandler
{
    public Quaternion rotateTowards(Vector3 currentPosition, Vector3 targetPosition)
    {
        Vector2 targetDirection = targetPosition - currentPosition;
        
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;

        return Quaternion.Euler(0f, 0f, angle);
    }
}