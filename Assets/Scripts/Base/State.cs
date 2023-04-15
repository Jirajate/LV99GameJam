using UnityEngine;

public abstract class State
{
    protected bool isInit = false;
    public virtual void Init(StateMachine _stateMachine)
    {
        if (isInit) return;
        isInit = true;
    }

    public virtual void OnEnter(StateMachine _stateMachine)
    {

    }

    public virtual void OnUpdate(StateMachine _stateMachine)
    {

    }

    public virtual void OnCollisionEnter(StateMachine _stateMachine)
    {

    }
}
