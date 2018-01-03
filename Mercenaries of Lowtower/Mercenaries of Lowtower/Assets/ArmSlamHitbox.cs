﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmSlamHitbox : MonoBehaviour
{
    public float slamDamage;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Health playerHealth = other.gameObject.GetComponent<Health>();
            playerHealth.health -= slamDamage;
            Debug.Log(slamDamage);
        }

    }
}
