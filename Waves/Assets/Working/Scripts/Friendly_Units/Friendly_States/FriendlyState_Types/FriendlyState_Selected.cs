using UnityEngine;

public class FriendlyState_Selected : FriendlyState
{
    [SerializeField] protected GameObject unselectedSprite;
    [SerializeField] protected GameObject selectedSprite;
    [SerializeField] protected FriendlyState_Moving movingState;
    Vector3 oldPosition;

    public override void Enter()
    {
        oldPosition = stats._targetPosition;
        isComplete = false;
        unselectedSprite.SetActive(false);
        selectedSprite.SetActive(true);
    }

    public override void Do()
    {
        if (oldPosition != stats._targetPosition)
        {
            isComplete = true;
        }
    }

    public override void FixedDo()
    {

    }

    public override void Exit()
    {
        selectedSprite.SetActive(false);
        unselectedSprite.SetActive(true);
    }
}