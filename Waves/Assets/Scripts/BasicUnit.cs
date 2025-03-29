using UnityEngine;

public class BasicUnit : MonoBehaviour
{
    protected float health = 100;
    protected float damage = 50;
    protected virtual float speed { get; set; } = 1;
    protected float cashValue = 100;
    protected float deathPlane = 1900;

    protected void Update()
    {
        Movement();
    }

    protected virtual void Movement(){}
    protected void TakeDamage(){}
    protected void Heal(){}
    protected void DealDamage(){}
    protected void ChooseTarget(){}
}
