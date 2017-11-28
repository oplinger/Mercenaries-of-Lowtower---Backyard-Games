using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    #region Variables
    [HideInInspector]
    public int CTRLID;
     GameObject controllerThing;
     Vector3 playermovement;
     ControllerThing controller;
     PlayerAbilityController abilities;
     PlayerCDController cooldowns;
     Collider[] colliders;
    Animator anim;
    Health health;
    float h1;
    float h2;
    float timer;
    float timer1;
    bool visual;

    float reflectDamage;

    [Header("Genral")]
    public bool altBuild;

    [Range(1, 50)]
    public float walkspeed;
    [Range(0,50)]
    public float jumpHeight;
    public LayerMask groundMask;
    public LayerMask magnetMask;
    public Material tankMat;
    public float reviveRadius;
    public float reviveCastTime;

    [Header("Magnet Settings")]
    [Range(0, 10)]
    public float magnetCooldown;
    [Range(0, 100)]
    public float magnetDistance;
    [Range(0, 10)]
    public float pullSpeed;
    public float magnetThreat;
    [Range(0, 10)]
    public float magnetDiameter;
    
    [Header("Shield Settings")]
    public bool InfiniteShield;
    [Range(0, 10)]
    public float shieldDuration;
    [Range(0, 10)]
    public float shieldCooldown;
    [Range(0, 100)]
    public float shieldHealth;
    [Range(0, 50)]
    public float shieldSize;
    [Header("Perfect Dodge Settings")]
    [Range(0, 10)]
    public float perfectShieldDuration;
    [Range(0, 10)]
    public float perfectShieldCooldown;
    [Range(0, 50)]
    public float dodgeRadius;
    [Header("Reflection Settings")]
    [Range(0, 10)]
    public float reflectCooldown;
    [Range(0,50)]
    public float reflectDistance;
    [Range(0, 2)]
    public float beamWidth;
    [Range(0, 10)]
    public float damageMultiplier;

    #endregion

    // Use this for initialization
    void Start()
    {

        DontDestroyOnLoad(transform.gameObject);

        controllerThing = GameObject.Find("Controller Thing");
        controller = controllerThing.GetComponent<ControllerThing>();
        abilities = controllerThing.GetComponent<PlayerAbilityController>();
        cooldowns = controllerThing.GetComponent<PlayerCDController>();
        health = GetComponent<Health>();
        anim = GetComponent<Animator>();
        h2 = health.health;
    }

    /*
     AnimStates
     0 = idle
     1 = Walk
     2 = Attack
     3= Jump
     4 = GetHurt
     5= Death
         */
    void Update()
    {
        if (altBuild)
        {
            tankMat.color = Color.HSVToRGB(.613f, .537f, .4f);


        }
        else if (!altBuild)
        {
            tankMat.color = Color.HSVToRGB(.613f, .537f, .82f);

        }
        anim.SetInteger("AnimState", 0);

        // colliders is for grounding the player, for jumping purposes.
        colliders = Physics.OverlapCapsule(transform.position, transform.position - (Vector3.up * .1f), .25f, groundMask, QueryTriggerInteraction.Ignore);
        h1 = health.health;
        #region Controls
        if (walkspeed >= 0 && CTRLID != 0 && !health.isDead)
        {
            playermovement = new Vector3(Input.GetAxis("J" + CTRLID + "Horizontal"), 0, Input.GetAxis("J" + CTRLID + "Vertical"));
            //Vector3 relpos = playermovement - transform.position;
            if (playermovement != Vector3.zero)
            {
                if (Input.GetKey("joystick " + CTRLID + " button 1") && cooldowns.activeCooldowns[0] <= 0 && !altBuild)
                {
                    transform.rotation = transform.rotation;
                } else
                {
                    transform.rotation = Quaternion.LookRotation(playermovement);

                }
                transform.Translate(playermovement * walkspeed * Time.deltaTime, Space.World);
                anim.SetInteger("AnimState", 1);
            }
            else
            {

            }
        }

        if (CTRLID != 0 && colliders.Length > 0 && Input.GetKeyDown("joystick " + CTRLID + " button 0"))
        {
            abilities.Jump(CTRLID, gameObject, jumpHeight);
            anim.SetInteger("AnimState", 3);
        }
        else
        {
        }

        if (CTRLID != 0 && Input.GetKey("joystick " + CTRLID + " button 3") && !health.isDead)
        {
            timer1 += Time.deltaTime;
            if (timer1 > reviveCastTime)
            {
                abilities.Revive(1, gameObject, reviveRadius);

            }
        }
        if (CTRLID != 0 && Input.GetKeyUp("joystick " + CTRLID + " button 3") && !health.isDead)
        {
            reviveCastTime = 0;
        }

        if (CTRLID != 0 && Input.GetKey("joystick " + CTRLID + " button 1") && cooldowns.activeCooldowns[0]<=0 && !altBuild && !health.isDead)
        {


                GameObject cap = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                Destroy(cap.GetComponent<CapsuleCollider>());
                cap.transform.position = transform.position + transform.forward * 10;
                cap.transform.rotation = transform.rotation * Quaternion.Euler(90, 0, 0);
                cap.transform.localScale = new Vector3(1, 10, 1);
                cap.transform.parent = transform;
            Destroy(cap, Time.deltaTime+.002f);


            abilities.TankMagnet(magnetThreat, 0, gameObject, magnetCooldown, magnetMask, magnetDistance, pullSpeed, magnetDiameter);
            anim.SetInteger("AnimState", 2);
            tankMat.SetColor("_EmissionColor", Color.HSVToRGB(.7f, 1, 1));

        }
        else
        {
            tankMat.SetColor("_EmissionColor", Color.HSVToRGB(.7f, 1, 0));
            

        }
        if (CTRLID != 0 && Input.GetKeyUp("joystick " + CTRLID + " button 1") && !altBuild && !health.isDead)
        {

            cooldowns.triggerCooldown(0, magnetCooldown);

        }

        if (CTRLID != 0 && Input.GetKeyDown("joystick " + CTRLID + " button 2") && cooldowns.activeCooldowns[1] <= 0 && altBuild && !health.isDead)
        {
            abilities.TankPerfectShield(shieldHealth, 0, gameObject, perfectShieldCooldown, perfectShieldDuration, dodgeRadius);
            anim.SetInteger("AnimState", 2);

        }

        if (CTRLID != 0 && Input.GetKeyDown("joystick " + CTRLID + " button 2") && cooldowns.activeCooldowns[1] <= 0 && !altBuild && !health.isDead)
        {
            abilities.TankShield(shieldHealth, 0, gameObject, shieldCooldown, shieldDuration, InfiniteShield, shieldSize);
            anim.SetInteger("AnimState", 2);

        }



        if (CTRLID != 0 && Input.GetKey("joystick " + CTRLID + " button 1") && cooldowns.activeCooldowns[0] <= 0 && altBuild && !health.isDead)
        {
            //timer += Time.deltaTime;
            //reflectDamage += (h2 - h1) * 2;
            abilities.TankReflect(reflectDamage,0, gameObject, reflectCooldown, true, h1, h2, timer, reflectDistance, beamWidth, damageMultiplier);
            tankMat.SetColor("_EmissionColor", Color.HSVToRGB(.5f,1,1));
            //if (timer > 2)
            //{
            //    timer = 0;
            //    reflectDamage = 0;
            //}
            
        }
        if (CTRLID != 0 && Input.GetKeyUp("joystick " + CTRLID + " button 1") && cooldowns.activeCooldowns[0] <= 0 && altBuild && !health.isDead)
        {
            tankMat.SetColor("_EmissionColor", Color.HSVToRGB(.5f, 1, 0));
            cooldowns.triggerCooldown(0, reflectCooldown);

            //timer = 0;
            //reflectDamage = 0;


        }




        if (CTRLID != 0 && Input.GetKeyDown("joystick " + CTRLID + " button 5"))
        {
            altBuild = !altBuild;
        }
        #endregion
        #region Health and Death
        if (h1 < h2)
        {
            tankMat.SetColor("_EmissionColor", Color.HSVToRGB(1, 1, 1));
            anim.SetInteger("AnimState", 4);
            h2 = h1;
        }
        else if (tankMat.GetColor("_EmissionColor") != Color.HSVToRGB(1, 1, 0) && !Input.GetKey("joystick " + CTRLID + " button 1"))
        {
            tankMat.SetColor("_EmissionColor", Color.HSVToRGB(1, 1, 0));

        }

        if (health.isDead)
        {
            anim.SetInteger("AnimState", 5);
            walkspeed = 0;
            playermovement *= 0;
        }


        #endregion
    }
}
