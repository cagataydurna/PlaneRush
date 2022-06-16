using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingController : MonoBehaviour
{
    public GameObject wing;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "wing")
        {
            //gameObject.GetType("wing")+=new Vector3(0,0,0.01f);
            Destroy(collision.gameObject);
        }
    }
}
