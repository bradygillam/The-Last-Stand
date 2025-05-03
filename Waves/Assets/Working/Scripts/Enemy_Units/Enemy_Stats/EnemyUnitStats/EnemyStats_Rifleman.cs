
public class EnemyStats_Rifleman : EnemyStats
{
    private void Awake()
    {
        cost = GlobalVariables.riflemanEnemyCost;
        speed = GlobalVariables.riflemanEnemySpeed;
        GlobalVariables.enemyCash -= cost;
    }
}