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
        if (heldObject == null)
        {
            holdingObject = false;
        }

        
        if (Input.GetKeyDown("joystick button 4"))
        {
            //if player is not holding an object already, but they detect something that can be picked up
            if (!holdingObject && triggerObject != null)
            {
                PickUpCannonball();
            }
            else
            {
                DropCannonball();


            }

        }

        //cannonball follows player if player is holding the ball
        if (holdingObject)
        {
            heldObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2, gameObject.transform.position.z);
        }
        

        //    if (heldObject != null)
        //{

        //}

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PickUp")
        {
            //detects that something can be picked up
            triggerObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "PickUp")
        {
            triggerObject = null;
        }
    }

    public void DropCannonball()
    {

        heldObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - .5f, gameObject.transform.position.z);

        heldObject = null;
        holdingObject = false;

    }

    public void PickUpCannonball()
    {

        heldObject = triggerObject;
        holdingObject = true;
    }

}