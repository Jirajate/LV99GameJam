using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : StateMachine
{
    [SerializeField] public Rigidbody2D PlayerRigid;
    [SerializeField] public float MoveSpeed;
    [SerializeField] public float DashSpeed;

    private void Awake()
    {
        AddState(typeof(PlayerMoveState), new PlayerMoveState());
        AddState(typeof(PlayerDashState), new PlayerDashState());
        Init();
        SwitchToState(typeof(PlayerMoveState));
    }

    private void Update()
    {
        currentState.OnUpdate(this);
    }

    private void OnCollisionEnter2D(Collision2D _other)
    {
        currentState.OnCollisionEnter(this);
    }
}