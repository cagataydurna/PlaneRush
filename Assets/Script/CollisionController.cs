using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CollisionController : MonoBehaviour
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
        if (collision.gameObject.tag == "collectableWing")
        {
            wing = GameObject.FindGameObjectWithTag("wing");
            wing.transform.localScale+=new Vector3(0,0,0.4f);
            Destroy(collision.gameObject);
        }else if (collision.gameObject.tag == "ramp")
        {
            transform.DOMoveY(10, 4f, false).OnStepComplete(()=>ToGround());
        }
    }

    void ToGround()
    {
        

        transform.DOMoveY(1, 7f, false);
    }
}
