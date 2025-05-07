
using UnityEngine;

public class FriendlyState_Dead : FriendlyState
{
    [SerializeField] protected GameObject unselectedSprite;
    [SerializeField] protected GameObject selectedSprite;
    [SerializeField] protected GameObject deadSprite;
    
    public override void Enter()
    {
        isComplete = false;
        unselectedSprite.SetActive(false);
        selectedSprite.SetActive(false);
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