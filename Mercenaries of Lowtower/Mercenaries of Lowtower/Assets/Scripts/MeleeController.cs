﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeController : MonoBehaviour {
    public GameObject controllerThing;
    public Vector3 playermovement;
    public float walkspeed;
    public ControllerThing controller;
    public int CTRLID;
    public PlayerAbilityController abilities;
    public PlayerCDController cooldowns;
    float timer;


    // Use this for initialization
    void Start()
    {
        controller = controllerThing.GetComponent<ControllerThing>();
        abilities = controllerThing.GetComponent<PlayerAbilityController>();
        cooldowns = controllerThing.GetComponent<PlayerCDController>();
    }

    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
        if (walkspeed>= 0 && CTRLID != 0)
        {
            playermovement = new Vector3(Input.GetAxis("J"+ CTRLID + "Horizontal"), 0, Input.GetAxis("J"+CTRLID+"Vertical"));
            //Vector3 relpos = playermovement - transform.position;
            if (playermovement != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(playermovement);
                transform.Translate(playermovement * walkspeed * Time.deltaTime, Space.World);
            }
        }




        if (CTRLID != 0 && Input.GetKeyDown("joystick " + CTRLID + " button 1"))
        {
            
            
                abilities.MeleeDash(System.Array.IndexOf(controller.targets, "Melee Character"), gameObject);
            

        }
        if (CTRLID != 0 && Input.GetKeyDown("joystick " + CTRLID + " button 2"))
        {

                abilities.MeleeStrike(System.Array.IndexOf(controller.targets, "Melee Character"), gameObject);
            

        }

    }
}
