
public class EnemyStats_MachineGunner : EnemyStats
{
    private void Awake()
    {
        cost = GlobalVariables.machineGunnerEnemyCost;
        speed = GlobalVariables.machineGunnerEnemySpeed;
    }
}