
public class EnemyStats_Marine : EnemyStats
{
    private void Awake()
    {
        cost = GlobalVariables.marineEnemyCost;
        speed = GlobalVariables.marineEnemySpeed;
        GlobalVariables.enemyCash -= cost;
    }
}