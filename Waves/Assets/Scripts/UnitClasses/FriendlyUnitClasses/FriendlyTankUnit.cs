using Unity.VisualScripting;
using UnityEngine;

public class FriendlyTankUnit : MonoBehaviour
{
    private bool isSelected;
    private Vector3 targetPosition;
    private float directionAngle;
    private float enemyAngle;
    private float startLeft = 50;
    
    [SerializeField] private GameObject unselectedSprite;
    [SerializeField] private GameObject selectedSprite;
    
    private void Start()
    {
        Health = 100;
        Damage = 25;
        Speed = 1;
        targetPosition = transform.position + (startLeft * Vector3.left);
        directionAngle = 180;
        isSelected = true;
    }

    public float Health { get; set; }
    public float Damage { get; set; }
    public float Speed { get; set; }
    
    private void Update()
    {
        detectSelect();
        displaySelected();
    }

    private void FixedUpdate()
    {
        if (targetPosition != transform.position)
        {
            movement();
        }
        
        direction();
    }

    private void detectSelect()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mouseClickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            if (isSelected)
            {
                targetPosition = mouseClickPosition;
                Vector2 direction = targetPosition - transform.position;
                directionAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
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

    private void movement()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, Speed);
    }

    private void direction()
    { 
        transform.rotation = Quaternion.Euler(0, 0, directionAngle);
    }
}