
using System;

public class FriendlyStats_Recruit : FriendlyStats
{
    private void Awake()
    {
        speed = GlobalVariables.recruitFriendlySpeed;
    }
}