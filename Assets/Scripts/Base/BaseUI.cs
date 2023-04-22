using System.Collections;
using System;
using UnityEngine;

public class BaseUI : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private AnimationClip inClip;
    [SerializeField] private AnimationClip outClip;
    private bool isPlaying;
    public const string InTrigger = "in";
    public const string OutTrigger = "out";

    public virtual void Show(Action _onComplete = null)
    {
        if (inClip == null || isPlaying) return;
        StartCoroutine(ieShow(_onComplete));
    }

    public virtual void Hide(Action _onComplete = null)
    {
        if (outClip == null || isPlaying) return;
        StartCoroutine(ieHide(_onComplete));
    }

    private IEnumerator ieShow(Action _onComplete = null)
    {
        isPlaying = true;
        animator.SetTrigger(InTrigger);
        yield return inClip.length;
        _onComplete?.Invoke();
        isPlaying = false;
    }

    private IEnumerator ieHide(Action _onComplete = null)
    {
        isPlaying = true;
        animator.SetTrigger(OutTrigger);
        yield return outClip.length;
        _onComplete?.Invoke();
        isPlaying = false;
    }
}
