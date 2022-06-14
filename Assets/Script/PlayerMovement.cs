using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement _instance;
    public Touch theTouch;
    public float movementSpeed=10f;
    public float horSpeed=5f;
    

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    private void Update()
    {
        transform.Translate(Vector3.forward*Time.deltaTime*movementSpeed);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3f, 3f),
            transform.position.y,
            transform.position.z);
        if (Input.touchCount > 0)
        {
            theTouch = Input.GetTouch(0);
            if (theTouch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(
                    transform.position.x + theTouch.deltaPosition.x * Time.deltaTime * horSpeed,
                    transform.position.y, transform.position.z);
            }
        }
    }
}
