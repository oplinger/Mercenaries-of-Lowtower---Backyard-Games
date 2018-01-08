﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(HealerAbilities))]
[RequireComponent(typeof(HealerCooldowns))]






public class HealerClass : PlayerClass
{
    //public GameObject smoke;
    public HealerAbilities abilities;
    public HealerCooldowns abilityCooldowns;
    public GameObject healObject;
    public GameObject healTarget;
    public float stopTimer;

    [SerializeField]
    int grounded;
    public LayerMask enemyMask;
    [Header("Heal Settings")]
    [Range(0, 10)]
    public float healAmount;
    public float orbSpeed;
    [Header("Teleport Settings")]
    [Range(0, 10)]
    public float teleportDistance;

    // Use this for initialization

    void Start()
    {
        abilities = GetComponent<HealerAbilities>();
        abilityCooldowns = GetComponent<HealerCooldowns>();
        CTRLID = 2;

        //DOWNCASTING EXAMPLE
        //MeleeClass mC = new MeleeAbilities();
        //MeleeAbilities mA;
        //mA = (MeleeAbilities)mC;

        jumpheight = 5;

        ability1 = Jump;
        ability2 = abilities.TargetedHeal;
        ability3 = abilities.Healaport;
    }

    void Update()
    {
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


}
