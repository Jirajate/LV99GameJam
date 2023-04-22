using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TransitionManager : Singleton<TransitionManager>
{
    public TransitionUI TransitionUI;
    public float FadeDuration = 0.35f;

    public override void Init()
    {
        base.Init();
        if (TransitionUI == null) TransitionUI = Instantiate(Resources.Load<TransitionUI>("Prefabs/Transition Canvas"));
    }

    public void SetFadeDuration(float _duration)
    {
        FadeDuration = _duration;
    }

    public void SetFadeColor(Color _color)
    {
        TransitionUI.SetBackgroundColor(_color);
    }

    public void FadeIn(Action _onComplete = null)
    {
        TransitionUI.FadeIn(FadeDuration, _onComplete);
    }

    public void FadeOut(Action _onComplete = null)
    {
        TransitionUI.FadeOut(FadeDuration, _onComplete);
    }
}
