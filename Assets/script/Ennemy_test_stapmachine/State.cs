using UnityEngine;

public abstract class State : MonoBehaviour
{
    public bool isComplete { get; protected set; }

    protected float startTime;

    public float time => Time.time - startTime;


    protected Rigidbody2D body;

    protected Animator animator;

    protected bool grounded;

    protected float xInput;

    protected float yInput;

    public virtual void Enter() { }

    public virtual void Do() { }

    public virtual void FixedDo() { }

    public virtual void Exit() { }
}
