using UnityEngine;
using DG.Tweening;

public class SoundManager : Singleton<SoundManager>
{
    public AudioSource AudioSource;
    public AudioClip GameplayBGM;
    public AudioClip MenuBGM;

    private float originalVolume = 0.3f;

    public override void Init()
    {
        base.Init();
        AudioSource = gameObject.AddComponent<AudioSource>();
        GameplayBGM = Resources.Load<AudioClip>("Sound/GameplayBGM");
        MenuBGM = Resources.Load<AudioClip>("Sound/MenuBGM");
    }

    public void PlayMenuBGM()
    {
        if (AudioSource.clip == MenuBGM) return;
        Play(MenuBGM);
    }

    public void PlayGameplayBGM(float _volume = 0.3f)
    {
        Play(GameplayBGM, _volume);
    }

    public void Play(AudioClip _audioClip, float _volume = 0.3f)
    {
        originalVolume = _volume;
        AudioSource.clip = _audioClip;
        AudioSource.volume = originalVolume * OptionManager.Instance.BGMVolume;
        AudioSource.Play();
    }

    public void UpdateAudioVolume(float _volume)
    {
        AudioSource.volume = originalVolume * _volume;
    }

    public void FadeOutAudio(float _duration)
    {
        AudioSource.DOFade(0, _duration).OnComplete(StopBGM);
    }

    public void FadeInAudio(float _duration)
    {
        AudioSource.DOFade(originalVolume, _duration);
    }

    public void StopBGM()
    {
        AudioSource.Stop();
    }
}