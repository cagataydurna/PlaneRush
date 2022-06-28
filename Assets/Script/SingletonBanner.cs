using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonBanner : MonoBehaviour
{
    public static SingletonBanner obj = null;

    public void Awake()
    {
        if (obj == null)
        {
            obj = this;
            DontDestroyOnLoad(this);
        }
        else if(this != obj)
        {
            Destroy(gameObject);
        }
    }
}
