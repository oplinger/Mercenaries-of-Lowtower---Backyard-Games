﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltKnockback : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            other.GetComponent<Rigidbody>().AddForce((other.transform.position - gameObject.transform.position)*50, ForceMode.Impulse);
            Destroy(gameObject);
        }
    }
}
