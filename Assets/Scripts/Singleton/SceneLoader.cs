using UnityEngine;
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
        SceneManager.LoadScene(_sceneName);
        currentScene = _sceneName;
    }

    public void ReloadScene()
    {
        LoadScene(currentScene);
    }
}