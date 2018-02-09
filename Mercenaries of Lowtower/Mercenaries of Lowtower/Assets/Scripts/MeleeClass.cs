﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MeleeAbilities))]
[RequireComponent(typeof(MeleeCooldowns))]






public class MeleeClass : PlayerClass
{
    //public GameObject smoke;
     public MeleeAbilities abilities;
     public MeleeCooldowns abilityCooldowns;
    public MeleeTargetList targetList;

    [SerializeField]
    int grounded;
    public LayerMask enemyMask;
    [Header("Melee Settings")]
    [Range(0, 10)]
    public float meleeDamage;
    [Header("Lunge Settings")]
    [Range(0, 10)]
    public float lungeDamage;
    [Range(0, 20)]
    public float lungeDistance;

    public PickUpBox cannonballHolder;

    // Use this for initialization

    void Start()
    {
        abilities = GetComponent<MeleeAbilities>();
        abilityCooldowns = GetComponent<MeleeCooldowns>();
        targetList = GetComponent<MeleeTargetList>();
        CTRLID = 3;

        //DOWNCASTING EXAMPLE
        //MeleeClass mC = new MeleeAbilities();
        //MeleeAbilities mA;
        //mA = (MeleeAbilities)mC;

        //jumpheight = 5;

        ability1 = Jump;
        ability3 = abilities.MeleeStrikeRogue;
        ability2 = abilities.MeleeLunge;
        currentHealth = maxHealth;
        
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        grounded = JumpCheck();

        Movement();
        if (Input.GetKeyDown("joystick " + CTRLID + " button " + buttons["Abutton"]) && grounded > 0)
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


        if (currentHealth <= 0)
        {
            print(currentHealth);
            Death();
        }
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if (lastFrameHealth < currentHealth)
        {
            EnableAbilities();
        }
        lastFrameHealth = currentHealth;

        //disables abilities if player is holding cannonball, re-enables them if they aren't holding it
        if (cannonballHolder.holdingObject)
        {
            DisableAbilities();
        }
        else if (!cannonballHolder.holdingObject)

        {
            EnableAbilities();
        }
    }

    public new void Death()
    {
        anim.SetInteger("AnimState", 5);
        walkspeed = 0;
        walkspeed *= 0;
        DisableAbilities();

    }

    public void DisableAbilities()
    {
        ability1 = null;
        ability2 = null;
        ability3 = null;
    }

    public void EnableAbilities()
    {
        ability1 = Jump;
        ability3 = abilities.MeleeStrikeRogue;
        ability2 = abilities.MeleeLunge;
    }
}
