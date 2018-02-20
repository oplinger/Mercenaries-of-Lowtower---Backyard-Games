﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FireCannon : MonoBehaviour {

    public GameObject cannonball;
    public GameObject cannonballProp;
    public GameObject bossManager;
    public Transform cannonballSpawner;

    //Reference to the phase-changing script
    //public PhaseControllerScript phaseScript;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


    }

    private void OnTriggerEnter(Collider other)

    {

        if (other.tag == "PickUp")
        {

            //phaseScript.cannonFired = true;
            bossManager.GetComponent<BossControlScript>().cannonFired = true;
            Destroy(other.gameObject);
            Instantiate(cannonball, cannonballSpawner.position, transform.rotation);
            Instantiate(cannonballProp, new Vector3(transform.position.x, transform.position.y+3, transform.position.z), transform.rotation);



            //GameObject firedBall = Instantiate(cannonball, transform.position, transform.rotation);
            //Rigidbody rb = firedBall.GetComponent<Rigidbody>();
            //rb.AddForce(transform.forward * 2);

            //other.transform.position = this.gameObject.transform.position;
            //Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            //rb.AddForce(transform.forward * 2);
        }
    }
}
