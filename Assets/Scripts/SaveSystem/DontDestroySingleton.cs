using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroySingleton<T> : MonoBehaviour where T : DontDestroySingleton<T>
{
    public static T Instance;
    public virtual void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = (T)this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
