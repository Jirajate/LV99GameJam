using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDashState : State
{
    private PlayerManager playerManager;
    private bool canDash = true;

    public override void Init(StateMachine _stateMachine)
    {
        base.Init(_stateMachine);
        playerManager = _stateMachine as PlayerManager;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        if (canDash) playerManager.StartCoroutine(ieDash());
        else playerManager.SwitchToState(typeof(PlayerMoveState));
    }

    public override void OnTriggerEnter2D(Collider2D _other)
    {
        playerManager.SwitchToState(typeof(PlayerDeadState));
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    private IEnumerator ieDash()
    {
        canDash = false;
        var _dashDirection = InputManager.Instance.Inputs.Player.Movement.ReadValue<Vector2>();
        var _dashDistanceVector = _dashDirection * playerManager.DashDistance;
        playerManager.PlayerRigid.AddForce(_dashDistanceVector, ForceMode2D.Impulse);
        yield return new WaitForSeconds(playerManager.DashDuration);
        playerManager.SwitchToState(typeof(PlayerMoveState));
        yield return new WaitForSeconds(playerManager.DashCooldown);
        canDash = true;
    }
}
