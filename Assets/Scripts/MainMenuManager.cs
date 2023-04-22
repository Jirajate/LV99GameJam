using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private TextMeshProUGUI bgmText;

    private void Awake()
    {
        startButton.onClick.AddListener(StartGame);
        InputManager.Instance.Init();
        OptionManager.Instance.Init();
        SoundManager.Instance.Init();
        SceneLoader.Instance.Init();
    }

    private void StartGame()
    {
        SceneLoader.Instance.LoadGameplayScene();
    }
}
