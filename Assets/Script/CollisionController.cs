using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
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
            GameManager._instance.VibrationPopGame();

        }else if (collision.gameObject.tag == "ramp")//Oyun bitişi çizgisi
        {
            Physics.gravity = new Vector3(0, 0f, 0);
            transform.DORotate(new Vector3(0, 0, 0), 1f, RotateMode.Fast);
            collision.gameObject.GetComponent<BoxCollider>().enabled = false;
            transform.DOMoveY(5, 1, false);

            GameManager._instance.isFinish = true;
            PlayerMovement._instance.isFly = true;
            PlayerMovement._instance.clampValue = 6f;
            GameManager._instance.VibrationPopGame();


        }else if (collision.gameObject.tag=="gas")
        {
            PlayerMovement._instance.movementSpeed++;
            Destroy(collision.gameObject);
            GameManager._instance.VibrationPopGame();

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
                GameManager._instance.VibrationPopGame();

            
        }else if (collision.gameObject.tag == "obstacle")
        {
            Destroy(collision.gameObject.GetComponent<MeshCollider>());
            collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0,4f,3f));
            PlayerMovement._instance.movementSpeed--;
            GameManager._instance.VibrationPopGame();

        }else if (collision.gameObject.tag == "finishPanel")
        {
            GameManager._instance.finishPanelCount++;
            collision.gameObject.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
            Destroy(collision.gameObject.GetComponent<MeshRenderer>());
            collision.gameObject.transform.GetChild(1).GameObject().SetActive(false);
            Destroy(collision.gameObject.GetComponent<MeshCollider>());
            GameObject.FindGameObjectWithTag("wing").transform.localScale-=new Vector3(0,0,0.4f);
            GameManager._instance.VibrationPopGame();


        }else if (collision.gameObject.tag == "finishGround")
        {
            GameManager._instance.isFailFinish = true;
            GameManager._instance.VibrationPopGame();
            
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(9f);
        PlayerMovement._instance.isFly = false;
        particleTurbo.GetComponent<ParticleSystem>().Stop();
        PlayerMovement._instance.FixRotation();
        transform.DOMoveY(0.84f, 4f, false);

    }

    

    
}
