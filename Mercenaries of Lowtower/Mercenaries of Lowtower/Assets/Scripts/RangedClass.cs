using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(RangedAbilities))]
[RequireComponent(typeof(RangedCooldowns))]






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
    public float knockbackDamage;
    [Range(0, 20)]
    public float knockbackRange;
    [Range(0, 10)]
    public float spread;

    public PickUpBox cannonballHolder;


    // Use this for initialization

    void Start()
    {
        abilities = GetComponent<RangedAbilities>();
        abilityCooldowns = GetComponent<RangedCooldowns>();
        CTRLID = 4;

        //DOWNCASTING EXAMPLE
        //MeleeClass mC = new MeleeAbilities();
        //MeleeAbilities mA;
        //mA = (MeleeAbilities)mC;

        //jumpheight = 5;

        ability1 = Jump;
        ability2 = abilities.BluntTipArrow;
        ability3 = abilities.RangedBolt;
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
        if (abilityCooldowns.cooldowns["knockbackCD"] <= 0)
        {
            if (Input.GetKeyDown("joystick " + CTRLID + " button " + buttons["Bbutton"]))
            {
                GetComponent<LineOfFireVisual>().on = true;
            }
            if (Input.GetKeyUp("joystick " + CTRLID + " button " + buttons["Bbutton"]))
            {
                buttonB();

                GetComponent<LineOfFireVisual>().on = false;
            }
        }
        if (abilityCooldowns.cooldowns["boltCD"] <= 0)
        {
            if (Input.GetKey("joystick " + CTRLID + " button " + buttons["Xbutton"]))
            {
                GetComponent<LineOfFireVisual>().on = true;
            }
            if (Input.GetKeyUp("joystick " + CTRLID + " button " + buttons["Xbutton"]))
            {
                buttonX();

                GetComponent<LineOfFireVisual>().on = false;
            }
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
        ability2 = abilities.BluntTipArrow;
        ability3 = abilities.RangedBolt;
    }
}
