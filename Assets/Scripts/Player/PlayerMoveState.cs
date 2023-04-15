using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveState : State
{
    private Vector2 moveVector;

    public override void Init(StateMachine _stateMachine)
    {
        base.Init(_stateMachine);
        InputManager.Instance.Inputs.Player.Movement.performed += OnMovementPerformed;
        InputManager.Instance.Inputs.Player.Movement.canceled += OnMovementPerformed;
    }

    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);
    }

    public override void OnUpdate(StateMachine _stateMachine)
    {
        base.OnUpdate(_stateMachine);
        MovePlayer(_stateMachine);
        if (Input.GetKeyDown(KeyCode.Space)) _stateMachine.SwitchToState(typeof(PlayerDashState));
    }

    private void OnMovementPerformed(InputAction.CallbackContext _value)
    {
        moveVector = _value.ReadValue<Vector2>();
    }

    private void OnMovementCancelled(InputAction.CallbackContext _value)
    {
        moveVector = Vector2.zero;
    }

    private void MovePlayer(StateMachine _stateMachine)
    {
        var _playerManager = _stateMachine as PlayerManager;
        _playerManager.PlayerRigid.velocity = moveVector * _playerManager.MoveSpeed;
        Debug.Log(_playerManager.PlayerRigid.velocity);
    }
}
