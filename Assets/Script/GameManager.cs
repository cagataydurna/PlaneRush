using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    public bool isFinish;
    void Awake()
    {
        isFinish = false;
        if (_instance == null) _instance = this;
    }

    void Update()
    {
        
    }
}
