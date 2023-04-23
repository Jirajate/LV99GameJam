using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public AudioSource AudioSource;
    public AudioClip GameplayBGM;

    public override void Init()
    {
        base.Init();
        AudioSource = gameObject.AddComponent<AudioSource>();
        GameplayBGM = Resources.Load<AudioClip>("Sound/GameplayBGM");
    }

    public void PlayMenuBGM()
    {
        Play(GameplayBGM);
    }

    public void PlayGameplayBGM(float _volume = 0.3f)
    {
        Play(GameplayBGM, _volume);
    }

    public void Play(AudioClip _audioClip, float _volume = 0.5f)
    {
        AudioSource.clip = _audioClip;
        AudioSource.volume = _volume * OptionManager.Instance.BGMVolume;
        AudioSource.Play();
    }

    public void StopBGM()
    {
        AudioSource.Stop();
    }
}