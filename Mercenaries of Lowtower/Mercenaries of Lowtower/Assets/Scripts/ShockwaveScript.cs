﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockwaveScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Health>().health -= 10;
        other.GetComponent<Rigidbody>().AddForce((other.transform.position - transform.position) * 100);
    }

    void Shockwave(float speed, float range, Vector3 position)
    {

    }
}
