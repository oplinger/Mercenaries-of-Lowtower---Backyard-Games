using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(TankAbilities))]
[RequireComponent(typeof(TankCooldowns))]

public class TankClass : PlayerClass
{
    

    public TankAbilities abilities;
    public TankCooldowns abilityCooldowns;

    [SerializeField]
    int grounded;

    public LayerMask enemyMask;
    public LayerMask lMask;
    public LayerMask shieldMask;
    [Header("Shield Settings")]
    [Range(0, 10)]
    public float shieldSize;
    public float shieldDuration;
    [Header("Magnet Settings")]
    public float magnetDistance;
    public float magnetDiameter;
    public float pullSpeed;
    
    [Header("Non-Ability Settings")]

    public PickUpBox cannonballHolder;

    public GameObject tankModel;

    Renderer tankRenderer;

    float h1;
    float h2;


    // Use this for initialization
    void Start()
    {


        abilities = GetComponent<TankAbilities>();
        abilityCooldowns = GetComponent<TankCooldowns>();
        //Hashtable tButtons = new Hashtable(buttons);
        //buttons.Add("Abutton", 0);

        //jumpheight = 10;
        ability1 = Jump;
        ability2 = abilities.TankMagnet;
        ability3 = abilities.TankShield;
        CTRLID = 1;
        currentHealth = maxHealth;

        shielded = false;

        anim = GetComponent<Animator>();

        tankRenderer = tankModel.GetComponent<Renderer>();
        h2 = currentHealth;

    }

    // Update is called once per frame
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
            print(("joystick " + CTRLID + " button " + buttons["Bbutton"]));
        }
        if (Input.GetKey("joystick " + CTRLID + " button " + buttons["Xbutton"]))
        {
            buttonX();
        }
        if (Input.GetKeyDown("joystick " + CTRLID + " button " + buttons["Ybutton"]))
        {
            buttonY();
        }

        if (abilityCooldowns.cooldowns["magnetCD"] <= 0)
        {
            if (Input.GetKeyUp("joystick " + CTRLID + " button " + buttons["Bbutton"]))
            {
                print("magnet cooldown");
                abilityCooldowns.cooldowns["magnetCD"] = abilityCooldowns.magnetCD;

            }
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

        //restores abilities if players are revived
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
            tankRenderer.material.SetColor("_EmissionColor", Color.red);

            h2 = h1;

        }
        else
        {
            tankRenderer.material.SetColor("_EmissionColor", Color.black);
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
        ability2 = abilities.TankMagnet;
        ability3 = abilities.TankShield;
    }

}
