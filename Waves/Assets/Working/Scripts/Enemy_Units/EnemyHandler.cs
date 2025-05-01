using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    [SerializeField] private EnemyState_OffScreen offscreenState;
    [SerializeField] private EnemyState_Moving movingState;
    [SerializeField] private EnemyState_Searching searchingState;
    [SerializeField] private EnemyStats stats;
    private EnemyState state;

    private void Awake()
    {
        offscreenState.Setup(gameObject, stats);
        movingState.Setup(gameObject, stats);
        searchingState.Setup(gameObject, stats);
        state = offscreenState;
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
        switch (state)
        {
            case EnemyState_OffScreen:
                state = movingState;
                break;
            case EnemyState_Moving:
                state = searchingState;
                break;
            case EnemyState_Searching:
                state = movingState;
                break;
            default:
                state = movingState;
                break;
        }
        state.Enter();
    }
}
