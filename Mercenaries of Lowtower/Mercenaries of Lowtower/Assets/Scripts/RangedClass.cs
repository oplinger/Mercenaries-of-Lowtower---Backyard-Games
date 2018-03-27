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
    public GameObject boltspawn;
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

    [Header("Non-Ability Settings")]

    public PickUpBox cannonballHolder;

    public GameObject rangedModel;

    public GameObject yButtonToRevive;

    Renderer rangedRenderer;

    float h1;
    float h2;


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

        rangedRenderer = rangedModel.GetComponent<Renderer>();
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
            Death();
            yButtonToRevive.SetActive(true);
        }
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if (lastFrameHealth < currentHealth)
        {
            EnableAbilities();
            yButtonToRevive.SetActive(false);
        }
        lastFrameHealth = currentHealth;

        //disables abilities if player is holding cannonball, re-enables them if they aren't holding it
        if (cannonballHolder.holdingObject)
        {
            DisableAbilities();
            walkspeed = 5;

            //drops cannonball if player dies while holding it
            if(currentHealth<=0)
            {
                cannonballHolder.DropCannonball();
            }
        }
        else if (!cannonballHolder.holdingObject && currentHealth>0)

        {
            EnableAbilities();
            walkspeed = 10;
        }

        //makes object flash red when it takes damage
        h1 = currentHealth;

        if (h1 < h2)
        {
            StartCoroutine(PumpColour(flashColour, flashTime));

            h2 = h1;

        }
        //else
        //{
        //    rangedRenderer.material.SetColor("_EmissionColor", Color.black);
        //}
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
        ability2 = abilities.BluntTipArrow;
        ability3 = abilities.RangedBolt;
    }

    private IEnumerator PumpColour(Color target, float time)
    {
        float timer = 0;
        while (timer < time)
        {
            timer += Time.deltaTime;
            rangedRenderer.material.SetColor("_Colour", Color.Lerp(Color.white, target, Mathf.Pow((timer / time), 2)));
            yield return null;
        }

        timer = 0;
        while (timer < time)
        {
            timer += Time.deltaTime;
            rangedRenderer.material.SetColor("_Colour", Color.Lerp(target, Color.white, timer / time));
            yield return null;
        }
    }
}
