
using UnityEngine;

public class FriendlyState_Searching : FriendlyState
{
    public override void Enter()
    {
        isComplete = false;
        Invoke(nameof(selectTarget), stats._searchTime);
    }
    public override void Do() { }

    public override void FixedDo()
    {
        // Waits until target is selected
    }

    public override void Exit()
    {
        CancelInvoke(nameof(selectTarget));
    }

    private void selectTarget()
    {
        if (GlobalVariables.enemies.Count > 0)
        {
            int randomIndex = Random.Range(0, GlobalVariables.enemies.Count);
            stats._enemyTarget = (GameObject) GlobalVariables.enemies[randomIndex];
        }
        isComplete = true;
    }
}
