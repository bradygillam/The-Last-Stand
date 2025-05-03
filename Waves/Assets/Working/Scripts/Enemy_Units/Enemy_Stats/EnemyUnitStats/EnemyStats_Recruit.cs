
public class EnemyStats_Recruit : EnemyStats
{
    private void Awake()
    {
        cost = GlobalVariables.recruitEnemyCost;
        speed = GlobalVariables.recruitEnemySpeed;
        GlobalVariables.enemyCash -= cost;
    }
}