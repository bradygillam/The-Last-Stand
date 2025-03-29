using UnityEngine;

public class BaseUnitFriendly : MonoBehaviour
{
    protected bool isSelected;
    protected Vector3 targetPosition;
    protected Quaternion movementQuaternion;
    protected Quaternion enemyQuaternion;
    protected EnemyBaseUnit target;
    
    [SerializeField] protected float FIRST_LEFT_STEP = 50;
    [SerializeField] protected float damage = 1;
    [SerializeField] protected float speed = 1;
    protected MovementFriendlyHandler movementHandler;
    protected AttackHandler attackHandlerHandler;
    protected TargetPickingHandler targettingHandler;
    protected RotationHandler rotationHandler;
    [SerializeField] protected GameObject unselectedSprite;
    [SerializeField] protected GameObject selectedSprite;
    
    protected void Start()
    {
        targetPosition = transform.position + (FIRST_LEFT_STEP * Vector3.left);
        movementQuaternion = Quaternion.Euler(0f, 0f, 180);
        isSelected = true;
        
        movementHandler = new MovementFriendlyHandler();
        attackHandlerHandler = new AttackHandler();
        targettingHandler = new TargetPickingHandler();
        rotationHandler = new RotationHandler();
    }
    
    protected void Update()
    {
        detectSelect();
        displaySelected();
    }

    protected void FixedUpdate()
    {
        if (targetPosition != transform.position)
        {
            move();
        }

        chooseTargetEnemy();

        if (target != null)
        {
            attack();
        }

        direction();
    }

    protected void detectSelect()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mouseClickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            if (isSelected)
            {
                targetPosition = mouseClickPosition;
                movementQuaternion = rotationHandler.rotateTowards(transform.position, targetPosition);
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

    protected void displaySelected()
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

    protected void chooseTargetEnemy()
    {
        target = (EnemyBaseUnit) targettingHandler.chooseTarget(transform.position, Global.ENEMIES);

        if (target != null)
        {
            enemyQuaternion = rotationHandler.rotateTowards(transform.position, target.transform.position);
        }
    }

    protected virtual void direction()
    {
        transform.rotation = movementQuaternion;
    }
    
    protected void move()
    {
        transform.position = movementHandler.movement(transform.position, targetPosition, speed);
    }
    
    protected void attack()
    {
        target.setHealth( target.getHealth() - attackHandlerHandler.attackDamage(damage));
    }
}
