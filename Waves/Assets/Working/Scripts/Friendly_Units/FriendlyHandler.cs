using UnityEngine;

public class FriendlyHandler : MonoBehaviour
{
    [SerializeField] private FriendlyState_OffScreen offscreenState;
    [SerializeField] private FriendlyState_Moving movingState;
    [SerializeField] private FriendlyState_Searching searchingState;
    [SerializeField] private FriendlyState_Selected selectedState;
    [SerializeField] private FriendlyStats stats;
    [SerializeField] private Collider2D clickable;
    private FriendlyState state;
    private bool wasClicked;
    
    private void Awake()
    {
        offscreenState.Setup(gameObject, stats);
        movingState.Setup(gameObject, stats);
        searchingState.Setup(gameObject, stats);
        selectedState.Setup(gameObject, stats);
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
        if (state.isComplete || wasClicked)
        {
            selectState();
        }
        state.FixedDo();
    }
    
    private void selectState()
    {
        state.Exit();
        if (wasClicked)
        {
            wasClicked = false;
            state = selectedState;
        }
        else
        {
            switch (state)
            {
                case FriendlyState_OffScreen:
                    state = searchingState;
                    break;
                case FriendlyState_Moving:
                    state = searchingState;
                    break;
                case FriendlyState_Selected:
                    state = movingState;
                    break;
                default:
                    state = searchingState;
                    break;
            }
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