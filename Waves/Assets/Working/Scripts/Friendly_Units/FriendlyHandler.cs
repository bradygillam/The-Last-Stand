using UnityEngine;

public class FriendlyHandler : MonoBehaviour
{
    [SerializeField] private GameObject parent;
    [SerializeField] private FriendlyState_OffScreen offscreenState;
    [SerializeField] private FriendlyState_Moving movingState;
    [SerializeField] private FriendlyState_Searching searchingState;
    [SerializeField] private FriendlyState_Attacking attackingState;
    [SerializeField] private FriendlyState_Selected selectedState;
    [SerializeField] private FriendlyState_Dead deadState;
    [SerializeField] private FriendlyStats stats;
    [SerializeField] private Collider2D clickable;
    private FriendlyState state;
    private bool wasClicked;
    
    private void Awake()
    {
        offscreenState.Setup(gameObject, stats);
        movingState.Setup(gameObject, stats);
        searchingState.Setup(gameObject, stats);
        attackingState.Setup(gameObject, stats);
        selectedState.Setup(gameObject, stats);
        deadState.Setup(gameObject, stats);
        state = offscreenState;
        state.Enter();
    }

    private void Update()
    {
        detectSelected();
        state.Do();
    }
    
    private void FixedUpdate()
    {
        if (state.isComplete || wasClicked || stats._health <= 0)
        {
            selectState();
        }
        state.FixedDo();
    }
    
    private void selectState()
    {
        state.Exit();

        switch (state)
        {
            case FriendlyState_OffScreen:
                state = searchingState;
                break;
            case FriendlyState_Moving:
                if (stats._health <= 0)
                {
                    state = deadState;
                }            
                else if (wasClicked)
                {
                    wasClicked = false;
                    state = selectedState;
                }
                else if (stats._enemyTarget == null)
                {
                    state = searchingState;
                }
                else
                {
                    state = attackingState;
                }
                break;
            case FriendlyState_Searching:
                if (stats._health <= 0)
                {
                    state = deadState;
                }            
                else if (wasClicked)
                {
                    wasClicked = false;
                    state = selectedState;
                }
                else if (stats._enemyTarget == null)
                {
                    state = searchingState;
                }
                else
                {
                    state = attackingState;
                }
                break;
            case FriendlyState_Selected:
                if (stats._health <= 0)
                {
                    state = deadState;
                }            
                else if (wasClicked)
                {
                    wasClicked = false;
                    state = selectedState;
                }
                else
                {
                    state = movingState;
                }
                break;
            case FriendlyState_Attacking:
                if (stats._health <= 0)
                {
                    state = deadState;
                }            
                else if (wasClicked)
                {
                    wasClicked = false;
                    state = selectedState;
                }
                else if (stats._enemyTarget == null || stats._enemyTarget.GetComponentInChildren<EnemyStats>()._health <= 0)
                {
                    state = searchingState;

                }
                else
                {
                    state = attackingState;
                }
                break;
            case FriendlyState_Dead:
                return;
        }
        
        state.Enter();
    }

    private void detectSelected()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mouseClickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            RaycastHit2D hit = Physics2D.Raycast(mouseClickPosition, Vector2.zero);
            
            if (hit.collider == clickable)
            {
                wasClicked = true;
            }
        }
    }
}