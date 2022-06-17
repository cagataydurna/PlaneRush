using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingController : MonoBehaviour
{
    public GameObject wing;

     void Start()
     {
     }

    private void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            wing = GameObject.FindGameObjectWithTag("wing");
            wing.transform.localScale+=new Vector3(0,0,0.2f);
            Destroy(collision.gameObject);
        }
    }
}
