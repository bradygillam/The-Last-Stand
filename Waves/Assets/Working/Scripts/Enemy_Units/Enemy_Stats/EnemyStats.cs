using UnityEngine;

public abstract class EnemyStats : MonoBehaviour
{
    [SerializeField] private float cost;
    [SerializeField] private float health;
    [SerializeField] private float speed;
    [SerializeField] private float searchTime;
    [SerializeField] private float atkTime;
    [SerializeField] private float atkSkill;
    [SerializeField] private float atkDamage;
    private GameObject enemyTarget;

    public float _cost { get => cost; set => cost = value; }
    public float _health { get => health; set => health = value; }
    public float _speed { get => speed; set => speed = value; }
    public float _searchTime { get => searchTime; set => searchTime = value; }
    public float _atkTime { get => atkTime; set => atkTime = value; }
    public float _atkSkill { get => atkSkill; set => atkSkill = value; }
    public float _atkDamage { get => atkDamage; set => atkDamage = value; }
    public GameObject _enemyTarget { get; set; }
}