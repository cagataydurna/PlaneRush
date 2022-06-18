using System;
using System.Collections;
using System.Collections.Generic;
using EzySlice;
using Unity.VisualScripting;
using UnityEngine;

public class Cut : MonoBehaviour
{
   public Material mat;
   public Material mat1;
   public Vector3 otherObjTransform;
   private GameObject parent;
   public GameObject refObj;
   

   private void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.layer == LayerMask.NameToLayer("Cut"))
      {
         Destroy(other.gameObject.GetComponent<MeshCollider>());
         parent = GameObject.FindWithTag("Chest");
         refObj = GameObject.FindWithTag("refObj");
         otherObjTransform = other.ClosestPoint(transform.position);
         
         SlicedHull cuttOff = Cutt(this.gameObject, mat);
         GameObject downSideOfCut = cuttOff.CreateLowerHull(this.gameObject, mat1); 
         GameObject upSideOfCut = cuttOff.CreateUpperHull(this.gameObject, mat1);
         if (other.gameObject.transform.position.x< refObj.transform.position.x)
         {
            AddComponent(upSideOfCut);
            AddTransformsLeftCut(upSideOfCut);
            AddTransformsCutOff(downSideOfCut);
            Destroy(this.gameObject);
         }
         else
         {
            AddComponent(downSideOfCut);  
            AddTransformsLeftCut(downSideOfCut);
            AddTransformsCutOff(upSideOfCut);
            Destroy(this.gameObject);

         }
         

      }
   }

   private void Update()
   {
      
   }

   public SlicedHull Cutt(GameObject obj, Material crossSection)
   {
      return obj.Slice(otherObjTransform, Vector3.right, crossSection);
   }

   public void AddComponent(GameObject obj)
   {
      
      obj.AddComponent<MeshCollider>();
      obj.GetComponent<MeshCollider>().convex = true;
      obj.GetComponent<MeshCollider>().isTrigger = true;
      obj.AddComponent<Cut>();
      obj.tag = "wing";
   }

   public void AddTransformsCutOff(GameObject obj)
   {                                                                            
      obj.transform.position = this.gameObject.transform.position;
      obj.transform.rotation = this.gameObject.transform.rotation;
      obj.transform.localScale = new Vector3(0.4f,0.01258f,1.105f);
      obj.AddComponent<Rigidbody>();
      

   }
   public void AddTransformsLeftCut(GameObject obj)
   {                                                                            
      obj.transform.position = this.gameObject.transform.position;
      obj.transform.rotation = this.gameObject.transform.rotation;
      obj.transform.localScale = new Vector3(0.4f,0.01258f,1.105f);
      obj.transform.SetParent(parent.transform);
      
   }
}
