using UnityEngine;

public class FriendlyMovement : MonoBehaviour
{
    [SerializeField] protected GameObject unselectedSprite;
    [SerializeField] protected GameObject selectedSprite;
    
    Vector3 targetPosition;
    private float INITIAL_X_MOV = -1f;
    private bool isSelected;
    
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
        displaySelected();
    }
    
    private void moveTowardsTarget()
    {
        if (transform.position != targetPosition)
        {
            rotateTowardsTarget();
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * unitStats.speed);
    }
    
    private void rotateTowardsTarget()
    {
        Vector2 direction = targetPosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
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
