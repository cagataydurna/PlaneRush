using System;
using System.Collections;
using System.Collections.Generic;
using EzySlice;
using Unity.VisualScripting;
using UnityEngine;

public class Cut : MonoBehaviour
{
   public Material mat;
   public Transform otherObjTransform;
   public GameObject parent;
   

   private void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.layer == LayerMask.NameToLayer("Cut"))
      {
         otherObjTransform = other.gameObject.transform;
         SlicedHull cuttOff = Cutt(this.gameObject, mat);
         GameObject downSideOfCut = cuttOff.CreateLowerHull(this.gameObject, null); 
        GameObject upSideOfCut = cuttOff.CreateUpperHull(this.gameObject, null);
        upSideOfCut.transform.position = this.gameObject.transform.position;  
        upSideOfCut.transform.rotation = this.gameObject.transform.rotation;  
        upSideOfCut.transform.localScale = new Vector3(0.4f,0.01258f,1.105f);
        upSideOfCut.AddComponent<Rigidbody>();
        upSideOfCut.GetComponent<Rigidbody>().AddForce(Vector3.up*1000);
        downSideOfCut.transform.position = this.gameObject.transform.position;
        downSideOfCut.transform.rotation = this.gameObject.transform.rotation;
        downSideOfCut.transform.localScale = new Vector3(0.4f,0.01258f,1.105f);
        downSideOfCut.transform.SetParent(parent.transform);
        downSideOfCut.tag = "wing";
        Destroy(this.gameObject);
         

         
         Destroy(other.gameObject);

      }
   }

   private void Update()
   {
      
   }

   public SlicedHull Cutt(GameObject obj, Material crossSection = null)
   {
      return obj.Slice(otherObjTransform.transform.position, otherObjTransform.transform.up, crossSection);
   }
}
