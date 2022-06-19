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
            Physics.gravity = new Vector3(0, 0f, 0);
            transform.DOMoveY(10, 2f, false);

        }else if (collision.gameObject.tag=="gas")
        {
            PlayerMovement._instance.movementSpeed++;
            Destroy(collision.gameObject);
        }else if (collision.gameObject.tag == "turbo")
        {
            PlayerMovement._instance.isFly = true;
            GameObject.FindWithTag("Chest").transform.DORotate(new Vector3(-10,0,0),
                2f,  RotateMode.LocalAxisAdd);
                Destroy(collision.gameObject);
            StartCoroutine(Wait());
            
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5f);
        PlayerMovement._instance.isFly = false;
        transform.DOMoveY(1, 2f, false);
    }

    
}
