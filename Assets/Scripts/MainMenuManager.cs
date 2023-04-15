using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    private void Awake()
    {
        InputManager.Instance.Init();
        OptionManager.Instance.Init();
        SoundManager.Instance.Init();
        SceneLoader.Instance.Init();
    }
}
