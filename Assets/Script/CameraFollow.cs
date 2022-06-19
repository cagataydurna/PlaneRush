using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class CameraFollow : MonoBehaviour
{
    public enum FollowType
    {
        Rigid,
        Lerp,
        Slerp,
    }
 
    public Transform    TargetToFollow;
 
    public Vector3      FollowOffset        = new Vector3(0, 0, -10);
 
    public float        FollowSpeed         = 5f;
 
    public FollowType   FollowMethod        = FollowType.Lerp;
 
    private Transform   _cameraTransform;
    private Vector3     _targetPos;
 
    private void Start()
    {
        if(TargetToFollow == null)
            Debug.LogError($"{nameof(TargetToFollow)} is null", this);
 
        _cameraTransform = transform;
    }
 
    private void LateUpdate()
    {
        switch (FollowMethod)
        {
            case FollowType.Rigid:
                _targetPos = TargetToFollow.position + FollowOffset;
                break;
            case FollowType.Lerp:
                _targetPos = Vector3.Lerp(_cameraTransform.position , TargetToFollow.position + FollowOffset, Time.deltaTime * FollowSpeed);
                break;
            case FollowType.Slerp:
                _targetPos = Vector3.Slerp(_cameraTransform.position, TargetToFollow.position + FollowOffset, Time.deltaTime * FollowSpeed);
                break;
        }
 
        _cameraTransform.position = _targetPos;
    }
}
