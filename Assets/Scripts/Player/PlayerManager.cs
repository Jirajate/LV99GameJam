using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerManager : StateMachine
{
    [field: SerializeField] public Rigidbody2D PlayerRigid { get; private set; }
    public Vector2 MoveVector { get; private set; }
    public float MoveSpeed = 5f;
    public float DashDistance = 5.0f;
    public float DashDuration = 0.2f;
    public float DashCooldown = 0.2f;
    public float SmoothValue = 10f;

    [SerializeField] private Button backButton;
    private bool isHitByParticle = false;

    private void Awake()
    {
        backButton.onClick.AddListener(BacktoMenu);
        AddState(typeof(PlayerMoveState), new PlayerMoveState());
        AddState(typeof(PlayerDashState), new PlayerDashState());
        AddState(typeof(PlayerDeadState), new PlayerDeadState());
        Init();
    }

    public override void Init()
    {
        base.Init();
        BindPlayerInputs();
        SwitchToState(typeof(PlayerMoveState));
        StartCoroutine(ieStartGame());
    }

    private void Update()
    {
        currentState.OnUpdate();
    }

    private void OnTriggerEnter2D(Collider2D _other)
    {
        currentState.OnTriggerEnter2D(_other);
    }

    private void OnParticleCollision(GameObject _other)
    {
        if (isHitByParticle) return;
        isHitByParticle = true;
        currentState.OnTriggerEnter2D(null);
    }

    private IEnumerator ieStartGame()
    {
        SoundManager.Instance.PlayGameplayBGM();
        yield return new WaitForSeconds(SoundManager.Instance.GameplayBGM.length);
        EndGame();
    }

    #region Input Binding
    public void BindPlayerInputs()
    {
        InputManager.Instance.Inputs.Player.Movement.performed += OnMovementPerformed;
        InputManager.Instance.Inputs.Player.Movement.canceled += OnMovementCancelled;
        InputManager.Instance.Inputs.Player.Dash.performed += OnDashPerformed;
        InputManager.Instance.EnableInput();
    }

    public void UnBindPlayerInputs()
    {
        MoveVector = Vector2.zero;
        InputManager.Instance.Inputs.Player.Movement.performed -= OnMovementPerformed;
        InputManager.Instance.Inputs.Player.Movement.canceled -= OnMovementCancelled;
        InputManager.Instance.Inputs.Player.Dash.performed -= OnDashPerformed;
        InputManager.Instance.DisableInput();
    }

    private void OnMovementPerformed(InputAction.CallbackContext _value)
    {
        MoveVector = _value.ReadValue<Vector2>();
    }

    private void OnMovementCancelled(InputAction.CallbackContext _value)
    {
        MoveVector = Vector2.zero;
    }
    private void OnDashPerformed(InputAction.CallbackContext _value)
    {
        SwitchToState(typeof(PlayerDashState));
    }

    private void EndGame()
    {
        UnBindPlayerInputs();
        SceneLoader.Instance.LoadEndGameScene();
    }

    private void BacktoMenu()
    {
        UnBindPlayerInputs();
        SceneLoader.Instance.LoadMenuScene();
    }
    #endregion
}
