using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader : Singleton<SceneLoader>
{
    public string currentScene;
    [SerializeField] private float startGameFadeDuration = 0.35f;
    [SerializeField] private float exitGameFadeDuration = 0.35f;
    [SerializeField] private float endGameFadeDuration = 0.35f;
    [SerializeField] private float backToMenuFadeDuration = 0.35f;
    [SerializeField] private float reloadSceneFadeDuration = 0.15f;
    [SerializeField] private Color reloadSceneColor = Color.white;

    protected override void Awake()
    {
        base.Awake();
        currentScene = SceneManager.GetActiveScene().name;
    }

    public void LoadMenuScene()
    {
        TransitionManager.Instance.SetFadeColor(Color.black);
        TransitionManager.Instance.SetFadeDuration(backToMenuFadeDuration);
        LoadScene("MainMenu");
    }

    public void LoadGameplayScene()
    {
        TransitionManager.Instance.SetFadeColor(Color.black);
        TransitionManager.Instance.SetFadeDuration(startGameFadeDuration);
        LoadScene("GameplayScene");
    }

    public void LoadEndGameScene()
    {
        TransitionManager.Instance.SetFadeColor(Color.black);
        TransitionManager.Instance.SetFadeDuration(endGameFadeDuration);
        LoadScene("EndGameScene");
    }

    public void LoadScene(string _sceneName)
    {
        StartCoroutine(ieLoadScene(_sceneName));
    }

    private IEnumerator ieLoadScene(string _sceneName)
    {
        TransitionManager.Instance.FadeIn();
        yield return new WaitForSeconds(TransitionManager.Instance.FadeDuration);
        SoundManager.Instance.StopBGM();
        SceneManager.LoadScene(_sceneName);
        currentScene = _sceneName;
        TransitionManager.Instance.FadeOut();
    }

    public void ReloadScene()
    {
        TransitionManager.Instance.SetFadeColor(reloadSceneColor);
        TransitionManager.Instance.SetFadeDuration(reloadSceneFadeDuration);
        LoadScene(currentScene);
    }

    public void ExitGame()
    {
        TransitionManager.Instance.SetFadeColor(Color.black);
        TransitionManager.Instance.SetFadeDuration(exitGameFadeDuration);
        TransitionManager.Instance.FadeIn(() => Application.Quit());
    }
}