﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(TankAbilities))]
[RequireComponent(typeof(TankCooldowns))]

public class TankClass : PlayerClass
{
    

    public TankAbilities abilities;
    public TankCooldowns abilityCooldowns;
    public GameObject tankArm;

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

    public GameObject yButtonToRevive;

    public GameObject healingParticles;

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
        }
        if (Input.GetKey("joystick " + CTRLID + " button " + buttons["Xbutton"]))
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

        //restores abilities if players are revived
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
        if (h1 > h2)
        {
            StartCoroutine(ShowHealParticles());

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

    private IEnumerator PumpColour(Color target, float time)
    {
        float timer = 0;
        while (timer < time)
        {
            timer += Time.deltaTime;
            tankRenderer.material.SetColor("_Colour", Color.Lerp(Color.white, target, Mathf.Pow((timer / time), 2)));
            yield return null;
        }

        timer = 0;
        while (timer < time)
        {
            timer += Time.deltaTime;
            tankRenderer.material.SetColor("_Colour", Color.Lerp(target, Color.white, timer / time));
            yield return null;
        }
    }

    private IEnumerator ShowHealParticles()
    {
        healingParticles.SetActive(true);

        yield return new WaitForSeconds(1);

        healingParticles.SetActive(false);

    }

    public void WhichGrab()
    {
        if (tankArm.GetComponent<TankArm>().target != null)
        {
            if (tankArm.GetComponent<TankArm>().target.tag == "Tentacle")
            {
                anim.SetInteger("AnimState", 7);

            }
            else if (tankArm.GetComponent<TankArm>().target.tag == "Enemey")
            {
                anim.SetInteger("AnimState", 8);
            }
        }
        else
        {
            anim.SetInteger("AnimState", 8);
        }
    }

    public void FreezeTentacle()
    {
        if (tankArm.GetComponent<TankArm>().target.GetComponent<TentacleSlamDamage>() != null)
        {
            print("oihiu");
            tankArm.GetComponent<TankArm>().armJoint[2].transform.position = new Vector3(tankArm.GetComponent<TankArm>().hitPoint.x, tankArm.GetComponent<TankArm>().armJoint[2].transform.position.y, tankArm.GetComponent<TankArm>().hitPoint.z);
            Instantiate(Resources.Load("FrozenWaterArm"), tankArm.GetComponent<TankArm>().hitPoint, Quaternion.Euler(0,0,90));
            tankArm.GetComponent<TankArm>().target.GetComponent<TentacleSlamDamage>().tentacle.GetComponent<BossTentacleScript>().tentacleGrabbed = true;
        }
    }

}
