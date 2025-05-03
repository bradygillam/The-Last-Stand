
public class EnemyStats_Sniper : EnemyStats
{
    private void Awake()
    {
        cost = GlobalVariables.sniperEnemyCost;
        speed = GlobalVariables.sniperEnemySpeed;
        GlobalVariables.enemyCash -= cost;
    }
}