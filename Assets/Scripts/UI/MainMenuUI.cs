using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MainMenuUI : BaseUI
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private TextMeshProUGUI bgmText;

    private void Awake()
    {
        startButton.onClick.AddListener(StartGame);
        exitButton.onClick.AddListener(ExitGame);
        bgmSlider.onValueChanged.AddListener(OnBGMSliderValueChanged);
        InputManager.Instance.Init();
        OptionManager.Instance.Init();
        SoundManager.Instance.Init();
        SceneLoader.Instance.Init();
        TransitionManager.Instance.Init();
        SoundManager.Instance.PlayMenuBGM();
        UpdateBGMSlider(OptionManager.Instance.BGMVolume);
    }

    private void StartGame()
    {
        SceneLoader.Instance.LoadGameplayScene();
    }

    private void ExitGame()
    {
        SceneLoader.Instance.ExitGame();
    }

    private void UpdateBGMSlider(float _value)
    {
        bgmSlider.value = OptionManager.Instance.BGMVolume;
    }

    private void UpdateBGMVolumeText(float _value)
    {
        bgmText.text = Mathf.RoundToInt(_value * 100).ToString() + "%";
    }

    private void OnBGMSliderValueChanged(float _value)
    {
        UpdateBGMVolumeText(_value);
        OptionManager.Instance.ChangeBGMVolume(_value);
    }
}
