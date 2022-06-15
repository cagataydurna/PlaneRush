using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public static CameraFollow _instance;
    public Vector3 offSet;
    

     void Awake()
     {
         if (_instance == null) _instance = this;
        
     }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position,
            player.transform.position+offSet,
            
            Time.deltaTime*5);
    }
}
