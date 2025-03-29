using UnityEngine;

public class MovementFriendlyHandler
{
    public Vector2 movement(Vector3 from, Vector3 to, float speed)
    {
        return Vector2.MoveTowards(from, to, speed);
    }
}
