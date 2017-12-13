using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class TankClass : PlayerClass
{
    [SerializeField]
    int grounded;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        grounded = JumpCheck();

        if (grounded > 0)
        {

            Jump(5);
        }
        else
        {
            Jump(0);
        }
	}
}
