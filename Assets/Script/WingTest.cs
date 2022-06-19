using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingTest : MonoBehaviour
{
    public static WingTest _instance;
    private GameObject player;
    
    void Start()
    {
        if (_instance == null) _instance = this;
    }

    void Update()
    {
        if(PlayerMovement._instance.isFly&& GameManager._instance.isFinish){
            if (this.gameObject.GetComponent<Renderer>().localBounds.center.z < 0)
            {
                player = GameObject.FindWithTag("Player");
                PlayerMovement._instance.fakeGravity = 1;
                player.transform.Rotate(Vector3.back * Time.deltaTime * transform.localScale.z * 5);

            }
            else if (this.gameObject.GetComponent<Renderer>().localBounds.center.z > 0)
            {
                player = GameObject.FindWithTag("Player");
                PlayerMovement._instance.fakeGravity = 1;
                player.transform.Rotate(Vector3.forward * Time.deltaTime * transform.localScale.z * 5);
            }
            else
            {
                PlayerMovement._instance.fakeGravity = -1;
            }

            ;
        }
    }
}
