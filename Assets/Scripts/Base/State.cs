using UnityEngine;

public abstract class State
{
    protected bool isInit = false;
    public virtual void Init(StateMachine _stateMachine)
    {
        if (isInit) return;
        isInit = true;
    }

    public virtual void OnEnter()
    {

    }

    public virtual void OnUpdate()
    {

    }

    public virtual void OnExit()
    {

    }

    public virtual void OnTriggerEnter2D(Collider2D _other)
    {

    }
}
