﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltDamage : MonoBehaviour {
   public Health health;
    public GameObject controller;
	// Use this for initialization
	void Start () {
        controller = GameObject.Find("Controller Thing");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Enemy")
        {
            health = other.GetComponent<Health>();
            ControllerThing CT = controller.GetComponent<ControllerThing>();
            //health.modifyHealth(3, 3);

            //deals 2x damage than it should, so 1.5 wnds up being 3
            health.health -= 1.5f;
            //Destroy(gameObject);
        }
    }
}
