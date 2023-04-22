using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TransitionUI : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] Image backgroundImage;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void SetBackgroundColor(Color _color)
    {
        backgroundImage.color = _color;
    }

    public void FadeIn(float _duration, Action _onComplete = null)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.DOFade(1, _duration);
        _onComplete?.Invoke();
    }

    public void FadeOut(float _duration, Action _onComplete = null)
    {
        canvasGroup.DOFade(0, _duration).OnComplete(() => canvasGroup.blocksRaycasts = false);
        _onComplete?.Invoke();
    }
}
