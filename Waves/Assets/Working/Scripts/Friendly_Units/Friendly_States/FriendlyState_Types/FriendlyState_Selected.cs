using UnityEngine;

public class FriendlyState_Selected : FriendlyState
{
    [SerializeField] protected GameObject unselectedSprite;
    [SerializeField] protected GameObject selectedSprite;
    [SerializeField] protected FriendlyState_Moving movingState;

    public override void Enter()
    {
        isComplete = false;
        unselectedSprite.SetActive(false);
        selectedSprite.SetActive(true);
    }

    public override void Do()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mouseClickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            movingState.setTargetPosition(mouseClickPosition);
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