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
        ability1 = shield;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("joystick " + CTRLID + " button 0"))
        {
            buttonAfunction();
        }
        if (Input.GetKeyDown("joystick " + CTRLID + " button 1"))
        {
            buttonBfunction();
        }
        if (Input.GetKeyDown("joystick " + CTRLID + " button 2"))
        {
            buttonXfunction();
        }
        if (Input.GetKeyDown("joystick " + CTRLID + " button 3"))
        {
            buttonYfunction();
        }
        //grounded = JumpCheck();

        //if (grounded > 0)
        //{

        //    Jump(5);
        //}
        //else
        //{
        //    Jump(0);
        //}
    }

    void shield()
    {
        Instantiate(Resources.Load("shield"));
    }
}
