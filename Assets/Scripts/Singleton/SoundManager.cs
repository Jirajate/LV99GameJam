using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    private AudioSource audioSource;
    private AudioClip gameplayBGM;

    public override void Init()
    {
        base.Init();
        audioSource = gameObject.AddComponent<AudioSource>();
        gameplayBGM = Resources.Load<AudioClip>("Sound/GameplayBGM");
    }

    public void PlayMenuBGM()
    {
        Play(gameplayBGM);
    }

    public void PlayGameplayBGM()
    {
        Play(gameplayBGM);
    }

    public void Play(AudioClip _audioClip, float _volume = 0.5f)
    {
        audioSource.clip = _audioClip;
        audioSource.volume = _volume;
        audioSource.Play();
    }
}