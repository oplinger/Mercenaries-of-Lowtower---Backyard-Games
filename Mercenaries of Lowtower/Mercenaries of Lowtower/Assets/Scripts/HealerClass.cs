using System.Collections;
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
    [Range(0, 100)]
    public float healAmount;
    public float orbSpeed;
    [Header("Teleport Settings")]
    [Range(0, 10)]
    public float teleportDistance;
    [Header ("Stun Range")]
    [Range(0,10)]
    public float stunRange;
    [Header("Stun Duration")]
    [Range(0, 10)]
    public float stunDuration;

    [Header("Non-Ability Settings")]

    public PickUpBox cannonballHolder;

    public GameObject healerModel;

    Renderer healerRenderer;

    float h1;
    float h2;

    // Use this for initialization

    void Start()
    {
        abilities = GetComponent<HealerAbilities>();
        abilityCooldowns = GetComponent<HealerCooldowns>();
        CTRLID = 3;
        //DOWNCASTING EXAMPLE
        //MeleeClass mC = new MeleeAbilities();
        //MeleeAbilities mA;
        //mA = (MeleeAbilities)mC;

        //jumpheight = 5;


        ability2 = abilities.HealerStun;
        ability1 = Jump;
        //ability2 = abilities.Healaport;
        ability3 = abilities.TargetedHeal;
        currentHealth = maxHealth;

        anim = GetComponent<Animator>();

        healerRenderer = healerModel.GetComponent<Renderer>();
        h2 = currentHealth;

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
        if (Input.GetKeyUp("joystick " + CTRLID + " button " + buttons["Xbutton"]))
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
        if (currentHealth>maxHealth)
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
            walkspeed = 5;

            //drops cannonball if player dies while holding it
            if (currentHealth <= 0)
            {
                cannonballHolder.DropCannonball();
            }
        }
        else if (!cannonballHolder.holdingObject && currentHealth > 0)

        {
            EnableAbilities();
            walkspeed = 10;
        }


        //makes object flash red when it takes damage
        h1 = currentHealth;

        if (h1 < h2)
        {
            healerRenderer.material.SetColor("_EmissionColor", Color.red);

            h2 = h1;

        }
        else
        {
            healerRenderer.material.SetColor("_EmissionColor", Color.black);
        }
    }

    public new void Death()
    {
        anim.SetInteger("AnimState", 4);
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
        ability2 = abilities.HealerStun;
        ability3 = abilities.TargetedHeal;
    }
}
