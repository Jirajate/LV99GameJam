using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionManager : Singleton<OptionManager>
{
    public float BGMVolume = 1f;

    public override void Init()
    {
        base.Init();
        if (PlayerPrefs.HasKey("bgm")) BGMVolume = PlayerPrefs.GetFloat("bgm");
    }

    public void ChangeBGMVolume(float _value)
    {
        BGMVolume = _value;
        SoundManager.Instance.UpdateAudioVolume(_value);
        PlayerPrefs.SetFloat("bgm", _value);
    }
}
