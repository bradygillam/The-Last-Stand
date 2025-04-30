using UnityEngine;

public abstract class EnemyState : MonoBehaviour
{
    protected EnemyStats stats;
    protected GameObject parent;
    public bool isComplete { get; protected set; }
    protected float startTime;
    public float time => Time.time - startTime;
    
    public virtual void Enter() { }
    public virtual void Do() { }
    public virtual void FixedDo() { }
    public virtual void Exit() { }

    public void Setup(GameObject _parent, EnemyStats _stats)
    {
        parent = _parent;
        stats = _stats;
    }
}