using UnityEngine;

public class EnemyState_Searching : EnemyState
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
        if (GlobalVariables.friendlies.Count > 0)
        {
            int randomIndex = Random.Range(0, GlobalVariables.friendlies.Count);
            stats._enemyTarget = (GameObject) GlobalVariables.friendlies[randomIndex];
        }
        isComplete = true;
    }
}
