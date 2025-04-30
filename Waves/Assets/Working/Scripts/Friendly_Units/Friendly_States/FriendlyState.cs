using UnityEngine;

public class FriendlyState : MonoBehaviour
{
    protected FriendlyStats stats;
    protected GameObject parent;
    public bool isComplete { get; protected set; }
    protected float startTime;
    public float time => Time.time - startTime;
    
    public virtual void Enter() { }
    public virtual void Do() { }
    public virtual void FixedDo() { }
    public virtual void Exit() { }

    public void Setup(GameObject _parent, FriendlyStats _stats)
    {
        parent = _parent;
        stats = _stats;
    }
}