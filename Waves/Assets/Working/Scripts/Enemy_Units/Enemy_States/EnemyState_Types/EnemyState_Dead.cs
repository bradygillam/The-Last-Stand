
using UnityEngine;

public class EnemyState_Dead : EnemyState
{
    [SerializeField] protected GameObject aliveSprite;
    [SerializeField] protected GameObject deadSprite;
    
    public override void Enter()
    {
        isComplete = false;
        aliveSprite.SetActive(false);
        deadSprite.SetActive(true);
        parent.transform.rotation = Quaternion.Euler(0, 0, Random.value * 360);
    }

    public override void Do()
    {
    }

    public override void FixedDo()
    {
    }

    public override void Exit()
    {
    }
}