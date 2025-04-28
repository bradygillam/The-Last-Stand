using UnityEngine;

public class FriendlyMovementHandler : MonoBehaviour
{
    [SerializeField] protected GameObject unselectedSprite;
    [SerializeField] protected GameObject selectedSprite;
    
    Vector3 targetPosition;
    private float INITIAL_X_MOV = -1f;
    private bool isSelected;
    private bool isMoving;
    
    private FriendlyUnitStats unitStats;
    
    void Start()
    {
        isSelected = true;
        targetPosition = transform.position + new Vector3(INITIAL_X_MOV, 0f, 0f);
        unitStats = GetComponent<FriendlyUnitStats>();
    }

    void Update()
    {
        detectSelected();
    }
    
    void FixedUpdate()
    {
        moveTowardsTarget();
        rotateTowardsTarget();
        displaySelected();
    }
    
    private void moveTowardsTarget()
    {
        if (transform.position != targetPosition)
        {
            isMoving = true;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * unitStats.speed);
        }
        else
        {
            isMoving = false;
        }
    }

    private void rotateTowardsTarget()
    {
        if (isMoving)
        {
            Vector2 direction = targetPosition - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        else if (unitStats.target != null)
        {
            Vector2 direction = unitStats.target.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
    
    private void detectSelected()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mouseClickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            if (isSelected)
            {
                targetPosition = mouseClickPosition;
                isSelected = false;
            }
            else
            {
                RaycastHit2D hit = Physics2D.Raycast(mouseClickPosition, Vector2.zero);
                
                if (hit.collider == gameObject.GetComponent<Collider2D>())
                {
                    isSelected = true;
                }
            }
        }
    }
    
    private void displaySelected()
    {
        if (isSelected)
        {
            selectedSprite.SetActive(true);
            unselectedSprite.SetActive(false);
        }
        else
        {
            selectedSprite.SetActive(false);
            unselectedSprite.SetActive(true);
        }
    }
}
