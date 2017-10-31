﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedController : MonoBehaviour
{
    #region Variables
    public GameObject controllerThing;
    public Vector3 playermovement;
    public float walkspeed;
    public ControllerThing controller;
    public int CTRLID;
    public PlayerAbilityController abilities;
    public PlayerCDController cooldowns;
    public bool visual;

    public LayerMask lMask;
    public Collider[] colliders;

    Health health;
    #endregion
    // Use this for initialization
    void Start()
    {
        controllerThing = GameObject.Find("Controller Thing");

        controller = controllerThing.GetComponent<ControllerThing>();
        abilities = controllerThing.GetComponent<PlayerAbilityController>();
        cooldowns = controllerThing.GetComponent<PlayerCDController>();
        LineOfFireVisual line = GetComponent<LineOfFireVisual>();
        health = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        // colliders is for grounding the player, for jumping purposes.

        colliders = Physics.OverlapCapsule(transform.position, transform.position-(Vector3.up*2), .25f, lMask, QueryTriggerInteraction.Ignore);
        #region Controls
        if (walkspeed >= 0 && CTRLID != 0)
        {
            playermovement = new Vector3(Input.GetAxis("J" + CTRLID + "Horizontal"), 0, Input.GetAxis("J" + CTRLID + "Vertical"));
            if (playermovement != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(playermovement);
                transform.Translate(playermovement * walkspeed * Time.deltaTime, Space.World);
            }
        }

        if (CTRLID != 0 && colliders.Length>0 && Input.GetKeyDown("joystick " + CTRLID + " button 0"))
        {

            print("something happened");
            abilities.Jump(CTRLID, gameObject);


        }

        if (CTRLID != 0 && Input.GetKeyDown("joystick " + CTRLID + " button 1"))
        {

            abilities.RangedRopeBolt(3, gameObject);

        }
        if (CTRLID != 0 && Input.GetKey("joystick " + CTRLID + " button 2"))
        {



        }

        if (CTRLID != 0 && Input.GetKeyDown("joystick " + CTRLID + " button 2"))
        {
            visual = true;
            GetComponent<LineOfFireVisual>().OnBool(visual);

        }

        if (CTRLID != 0 && Input.GetKeyUp("joystick " + CTRLID + " button 2"))
        {

            visual = false;
            GetComponent<LineOfFireVisual>().OnBool(visual);

            abilities.RangedBolt(3, gameObject);

        }
        #endregion
        #region Health and Death
        if (health.isDead)
        {
            playermovement = new Vector3(0, 0, 0);
        }

#endregion
    }
}