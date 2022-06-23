using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "collectableWing")
        {
            GameObject.FindGameObjectWithTag("wing").transform.localScale+=new Vector3(0,0,0.4f);
            Destroy(collision.gameObject);
            GameManager._instance.VibrationPopGame();
        }
    }
}
