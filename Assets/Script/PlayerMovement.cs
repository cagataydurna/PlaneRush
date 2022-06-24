using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public static PlayerMovement _instance;
    public Touch theTouch;
    public DynamicJoystick joystick;
    public bool isStart;
    public float movementSpeed=5f;
    public float horSpeed=5f;
    public bool isFly;
    public float fakeGravity = 0;
    public float flySpeed = 5f;
    public float clampValue = 3f;
    


     void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

     void FixedUpdate()
    {


        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -clampValue, clampValue),
            transform.position.y,
            transform.position.z);
        
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;
            if (Input.touchCount > 0 && !isFly&&isStart)
            {
            
                if (transform.position.y > 0.84)
                {
                
                    transform.DOMoveY(0.80f, 1f, false);
                }
                theTouch = Input.GetTouch(0);
                Physics.gravity = new Vector3(0, -9.81f, 0);

                transform.position += transform.forward * Time.deltaTime * movementSpeed;
               if(theTouch.deltaPosition.x>-5 || theTouch.deltaPosition.x<5) {
                
                    var rot1 = new Vector3(0, Mathf.Clamp(theTouch.deltaPosition.normalized.x * horSpeed * 10, -30, 30),
                        0);
                    transform.rotation =
                        Quaternion.Lerp(transform.rotation, Quaternion.Euler(rot1), Time.deltaTime );
                }
               else
               {
                   FixRotation();
               }



            }
       
            else if (isFly)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
                Physics.gravity = new Vector3(0, 0, 0);
                transform.localPosition += new Vector3(horizontal * Time.deltaTime * flySpeed*2,
                    (vertical) * Time.deltaTime * flySpeed, 0);
                transform.rotation=Quaternion.Lerp(transform.rotation, Quaternion.Euler(Mathf.Clamp(-vertical*8*GameManager._instance.sizeOfWing,-15,15),0,
                    Mathf.Clamp(-horizontal * 8*GameManager._instance.sizeOfWing,-10,10)),Time.deltaTime);
                if(Input.touchCount==0) FixRotation();
              
            }else 
            {
               FixRotation();
            }

           

        }
     public void FixRotation()
     {
         Physics.gravity = new Vector3(0, -9.81f, 0);

         transform.rotation=Quaternion.Lerp(transform.rotation,
             Quaternion.Euler(0,0,0),
             Time.deltaTime*2);
         GameObject.FindWithTag("Chest").transform.rotation=Quaternion.Lerp(GameObject.FindWithTag("Chest").transform.rotation,Quaternion.Euler(10,180,0),Time.deltaTime*4 );
         if (transform.position.y > 0.84&& !isFly&& transform.position.y<0.81f)
         {
             transform.DOMoveY(0.80f, 0.1f, false);
         }
     }
    }

