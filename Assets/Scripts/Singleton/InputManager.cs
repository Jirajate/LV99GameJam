using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : Singleton<InputManager>
{
    public CustomInput Inputs;

    public override void Init()
    {
        base.Init();
        Inputs = new CustomInput();
        Inputs.Enable();
    }

    public void EnableInput()
    {
        Inputs.Enable();
    }

    public void DisableInput()
    {
        Inputs.Disable();
    }
}