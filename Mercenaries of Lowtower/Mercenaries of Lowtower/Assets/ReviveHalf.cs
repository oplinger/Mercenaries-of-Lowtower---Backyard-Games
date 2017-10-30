using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviveHalf : MonoBehaviour
{

    bool nearFallen;        //true if player is near a fallen teammate
    //public MeleeController meleeTeammateScript;
    //public RangedController rangedTeammateScript;

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }

    void ReviveHalfHealth()
    {

    }

    private void OnTriggerStay(Collider other)                     //players should have some kind of proximity trigger to see whether teammates are nearby
    {
        //this is probably pretty stressful and should be improved

        Health teammateHealth = other.gameObject.GetComponent<Health>();

        if (teammateHealth.isDead == true && Input.GetButton("Revive"))
        {

            teammateHealth.health = 50;
            teammateHealth.isDead = false;
        }

        nearFallen = true;
    }


    private void OnTriggerExit(Collider other)
    {
        nearFallen = false;
    }
}

