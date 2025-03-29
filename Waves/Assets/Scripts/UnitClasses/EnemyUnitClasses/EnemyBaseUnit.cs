using UnityEngine;

public class EnemyBaseUnit : MonoBehaviour
{
    [SerializeField] private float health = 100;
    [SerializeField] private float damage = 25;
    [SerializeField] private float speed = 1;
    [SerializeField] private float cashValue = 100;
    private float deathPlane = 1900;

    private void Start()
    {
        Global.ENEMIES.Add(gameObject);
    }

    public void setHealth(float health)
    {
        this.health = health;
    }

    public float getHealth()
    {
        return health;
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        transform.Translate(Vector3.up * speed);

        if (transform.position.x > deathPlane || health <= 0)
        {
            Global.ENEMIES.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}

