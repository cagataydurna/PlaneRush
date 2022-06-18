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
            Physics.gravity = new Vector3(0, 1f, 0);
            transform.DOMoveY(10, 4f, false).OnStepComplete(()=>ToGround());
            transform.DORotate(new Vector3(5f, 0, 0), 4f,
                RotateMode.FastBeyond360).OnStepComplete(() => ToFallAxis()).OnStepComplete(() => ToFixAxis());
        }
    }

    void ToGround()
    {
        transform.DOMoveY(1, 5f, false);
        Physics.gravity = new Vector3(0, -9.81f, 0);
    }

    void ToFallAxis()
    {
        transform.transform.DORotate(new Vector3(-3f, 0, 0), 4f,
            RotateMode.FastBeyond360);
    }

    void ToFixAxis()
    {
        transform.DORotate(new Vector3(0, 0, 0), 1f, RotateMode.FastBeyond360);
    }
}
