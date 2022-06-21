using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UIElements;

public class CollisionController : MonoBehaviour
{
    public GameObject wing,particleTurbo,chest;
    
    

     void Start()
     {
         particleTurbo = GameObject.FindWithTag("particleTurbo");
         chest = GameObject.FindWithTag("Chest");
         
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
            Destroy(collision.gameObject);
            PlayerMovement._instance.isFly = true;
            particleTurbo.GetComponent<ParticleSystem>().Play();
            chest.transform.DORotate(new Vector3(-10,0,0),
                2f,  RotateMode.LocalAxisAdd);
                Destroy(collision.gameObject);
                //transform.DORotate(new Vector3(0, 0, 0), 2f, RotateMode.Fast);
                StartCoroutine(Wait());
            
        }else if (collision.gameObject.tag == "obstacle")
        {
            Destroy(collision.gameObject.GetComponent<MeshCollider>());
            collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0,4f,3f));
            PlayerMovement._instance.movementSpeed--;

            
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(9f);
        PlayerMovement._instance.isFly = false;
        transform.DOMoveY(1, 2f, false).OnStepComplete(()=>particleTurbo.GetComponent<ParticleSystem>().Stop()
            );
    }

    

    
}
