using UnityEngine;

public class EnemyState_Searching : EnemyState
{
    private int i;

    public override void Enter()
    {
        isComplete = false;
        i = 0;
    }
    public override void Do() { }

    public override void FixedDo()
    {
        i++;
        if (i == 100)
        {
            isComplete = true;
        }
    }

    public override void Exit()
    {
        
    }
}
