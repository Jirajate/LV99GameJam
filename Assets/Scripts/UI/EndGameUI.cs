using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameUI : MonoBehaviour
{
    [SerializeField] private float duration = 10f;

    private void Awake()
    {
        StartCoroutine(ieShowCredit());
    }

    private IEnumerator ieShowCredit()
    {
        SoundManager.Instance.PlayMenuBGM();
        yield return new WaitForSeconds(duration);
        SceneLoader.Instance.LoadMenuScene();
    }
}
