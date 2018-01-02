using System.Collections;
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
    [Range(0, 10)]
    public float lungeCD;
    // Use this for initialization

    void Start()
    {
        abilities = GetComponent<MeleeAbilities>();
        abilityCooldowns = GetComponent<MeleeCooldowns>();
        targetList = GetComponent<MeleeTargetList>();
        CTRLID = 1;

        //DOWNCASTING EXAMPLE
        //MeleeClass mC = new MeleeAbilities();
        //MeleeAbilities mA;
        //mA = (MeleeAbilities)mC;

        jumpheight = 5;

        ability1 = Jump;
        ability3 = abilities.MeleeStrikeRogue;
        ability2 = abilities.MeleeLunge;
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
