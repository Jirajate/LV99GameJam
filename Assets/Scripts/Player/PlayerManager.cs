using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : StateMachine
{
    [SerializeField] public Rigidbody2D PlayerRigid;
    [SerializeField] public float MoveSpeed = 5f;
    [SerializeField] public float DashDistance = 5.0f;
    [SerializeField] public float DashDuration = 0.2f;
    [SerializeField] public float DashCooldown = 0.2f;
    [SerializeField] public float SmoothValue = 10f;

    private void Awake()
    {
        AddState(typeof(PlayerMoveState), new PlayerMoveState());
        AddState(typeof(PlayerDashState), new PlayerDashState());
        AddState(typeof(PlayerDeadState), new PlayerDeadState());
        Init();
    }

    public override void Init()
    {
        base.Init();
        SwitchToState(typeof(PlayerMoveState));
        SoundManager.Instance.PlayGameplayBGM();
    }

    private void Update()
    {
        currentState.OnUpdate();
    }

    private void OnTriggerEnter2D(Collider2D _other)
    {
        currentState.OnTriggerEnter2D(_other);
    }
}
