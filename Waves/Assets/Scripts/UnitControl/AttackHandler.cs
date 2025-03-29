using UnityEngine;

public class AttackHandler
{
    public float attackDamage(float attackPower)
    {
        if (Random.value < 0.01f)
        {
            return attackPower;
        }

        return 0f;
    }

}