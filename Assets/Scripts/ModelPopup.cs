using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class ModelPopup : MonoBehaviour
    {

        public bool mAddModel = true;

        public GameObject Box;
    public void Create() {
        
            Debug.Log("Adding model...");

            Box = GameObject.CreatePrimitive(PrimitiveType.Cube);

            Box.transform.parent = this.gameObject.transform;

            // Adjust scale and position 
            // (use localScale and localPosition to make it relative to the parent)
            Box.transform.localScale = new Vector3(0.03f, 0.08f, 0.03f);
            Box.transform.localPosition = new Vector3(0, 0.5f, 0);
            Box.transform.localRotation = Quaternion.identity;

            Box.gameObject.SetActive(true);

     

      
        }
    }