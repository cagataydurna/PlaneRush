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
    public Transform TargetObject;
    public float MoveSmoothTime = 0.3F;
    public float RotationSpeed = 6f;
    public Vector3 Offset = new Vector3(0f, 15f, 0f);

    public bool Enabled = true;

    private Transform myTransform;
    private Vector3 velocity = Vector3.zero;

    void Awake()
    {
        myTransform = this.transform;
    }

    void FixedUpdate()
    {
        if (TargetObject != null && Enabled)
        {
            Vector3 targetPosition = TargetObject.TransformPoint(Offset);
            myTransform.position = Vector3.SmoothDamp(myTransform.position, targetPosition, ref velocity, MoveSmoothTime);
            
        }
    }
}
