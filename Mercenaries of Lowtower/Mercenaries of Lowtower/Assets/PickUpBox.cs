using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//Orange Player
public class PickUpBox : MonoBehaviour
{
    public bool holdingObject;
    public GameObject heldObject;
    public GameObject triggerObject;
    public GameObject cannonball;
    public GameObject player;
    public  GameObject parentPlayer;
    public GameObject enemy;
    public AIControllerNavMesh enemyScript;
    public GameObject minionSpawner;
    public GameObject pickUpButton;

    public int charID;


    private void Start()
    {
        player = cannonball;
    }


    private void Update()
    {
        if (heldObject == null)
        {
            holdingObject = false;
        }

        //if (enemy = null)
        //{
        //    enemy = GameObject.Find("add_NavMesh");
        //    enemyScript = enemy.GetComponent<AIControllerNavMesh>();

        //}
        //else if (enemy!=null)
        //{
        //    enemyScript.Player = player;

        //}

        //if (heldObject!=null)
        //{
        //    addScript.Player = this.gameObject;
        //}


        if (Input.GetKeyDown("joystick " + charID + " button 4"))
        {
            //if player is not holding an object already, but they detect something that can be picked up
            if (!holdingObject && triggerObject != null)
            {
                PickUpCannonball();
            }
            else
            {
                heldObject.GetComponentInChildren<Light>().enabled = true;
                GameObject.Find("cannon").GetComponentInChildren<Light>().enabled = false;
                DropCannonball();


            }

        }

        //cannonball follows player if player is holding the ball
        if (holdingObject)
        {
            heldObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y+.5f, gameObject.transform.position.z);
            //heldObject.GetComponentInChildren<Light>().enabled = false;

            GameObject.Find("cannon").GetComponentInChildren<Light>().enabled = true;
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

            if (heldObject == null)
            {
                pickUpButton = triggerObject.transform.GetChild(1).gameObject;
                pickUpButton.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "PickUp")
        {
            triggerObject = null;
            pickUpButton.SetActive(false);
        }
    }

    public void DropCannonball()
    {
        if (heldObject != null)
        {
            heldObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - .25f, gameObject.transform.position.z);

            heldObject = null;
            holdingObject = false;
            SendMessage("CannonballDrop");
        }
        else
        {

        }

    }

    public void PickUpCannonball()
    {

        minionSpawner.SetActive(true);
        heldObject = triggerObject;
        holdingObject = true;
        enemyScript.Player = parentPlayer;

        SendMessage("SetDestination");
        SendMessage("CannonballHeld");

    }

}