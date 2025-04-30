
public class FriendlyState_Searching : FriendlyState
{
    public override void Enter()
    {
        isComplete = false;
    }
    public override void Do() { }

    public override void FixedDo()
    {
        // Exits state only when character is clicked (Enters Selected State)
    }

    public override void Exit()
    {
    }
}