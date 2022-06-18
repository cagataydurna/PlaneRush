using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement _instance;
    public Touch theTouch;
    public DynamicJoystick joystick;
    public float movementSpeed=10f;
    public float horSpeed=5f;
    public bool isFinish;
    

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3f, 3f),
            transform.position.y,
            transform.position.z);
        
            if (Input.touchCount > 0)
            {
                float horizontal = joystick.Horizontal;
                float vertical = joystick.Vertical;
                Vector3 pos = new Vector3(horizontal * Time.deltaTime * horSpeed, 0, 0);
                transform.position += pos;
                if(!isFinish){
                    if (horizontal < 0)
                    {
                        transform.rotation = Quaternion.Lerp(transform.rotation,
                            Quaternion.Euler(0, -6, 0),
                            Time.deltaTime * 7);
                    }
                    else if (horizontal > 0)
                    {
                        transform.rotation = Quaternion.Lerp(transform.rotation,
                            Quaternion.Euler(0, 6, 0),
                            Time.deltaTime * 7);
                    }
                    else
                    {
                        transform.rotation = Quaternion.Lerp(transform.rotation,
                            Quaternion.Euler(0, 0, 0),
                            Time.deltaTime * 2);
                    }
                }
                else
                {
                    Physics.gravity = new Vector3(0, 0, 0);
                    transform.position += new Vector3(horizontal*Time.deltaTime*horSpeed, vertical*Time.deltaTime*horSpeed, 0);
                    if (horizontal < 0)
                    {
                        transform.rotation = Quaternion.Lerp(transform.rotation,
                            Quaternion.Euler(0, 0, 10),
                            Time.deltaTime * 7);
                    }
                    else if (horizontal > 0)
                    {
                        transform.rotation = Quaternion.Lerp(transform.rotation,
                            Quaternion.Euler(0, 0, -10),
                            Time.deltaTime * 7);
                    }
                }

                
        }else
                         transform.rotation = Quaternion.Lerp(transform.rotation,
                             Quaternion.Euler(0, 0, 0),
                             Time.deltaTime * 2);
       
            
        /*transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3f, 3f),
            transform.position.y,
            transform.position.z);
        if (Input.touchCount > 0)
        {
            theTouch = Input.GetTouch(0);
            if (theTouch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(
                    transform.position.x + theTouch.deltaPosition.normalized.x * Time.deltaTime * horSpeed,
                    transform.position.y, transform.position.z);
                
               if(theTouch.deltaPosition.x<0) transform.rotation=Quaternion.Lerp(transform.rotation,
                    Quaternion.Euler(0,-6,0),
                    Time.deltaTime*7);
               else if(theTouch.deltaPosition.x>0) transform.rotation=Quaternion.Lerp(transform.rotation,
                   Quaternion.Euler(0,6,0),
                   Time.deltaTime*7);
               else transform.rotation=Quaternion.Lerp(transform.rotation,
                   Quaternion.Euler(0,0,0),
                   Time.deltaTime*2);
            }
            
        }else transform.rotation=Quaternion.Lerp(transform.rotation,
            Quaternion.Euler(0,0,0),
            Time.deltaTime*2);*/
        }
    }

