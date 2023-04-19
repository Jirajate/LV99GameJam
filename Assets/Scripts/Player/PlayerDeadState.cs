using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDeadState : State
{
    private PlayerManager playerManager;

    public override void Init(StateMachine _stateMachine)
    {
        base.Init(_stateMachine);
        playerManager = _stateMachine as PlayerManager;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        InputManager.Instance.RemoveAllCallback();
        SceneLoader.Instance.ReloadScene();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}
