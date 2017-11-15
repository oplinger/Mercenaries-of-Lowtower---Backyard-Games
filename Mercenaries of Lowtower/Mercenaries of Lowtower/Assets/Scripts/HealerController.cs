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
    Health health;
    float h1;
    float h2;
    Animator anim;
    bool altBuild;

    [Header("Genral")]
    [Range(1, 50)]
    public float walkspeed;
    public LayerMask groundMask;
    public LayerMask enemyMask;
    public Material healerMat;


    [Space(10)]
    [Header("Damage")]
    public float absorbDamage;
    public float healAmount;


    [Space(10)]
    [Header("Cooldowns")]
    [Range(0, 10)]
    public float absorbCooldown;
    [Range(0, 10)]
    public float fearCooldown;
    [Range(0, 10)]
    public float teleportCooldown;
    [Range(0, 10)]
    public float healCooldown;
    [Range(0, 10)]
    public float healInterval;
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
            healerMat.color = Color.HSVToRGB(.75f, .396f, .5f);
            

        } else
        {
            healerMat.color = Color.HSVToRGB(.75f, .396f, .95f);

        }
        anim.SetInteger("AnimState", 0);
        // colliders is for grounding the player, for jumping purposes.
        colliders = Physics.OverlapCapsule(transform.position, transform.position - (Vector3.up * 2), .25f, groundMask, QueryTriggerInteraction.Ignore);
        h1 = health.health;
        #region Controls
        if (walkspeed >= 0 && CTRLID != 0)
        {
            playermovement = new Vector3(Input.GetAxis("J" + CTRLID + "Horizontal"), 0, Input.GetAxis("J" + CTRLID + "Vertical"));
            //Vector3 relpos = playermovement - transform.position;
            if (playermovement != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(playermovement);
                transform.Translate(playermovement * walkspeed * Time.deltaTime, Space.World);
                anim.SetInteger("AnimState", 1);
            } else
            {
            }
        }

        if (CTRLID != 0 && colliders.Length > 0 && Input.GetKeyDown("joystick " + CTRLID + " button 0"))
        {
            abilities.Jump(CTRLID, gameObject);
            anim.SetInteger("AnimState", 3);
        }
        else
        {
        }

        //if (CTRLID != 0 && Input.GetKeyDown("joystick " + CTRLID + " button 1") && cooldowns.activeCooldowns[4] <= 0 && altBuild)
        //{
        //    abilities.HealerAbsorb(absorbDamage, 1, gameObject, absorbCooldown);
        //    anim.SetInteger("AnimState", 2);
        //}
        //else
        //{
        //}

        if (CTRLID != 0 && Input.GetKeyDown("joystick " + CTRLID + " button 1") && cooldowns.activeCooldowns[4] <= 0 && altBuild)
        {
            abilities.HealerCC(0, 1, gameObject, fearCooldown);
            anim.SetInteger("AnimState", 2);
        }
        else
        {
        }

        if (/*CTRLID != 0 && Input.GetKey("joystick " + CTRLID + " button 2")*/ Input.GetKey("h") && cooldowns.activeCooldowns[3] <= 0)
        {
            healVisual.SetActive(true);
            timer += Time.deltaTime;
            if (timer >= healInterval)
            {
                abilities.HealerHeal(-healAmount, 1, gameObject, healCooldown, healVisual);
                timer = 0;
            }
            anim.SetInteger("AnimState", 2);

        }
        else
        {
            healVisual.SetActive(false);
        }

        if (CTRLID != 0 && Input.GetKey("joystick " + CTRLID + " button 1") && cooldowns.activeCooldowns[4] <= 0 && !altBuild)
        {
            abilities.Healaport(0, 1, gameObject, teleportCooldown);
        }


        if (CTRLID != 0 && Input.GetKeyDown("joystick " + CTRLID + " button 5"))
        {
            altBuild = !altBuild;
        }

        #endregion
        #region Health and Death
        if (h1 < h2)
        {
            anim.SetInteger("AnimState", 4);
            h2 = h1;
        } else
        {
        }

        if (h1 <= 0)
        {
            anim.SetInteger("AnimState", 5);
            walkspeed = 0;
        } else
        {
        }
        #endregion
    }
}
