using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MeleeAbilities))]
[RequireComponent(typeof(MeleeCooldowns))]






public class RangedClass : PlayerClass
{
    //public GameObject smoke;
    public RangedAbilities abilities;
    public RangedCooldowns abilityCooldowns;

    [SerializeField]
    int grounded;
    public LayerMask enemyMask;
    [Header("Bolt Settings")]
    [Range(0, 10)]
    public float boltDamage;
    public float boltRange;
    [Header("Knockback Settings")]
    [Range(0, 10)]
    public float lungeDamage;
    [Range(0, 20)]
    public float knockbackRange;
    [Range(0, 10)]
    public float spread;
    // Use this for initialization

    void Start()
    {
        abilities = GetComponent<RangedAbilities>();
        abilityCooldowns = GetComponent<RangedCooldowns>();
        CTRLID = 2;

        //DOWNCASTING EXAMPLE
        //MeleeClass mC = new MeleeAbilities();
        //MeleeAbilities mA;
        //mA = (MeleeAbilities)mC;

        jumpheight = 5;

        ability1 = Jump;
        ability2 = abilities.RangedBolt;
        ability3 = abilities.BluntTipArrow;
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
