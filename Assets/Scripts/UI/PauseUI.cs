using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseUI : BaseUI
{
    [SerializeField] private Button backButton;

    private void Awake()
    {
        backButton.onClick.AddListener(BacktoMenu);
    }

    private void BacktoMenu()
    {
        SceneLoader.Instance.LoadMenuScene();
    }
}
