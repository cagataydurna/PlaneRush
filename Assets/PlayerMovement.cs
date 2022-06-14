using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement _instance;
    public Touch theTouch;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    private void Update()
    {
        if(this.gameObject.GetComponent<Rigidbody>().velocity.z < 10)
            this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward*Time.deltaTime*50);
        if (Input.touchCount > 0)
        {
            theTouch = Input.GetTouch(0);
            if (theTouch.phase == TouchPhase.Moved)
            {
                if(this.gameObject.GetComponent<Rigidbody>().rotation.y<10f&&this.gameObject.GetComponent<Rigidbody>().rotation.y>-10f)this.gameObject.GetComponent<Rigidbody>().AddTorque(new Vector3(0,theTouch.deltaPosition.x/10,0),ForceMode.Impulse);
            }
        }
        
    }
}
