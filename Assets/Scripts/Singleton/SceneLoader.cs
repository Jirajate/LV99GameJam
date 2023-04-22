using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader : Singleton<SceneLoader>
{
    public string currentScene;

    protected override void Awake()
    {
        base.Awake();
        currentScene = SceneManager.GetActiveScene().name;
    }

    public void LoadMenuScene()
    {
        LoadScene("MainMenu");
    }

    public void LoadGameplayScene()
    {
        LoadScene("GameplayScene");
    }

    public void LoadScene(string _sceneName)
    {
        StartCoroutine(ieLoadScene(_sceneName));
    }

    private IEnumerator ieLoadScene(string _sceneName)
    {
        TransitionManager.Instance.FadeIn();
        yield return new WaitForSeconds(TransitionManager.Instance.FadeDuration);
        SceneManager.LoadScene(_sceneName);
        currentScene = _sceneName;
        TransitionManager.Instance.FadeOut();
    }

    public void ReloadScene()
    {
        LoadScene(currentScene);
    }

    public void ExitGame()
    {
        TransitionManager.Instance.FadeIn(() => Application.Quit());
    }
}