using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    protected bool isInit = false;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                var _gameObject = new GameObject();
                _gameObject.name = typeof(T).Name;
                instance = _gameObject.AddComponent<T>();
                DontDestroyOnLoad(_gameObject);
            }
            return instance;
        }
    }

    public virtual void Init()
    {
        if (isInit) return;
        isInit = true;
    }

    protected virtual void Awake()
    {
        Init();
    }
}