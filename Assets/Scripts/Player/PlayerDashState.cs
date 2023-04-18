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
        canDash = true;
        playerManager.StartCoroutine(ieDash());
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }

    public override void OnExit()
    {
        base.OnExit();
        canDash = false;
    }

    private IEnumerator ieDash()
    {
        var _dashDirection = InputManager.Instance.Inputs.Player.Movement.ReadValue<Vector2>();
        var _dashDistanceVector = _dashDirection * playerManager.DashDistance;
        playerManager.PlayerRigid.AddForce(_dashDistanceVector, ForceMode2D.Impulse);
        yield return new WaitForSeconds(playerManager.DashDuration);
        playerManager.SwitchToState(typeof(PlayerMoveState));
        yield return new WaitForSeconds(playerManager.DashCooldown);
    }
}
