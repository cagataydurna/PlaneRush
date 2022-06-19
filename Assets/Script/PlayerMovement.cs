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
    public float movementSpeed=10f;
    public float horSpeed=5f;
    public bool isFly;
    public int fakeGravity = 0;


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
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;
            if (Input.touchCount > 0 && !isFly)
            {
                
                Vector3 pos = new Vector3(horizontal * Time.deltaTime * horSpeed, 0, 0);
                transform.position += pos;
                {
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
            }
       
            else if (isFly)
            {
                Physics.gravity = new Vector3(0, 0, 0);
                transform.localPosition += new Vector3(horizontal * Time.deltaTime * horSpeed,
                    (vertical+fakeGravity) * Time.deltaTime * horSpeed, 0);
                transform.rotation=Quaternion.Lerp(transform.rotation, Quaternion.Euler(-vertical*horSpeed*3,0,-horizontal*horSpeed*3),Time.deltaTime);
              
            }else 
            {
                transform.rotation=Quaternion.Lerp(transform.rotation,
                    Quaternion.Euler(0,0,0),
                    Time.deltaTime*2);
                GameObject.FindWithTag("Chest").transform.rotation=Quaternion.Lerp(GameObject.FindWithTag("Chest").transform.rotation,Quaternion.Euler(10,180,0),Time.deltaTime*3 );
            }

            




       
            
       
        }
    }

