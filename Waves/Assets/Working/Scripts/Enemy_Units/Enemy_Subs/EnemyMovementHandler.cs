using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMovementHandler : MonoBehaviour
{
    Vector3 targetPosition;
    private float MAX_Y_MOV_OFFSET = 1f;
    private float MAX_X_MOV_OFFSET = 1f;
    private float INITIAL_X_MOV = 0.5f;
    private float DEATH_PLANE = 8.7f;

    private EnemyUnitStats unitStats;
    
    void Start()
    {
        targetPosition = transform.position + new Vector3(INITIAL_X_MOV, 0f, 0f);
        unitStats = GetComponent<EnemyUnitStats>();
    }
    
    void FixedUpdate()
    {
        moveTowardsTarget();
        checkIfCrossedTheLine();
    }

    private void moveTowardsTarget()
    {
        if (transform.position == targetPosition)
        {
            selectNewTargetPosition();
            rotateTowardsTarget();
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * unitStats.speed);
    }
    
    private void checkIfCrossedTheLine()
    {
        if (transform.position.x > DEATH_PLANE)
        {
            Destroy(gameObject);
        }
    }

    private void selectNewTargetPosition()
    {
        Vector3 newPosition = new Vector3(transform.position.x + MAX_X_MOV_OFFSET, 
            transform.position.y - MAX_Y_MOV_OFFSET/2 + Random.value * MAX_Y_MOV_OFFSET, 
            transform.position.z);

        while (newPosition.y < 0)
        {
            newPosition.y = Random.value;
        } 
        while (newPosition.y > 9.6f)
        {
            newPosition.y = Random.value + 8.6f;
        }
            
        targetPosition = newPosition;
    }

    private void rotateTowardsTarget()
    {
        Vector2 direction = targetPosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
