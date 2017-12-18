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
        //Hashtable tButtons = new Hashtable(buttons);
        //buttons.Add("Abutton", 0);
        jumpheight = 10;
        ability1 = Jump;
        ability2 = shield;

    }

    // Update is called once per frame
    void Update () {
        grounded = JumpCheck();

        Movement();

        if (Input.GetKeyDown("joystick " + CTRLID + " button " + buttons["Abutton"]))
        {
            buttonA();
            
        }
        if (Input.GetKeyDown("joystick " + CTRLID + " button " + buttons["Bbutton"]))
        {
            buttonB();
        }
        if (Input.GetKeyDown("joystick " + CTRLID + " button " + buttons["Xbutton"]))
        {
            buttonX();
        }
        if (Input.GetKeyDown("joystick " + CTRLID + " button " + buttons["Ybutton"]))
        {
            buttonY();
        }


    }

    void shield()
    {
        print("TankAbility1");

        Instantiate(Resources.Load("shield"));
    }
}
