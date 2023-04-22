using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveState : State
{
    private PlayerManager playerManager;
    private Quaternion targetRotation = Quaternion.identity;

    public override void Init(StateMachine _stateMachine)
    {
        base.Init(_stateMachine);
        playerManager = _stateMachine as PlayerManager;
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
        StopPlayer();
    }

    public override void OnTriggerEnter2D(Collider2D _other)
    {
        playerManager.SwitchToState(typeof(PlayerDeadState));
    }

    private void StopPlayer()
    {
        playerManager.PlayerRigid.velocity = Vector2.zero;
    }

    private void MovePlayer()
    {
        var _rigidBody = playerManager.PlayerRigid;
        var _moveVector = playerManager.MoveVector;
        var _smoothValue = playerManager.SmoothValue * Time.deltaTime;
        _rigidBody.velocity = Vector3.Lerp(_rigidBody.velocity, _moveVector * playerManager.MoveSpeed, _smoothValue);
    }

    private void RotatePlayer()
    {
        var _rigidBody = playerManager.PlayerRigid;
        var _moveVector = playerManager.MoveVector;
        var _smoothValue = playerManager.SmoothValue * Time.deltaTime;
        if (_moveVector.magnitude != 0) targetRotation = Quaternion.LookRotation(Vector3.forward, _moveVector);
        _rigidBody.transform.rotation = Quaternion.Lerp(_rigidBody.transform.rotation, targetRotation, _smoothValue);
    }
}
