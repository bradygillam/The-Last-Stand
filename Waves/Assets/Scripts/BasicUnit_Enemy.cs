using UnityEngine;

public class BasicUnit_Enemy : BasicUnit
{
    protected override void Movement(){        
        transform.Translate(Vector3.up * speed);

        if (transform.position.x > deathPlane || health <= 0)
        {
            Global.ENEMIES.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}