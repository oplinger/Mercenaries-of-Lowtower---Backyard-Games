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
    public LayerMask lungeMask;
    public GameObject rayOrigin;
    [Header("Melee Settings")]
    [Range(0, 10)]
    public float meleeDamage;
    [Header("Lunge Settings")]
    [Range(0, 10)]
    public float lungeDamage;
    [Range(0, 20)]
    public float lungeDistance;

    [Header("Non-Ability Settings")]

    public PickUpBox cannonballHolder;

    public GameObject meleeModel;

    public GameObject yButtonToRevive;

    public GameObject healingParticles;

    Renderer meleeRenderer;

    float h1;
    float h2;

    public AudioSource meleeAudioSource;

    public AudioClip healing;

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

        meleeRenderer = meleeModel.GetComponent<Renderer>();
        h2 = currentHealth;

        meleeAudioSource = GetComponent<AudioSource>();

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
            StartCoroutine(PumpColour(flashColour, flashTime));

            h2 = h1;

        }

        //healing particles
        if (h1>h2)
        {
            StartCoroutine(ShowHealParticles());
            meleeAudioSource.PlayOneShot(healing);

            h2 = h1;
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

       // print("abilities disabled");
        ability1 = EmptyAbility;
        ability2 = EmptyAbility;
        ability3 = EmptyAbility;
    }

    public void EnableAbilities()
    {
        ability1 = Jump;
        ability3 = abilities.MeleeStrikeRogue;
        ability2 = abilities.MeleeLunge;
    }

    private IEnumerator PumpColour(Color target, float time)
    {
        float timer = 0;
        while (timer < time)
        {
            timer += Time.deltaTime;
            meleeRenderer.material.SetColor("_Colour", Color.Lerp(Color.white, target, Mathf.Pow((timer / time), 2)));
            yield return null;
        }

        timer = 0;
        while (timer < time)
        {
            timer += Time.deltaTime;
            meleeRenderer.material.SetColor("_Colour", Color.Lerp(target, Color.white, timer / time));
            yield return null;
        }
    }

    private IEnumerator ShowHealParticles()
    {
        healingParticles.SetActive(true);

        yield return new WaitForSeconds(1);

        healingParticles.SetActive(false);

    }
}
