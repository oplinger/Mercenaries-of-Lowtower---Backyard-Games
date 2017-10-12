using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviveHalf : MonoBehaviour {

    bool nearFallen;        //true if player is near a fallen teammate
    public MovementRigidbody teammateScript;

    // Use this for initialization
    void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ReviveHalfHealth()
    {

    }

    private void OnTriggerStay(Collider other)                     //players should have some kind of proximity trigger to see whether teammates are nearby
    {
        //this is probably pretty stressful and should be improved
        if (other.tag=="Player")
            {

            teammateScript = other.gameObject.GetComponent<MovementRigidbody>();

            if (teammateScript.isDead==true && Input.GetButton("Revive"))
            {
                Health teammateHealth = other.gameObject.GetComponent<Health>();

                teammateHealth.health = 50;
                teammateScript.isDead = false;
            }


            nearFallen = true;
        }

        
    }

    private void OnTriggerExit(Collider other)
    {
        nearFallen = false;
    }
}
