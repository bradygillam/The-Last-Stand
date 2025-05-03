
public class EnemyStats_SpecialForces : EnemyStats
{
    private void Awake()
    {
        cost = GlobalVariables.specialForcesEnemyCost;
        speed = GlobalVariables.specialForcesEnemySpeed;
        GlobalVariables.enemyCash -= cost;
    }
}