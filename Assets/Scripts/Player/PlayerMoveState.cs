using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveState : State
{
    private PlayerManager playerManager;
    private Vector2 moveVector;
    private Quaternion targetRotation = Quaternion.identity;

    public override void Init(StateMachine _stateMachine)
    {
        base.Init(_stateMachine);
        playerManager = _stateMachine as PlayerManager;
        InputManager.Instance.Inputs.Player.Movement.performed += OnMovementPerformed;
        InputManager.Instance.Inputs.Player.Movement.canceled += OnMovementPerformed;
    }

    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        RotatePlayer();
        MovePlayer();
    }

    public override void OnExit()
    {
        base.OnExit();
        playerManager.PlayerRigid.velocity = Vector2.zero;
    }

    public override void OnTriggerEnter2D(Collider2D _other)
    {
        playerManager.SwitchToState(typeof(PlayerDeadState));
    }

    private void OnMovementPerformed(InputAction.CallbackContext _value)
    {
        moveVector = _value.ReadValue<Vector2>();
    }

    private void OnMovementCancelled(InputAction.CallbackContext _value)
    {
        moveVector = Vector2.zero;
    }

    private void MovePlayer()
    {
        var _rigidBody = playerManager.PlayerRigid;
        var _smoothValue = playerManager.SmoothValue * Time.deltaTime;
        _rigidBody.velocity = Vector3.Lerp(_rigidBody.velocity, moveVector * playerManager.MoveSpeed, _smoothValue);
    }

    private void RotatePlayer()
    {
        var _rigidBody = playerManager.PlayerRigid;
        var _smoothValue = playerManager.SmoothValue * Time.deltaTime;
        if (moveVector.magnitude != 0) targetRotation = Quaternion.LookRotation(Vector3.forward, moveVector);
        _rigidBody.transform.rotation = Quaternion.Lerp(_rigidBody.transform.rotation, targetRotation, _smoothValue);
    }
}
