using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    [SerializeField] private EnemyState_Moving movingState;
    [SerializeField] private EnemyState_Selecting selectingState;
    [SerializeField] private EnemyStats stats;
    private EnemyState state;

    private void Awake()
    {
        movingState.Setup(this.gameObject, stats);
        selectingState.Setup(this.gameObject, stats);
        state = movingState;
        state.Enter();
    }
    
    private void FixedUpdate()
    {
        if (state.isComplete)
        {
            selectState();
        }
        state.FixedDo();
    }

    private void selectState()
    {
        state.Exit();
        Debug.Log("Leaving state " + state);
        switch (state)
        {
            case EnemyState_Moving:
                state = selectingState;
                break;
            case EnemyState_Selecting:
                state = movingState;
                break;
            default:
                state = movingState;
                break;
        }
        Debug.Log("Entering state " + state);
        state.Enter();
    }
    
    
}
