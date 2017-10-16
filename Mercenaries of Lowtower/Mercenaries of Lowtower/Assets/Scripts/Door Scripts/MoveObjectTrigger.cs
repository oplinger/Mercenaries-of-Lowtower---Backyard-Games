using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectTrigger : MonoBehaviour {

    public bool trigger = true;
    public Vector3 moveDir;
    public GameObject target;


        private void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && trigger == true)
        {
           MoveObject(moveDir, target);
        }
       
    }
        
    public void MoveObject (Vector3  moveDirection, GameObject target)
    {

       target.transform.Translate ( moveDirection);
        trigger = false;
        //door moves up
    }
}

