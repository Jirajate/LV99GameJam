using System.Collections.Generic;
using UnityEngine;
using System;

public class StateMachine : MonoBehaviour
{
    public Dictionary<Type, State> states = new Dictionary<Type, State>();
    public State currentState;

    public virtual void Init()
    {
        foreach(var _state in states.Values) _state.Init(this);
    }

    public virtual void AddState(Type _type, State _state)
    {
        states.Add(_type, _state);
    }

    public virtual void RemoveState(Type _type)
    {
        states.Remove(_type);
    }

    public virtual void SwitchToState(Type _type)
    {
        SetCurrentState(_type);
        currentState.OnEnter(this);
    }

    private void SetCurrentState(Type _type)
    {
        currentState = states[_type];
    }
}
