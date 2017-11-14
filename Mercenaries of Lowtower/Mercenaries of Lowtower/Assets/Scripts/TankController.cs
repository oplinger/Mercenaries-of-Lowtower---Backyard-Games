﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    #region Variables
    [HideInInspector]
    public int CTRLID;
     GameObject controllerThing;
     Vector3 playermovement;
     ControllerThing controller;
     PlayerAbilityController abilities;
     PlayerCDController cooldowns;
     Collider[] colliders;
    Animator anim;
    Health health;
    float h1;
    float h2;
    bool altBuild;

    [Header("Genral")]
    [Range(1, 50)]
    public float walkspeed;
    public LayerMask groundMask;
    public LayerMask enemyMask;
    public Material tankMat;
    public GameObject model;




    [Space(10)]
    [Header("Damage")]
    public float magnetThreat;
    float shieldAmount;


    [Space(10)]
    [Header("Cooldowns")]
    [Range(0, 10)]
    public float magnetCooldown;
    [Range(0, 10)]
    public float shieldCooldown;
    [Range(0, 10)]
    public float perfectShieldCooldown;
    [Range(0, 10)]
    public float reflectCooldown;
    #endregion

    // Use this for initialization
    void Start()
    {

        DontDestroyOnLoad(transform.gameObject);

        controllerThing = GameObject.Find("Controller Thing");
        controller = controllerThing.GetComponent<ControllerThing>();
        abilities = controllerThing.GetComponent<PlayerAbilityController>();
        cooldowns = controllerThing.GetComponent<PlayerCDController>();
        health = GetComponent<Health>();
        anim = GetComponent<Animator>();
        h2 = health.health;
    }

    /*
     AnimStates
     0 = idle
     1 = Walk
     2 = Attack
     3= Jump
     4 = GetHurt
     5= Death
         */
    void Update()
    {
        if (altBuild)
        {
            tankMat.color = Color.HSVToRGB(.613f, .537f, .5f);


        }
        else if (!altBuild)
        {
            tankMat.color = Color.HSVToRGB(.613f, .537f, .95f);

        }
        anim.SetInteger("AnimState", 0);

        // colliders is for grounding the player, for jumping purposes.
        colliders = Physics.OverlapCapsule(transform.position, transform.position - (Vector3.up * 2), .25f, groundMask, QueryTriggerInteraction.Ignore);
        h1 = health.health;
        #region Controls
        if (walkspeed >= 0 && CTRLID != 0)
        {
            playermovement = new Vector3(Input.GetAxis("J" + CTRLID + "Horizontal"), 0, Input.GetAxis("J" + CTRLID + "Vertical"));
            //Vector3 relpos = playermovement - transform.position;
            if (playermovement != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(playermovement);
                transform.Translate(playermovement * walkspeed * Time.deltaTime, Space.World);
                anim.SetInteger("AnimState", 1);
            }
            else
            {

            }
        }

        if (CTRLID != 0 && Input.GetKeyDown("joystick " + CTRLID + " button 1") && cooldowns.activeCooldowns[0]<=0 && !altBuild)
        {
            abilities.TankMagnet(magnetThreat, 0, gameObject, magnetCooldown);
            anim.SetInteger("AnimState", 2);
        }
        else
        {
        }

        if (CTRLID != 0 && Input.GetKeyDown("joystick " + CTRLID + " button 2") && cooldowns.activeCooldowns[1] <= 0 && altBuild)
        {
            abilities.TankPerfectShield(shieldAmount, 0, gameObject, perfectShieldCooldown);
            anim.SetInteger("AnimState", 2);

        }

        if (CTRLID != 0 && Input.GetKeyDown("joystick " + CTRLID + " button 2") && cooldowns.activeCooldowns[1] <= 0 && !altBuild)
        {
            abilities.TankShield(shieldAmount, 0, gameObject, shieldCooldown);
            anim.SetInteger("AnimState", 2);

        }

        if (CTRLID != 0 && colliders.Length > 0 && Input.GetKeyDown("joystick " + CTRLID + " button 0"))
        {
            abilities.Jump(CTRLID, gameObject);
            anim.SetInteger("AnimState", 3);
        }
        else
        {
        }

        if (CTRLID != 0 && Input.GetKey("joystick " + CTRLID + " button 1") && cooldowns.activeCooldowns[0] <= 0 && altBuild)
        {
            abilities.TankReflect(0, 0, gameObject, reflectCooldown, true, h1, h2);
            model.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.cyan);
            
        }
        if (CTRLID != 0 && Input.GetKeyUp("joystick " + CTRLID + " button 1") && cooldowns.activeCooldowns[0] <= 0 && altBuild)
        {
            model.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
            tankMat.color = Color.HSVToRGB(.613f, .537f, .95f);


        }




        if (CTRLID != 0 && Input.GetKeyDown("joystick " + CTRLID + " button 5"))
        {
            altBuild = !altBuild;
        }
        #endregion
        #region Health and Death
        if (h1 < h2)
        {
            anim.SetInteger("AnimState", 4);
            h2 = h1;
        }
        else
        {
        }

        if (h1 <= 0)
        {
            anim.SetInteger("AnimState", 5);
            walkspeed = 0;
        }
        else
        {
        }

        #endregion
    }
}
