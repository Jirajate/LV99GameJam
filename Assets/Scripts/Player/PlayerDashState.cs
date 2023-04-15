using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : State
{
    public override void Init(StateMachine _stateMachine)
    {
        base.Init(_stateMachine);
    }
    
    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);
    }

    public override void OnUpdate(StateMachine _stateMachine)
    {
        base.OnUpdate(_stateMachine);
        _stateMachine.SwitchToState(typeof(PlayerMoveState));
    }
}
