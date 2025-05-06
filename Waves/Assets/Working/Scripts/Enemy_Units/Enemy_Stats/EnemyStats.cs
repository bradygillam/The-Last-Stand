using UnityEngine;

public abstract class EnemyStats : MonoBehaviour
{
    [SerializeField] private float cost;
    [SerializeField] private float speed;

    public float _cost { get => cost; set => cost = value; }
    public float _speed { get => speed; set => speed = value; }
}