using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    [SerializeField] private GameObject parent;
    [SerializeField] private EnemyState_OffScreen offscreenState;
    [SerializeField] private EnemyState_Moving movingState;
    [SerializeField] private EnemyState_Searching searchingState;
    [SerializeField] private EnemyState_Attacking attackingState;
    [SerializeField] private EnemyState_Dead deadState;
    [SerializeField] private EnemyStats stats;
    private EnemyState state;

    private void Awake()
    {
        offscreenState.Setup(gameObject, stats);
        movingState.Setup(gameObject, stats);
        searchingState.Setup(gameObject, stats);
        attackingState.Setup(gameObject, stats);
        deadState.Setup(gameObject, stats);
        state = offscreenState;
        state.Enter();
    }
    
    private void FixedUpdate()
    {
        if (state.isComplete || stats._health <= 0)
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
                if (stats._health <= 0)
                {
                    state = deadState;
                }
                else
                {
                    state = searchingState;
                }
                break;
            case EnemyState_Searching:
                if (stats._health <= 0)
                {
                    state = deadState;
                }
                else
                {
                    state = attackingState;
                }
                break;
            case EnemyState_Attacking:
                if (stats._health <= 0)
                {
                    state = deadState;
                }
                else
                {
                    state = movingState;
                }
                break;
            case EnemyState_Dead:
                return;
        }
        state.Enter();
    }
}
