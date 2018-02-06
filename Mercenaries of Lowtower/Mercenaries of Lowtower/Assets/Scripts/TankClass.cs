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
   




    // Use this for initialization
    void Start () {


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

    }

    // Update is called once per frame
    void Update () {
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
    }

    public new void Death()
    {
       anim.SetInteger("AnimState", 5);
        walkspeed = 0;
        walkspeed *= 0;
        ability1 = null;
        ability2 = null;
        ability3 = null;

    }


}
