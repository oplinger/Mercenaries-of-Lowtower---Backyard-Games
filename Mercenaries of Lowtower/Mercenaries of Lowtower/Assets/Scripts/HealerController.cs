using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealerController : MonoBehaviour
{
    #region Variables
    [HideInInspector]
    public int CTRLID;
    
    GameObject controllerThing;
    Vector3 playermovement;
    ControllerThing controller;
    GameObject healVisual;
    PlayerAbilityController abilities;
    PlayerCDController cooldowns;
    Collider[] colliders;
    float timer;
    float timer1;
    float timer2;
    [SerializeField]
    GameObject healObject;
    Health health;
    float h1;
    float h2;
    Animator anim;
    bool stop;
    float stopTimer;

    [Header("Genral")]
    public bool altBuild;

    [Range(1, 50)]
    public float walkspeed;
    [Range(0, 50)]
    public float jumpHeight;
    public LayerMask groundMask;
    public LayerMask enemyMask;
    public Material healerMat;
    public float reviveRadius;
    public float reviveCastTime;

   // public float absorbDamage;
    //[Range(0, 10)]
   // public float absorbCooldown;

    [Header("Heal Settings")]
    public float healAmount;
    [Range(0, 10)]
    public float healCooldown;
    [Range(0, 10)]
    public float healInterval;
    [Range(0, 100)]
    public float healRange;

    public float orbCooldown;
    public float orbSpeed;
    [Header("Teleport Settings")]
    [Range(0, 10)]
    public float teleportCooldown;
    [Range(0, 50)]
    public float teleportRange;
    [Range(0, 10)]
    public float teleportDelay;
    [Header("Fear Settings")]
    [Range(0, 10)]
    public float fearCooldown;
    [Range(0, 50)]
    public float fearRange;
    [Range(0, 10)]
    public float fearRunSpeed;
    [Range(0, 10)]
    public float fearDuration;

    //get the cannonball holder object
    public PickUpBox ballHolderScript;

    #endregion


    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
        healVisual = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        healVisual.SetActive(false);
        DontDestroyOnLoad(healVisual);

        healVisual.GetComponent<Renderer>().material.color = Color.green;
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
            healerMat.color = Color.HSVToRGB(.2f, .89f, .5f);
            

        } else
        {
            healerMat.color = Color.HSVToRGB(.2f, .89f, .95f);

        }

        if (!altBuild && CTRLID != 0 && Input.GetKey("joystick " + CTRLID + " button 2"))
        {

            if (Input.GetAxis("J" + CTRLID + "Horizontal") > -1 && Input.GetAxis("J" + CTRLID + "Horizontal") < 0)
            {
                if (Input.GetAxis("J" + CTRLID + "Vertical") > 0 && Input.GetAxis("J" + CTRLID + "Vertical") < 1)
                {
                    healObject = controller.IDs[0].gameObject;
                    // transform.rotation = Quaternion.LookRotation(controller.IDs[0].gameObject.transform.position);
                    transform.LookAt(controller.IDs[0].gameObject.transform);

                    print(healObject);
                }

            }
            if (Input.GetAxis("J" + CTRLID + "Horizontal") > 0 && Input.GetAxis("J" + CTRLID + "Horizontal") < 1)
            {
                if (Input.GetAxis("J" + CTRLID + "Vertical") > 0 && Input.GetAxis("J" + CTRLID + "Vertical") < 1)
                {
                    healObject = controller.IDs[1].gameObject;
                    //transform.rotation = Quaternion.LookRotation(controller.IDs[1].gameObject.transform.position);
                    transform.LookAt(controller.IDs[1].gameObject.transform);


                    print(healObject);
                }

            }
            if (Input.GetAxis("J" + CTRLID + "Horizontal") > -1 && Input.GetAxis("J" + CTRLID + "Horizontal") < 0)
            {
                if (Input.GetAxis("J" + CTRLID + "Vertical") < 0 && Input.GetAxis("J" + CTRLID + "Vertical") > -1)
                {
                    healObject = controller.IDs[2].gameObject;
                    //transform.rotation = Quaternion.LookRotation(controller.IDs[2].gameObject.transform.position);
                    transform.LookAt(controller.IDs[2].gameObject.transform);


                    print(healObject);
                }

            }
            if (Input.GetAxis("J" + CTRLID + "Horizontal") > 0 && Input.GetAxis("J" + CTRLID + "Horizontal") < 1)
            {
                if (Input.GetAxis("J" + CTRLID + "Vertical") < 0 && Input.GetAxis("J" + CTRLID + "Vertical") > -1)
                {
                    healObject = controller.IDs[3].gameObject;
                    //transform.rotation = Quaternion.LookRotation(controller.IDs[3].gameObject.transform.position);
                    transform.LookAt(controller.IDs[3].gameObject.transform);


                    print(healObject);
                }

            }

        }
        if(CTRLID != 0 && Input.GetKeyUp("joystick " + CTRLID + " button 2") && cooldowns.activeCooldowns[3] <= 0 && !health.isDead && !altBuild && !ballHolderScript.holdingObject)
        {
            abilities.TargetedHeal(20, 1, gameObject, orbCooldown, healObject, orbSpeed);
            stopTimer = 0;
        }

        anim.SetInteger("AnimState", 0);
        // colliders is for grounding the player, for jumping purposes.
        colliders = Physics.OverlapCapsule(transform.position, transform.position - (Vector3.up * .01f), .25f, groundMask, QueryTriggerInteraction.Ignore);
        h1 = health.health;
        #region Controls
        if (walkspeed >= 0 && CTRLID != 0 && !health.isDead)
        {
            playermovement = new Vector3(Input.GetAxis("J" + CTRLID + "Horizontal"), 0, Input.GetAxis("J" + CTRLID + "Vertical"));
            //Vector3 relpos = playermovement - transform.position;
            if (playermovement != Vector3.zero)
            {
                if (Input.GetKey("joystick " + CTRLID + " button 2") && !altBuild)
                {
                    stop = true;
                    if(cooldowns.activeCooldowns[3]>0 && stopTimer==0)
                    stopTimer = .5f;


                }

                if (!stop)
                {
                    transform.rotation = Quaternion.LookRotation(playermovement);
                    walkspeed = 10;
                    transform.Translate(playermovement * walkspeed * Time.deltaTime, Space.World);
                    anim.SetInteger("AnimState", 1);
                }
            } else
            {

            }
        }
        if (CTRLID != 0 && colliders.Length > 0 && Input.GetKeyDown("joystick " + CTRLID + " button 0") && !health.isDead)
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


        //if (CTRLID != 0 && Input.GetKeyDown("joystick " + CTRLID + " button 1") && cooldowns.activeCooldowns[4] <= 0 && altBuild)
        //{
        //    abilities.HealerAbsorb(absorbDamage, 1, gameObject, absorbCooldown);
        //    anim.SetInteger("AnimState", 2);
        //}
        //else
        //{
        //}

        if (CTRLID != 0 && Input.GetKeyDown("joystick " + CTRLID + " button 1") && cooldowns.activeCooldowns[4] <= 0 && altBuild && !health.isDead && !ballHolderScript.holdingObject)
        {
            abilities.HealerCC(0, 1, gameObject, fearCooldown, fearRange, fearRunSpeed, fearDuration);
            anim.SetInteger("AnimState", 2);
        }
        else
        {
        }

        if (CTRLID != 0 && Input.GetKey("joystick " + CTRLID + " button 2") && cooldowns.activeCooldowns[3] <= 0 && !health.isDead && altBuild && !ballHolderScript.holdingObject)
        {
            healVisual.SetActive(true);
            timer += Time.deltaTime;
            if (timer >= healInterval)
            {
                abilities.HealerHeal(-healAmount, 1, gameObject, healCooldown, healVisual, healRange);
                timer = 0;
            }
            anim.SetInteger("AnimState", 2);

        }
        else
        {
            healVisual.SetActive(false);
        }

        if (CTRLID != 0 && Input.GetKey("joystick " + CTRLID + " button 1") && cooldowns.activeCooldowns[4] <= 0 && !altBuild && !health.isDead && !ballHolderScript.holdingObject)
        {
            //teleportDelay += Time.deltaTime;

            timer2 += Time.deltaTime;
            if(timer2>=teleportDelay)
            abilities.Healaport(0, 1, gameObject, teleportCooldown, teleportRange);
        }


        //if (CTRLID != 0 && Input.GetKeyDown("joystick " + CTRLID + " button 5"))
        //{
        //    altBuild = !altBuild;
        //}

        if (stop)
        {
            stopTimer += Time.deltaTime;
            if (stopTimer > .5f)
            {
                stop = false;
                stopTimer = 0;
            }
            transform.rotation = transform.rotation;
            walkspeed = 0;

        } else
        {
            walkspeed = 10;
        }

        #endregion
        #region Health and Death
        if (h1 < h2)
        {
            healerMat.SetColor("_EmissionColor", Color.HSVToRGB(1f, 1, 1));

            anim.SetInteger("AnimState", 4);
            h2 = h1;
        } else
        {
            healerMat.SetColor("_EmissionColor", Color.HSVToRGB(1f, 1, 0));

        }

        if (health.isDead)
        {
            anim.SetInteger("AnimState", 5);
            walkspeed = 0;
            playermovement *= 0;
        } else
        {
            walkspeed = 10;
        }
        #endregion
    }
}
