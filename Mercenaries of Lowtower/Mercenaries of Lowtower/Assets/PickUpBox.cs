using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Orange Player
public class PickUpBox : MonoBehaviour
{
    public bool holdingObject;
    public GameObject heldObject;
    public GameObject triggerObject;
    public GameObject cannonball;

    private void Update()
    {
        if (holdingObject == true)
        {
            // heldObject.transform.position = gameObject.transform.position;
        }
        if (Input.GetKeyDown("joystick button 4"))
        {
            if (!holdingObject && triggerObject != null)
            {
                heldObject = triggerObject;
                //heldObject.gameObject.GetComponent<SphereCollider>().enabled = true;
                holdingObject = true;
            }
            else
            {
                heldObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - .5f, gameObject.transform.position.z);

                heldObject = null;
                holdingObject = false;


            }

        }

        //if (Input.GetKeyDown(KeyCode.Space)&& holdingObject)
        //{

        //    cannonball.GetComponent<Rigidbody>().AddForce(transform.forward * 2);
        //}

            if (heldObject != null)
            heldObject.transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y+2, gameObject.transform.position.z);

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PickUp")
        {
            //Debug.Log("Box picked up!");
            //holdingObject = true;
            triggerObject = other.gameObject;
            //triggerObject.transform.position= new Vector3(transform.position.x, transform.position.y+3, transform.position.z);
            //heldObject.gameObject.GetComponent<SphereCollider>().enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "PickUp")
        {
            triggerObject = null;
        }
    }

}