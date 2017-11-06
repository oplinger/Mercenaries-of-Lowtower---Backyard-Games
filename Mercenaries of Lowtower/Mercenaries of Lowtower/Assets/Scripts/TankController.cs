using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    #region Variables
    public GameObject controllerThing;
    public Vector3 playermovement;
    public float walkspeed;
    public ControllerThing controller;
    public int CTRLID;
    public PlayerAbilityController abilities;
    public PlayerCDController cooldowns;
    public LayerMask lMask;
    public Collider[] colliders;
    Animator anim;
    Health health;
    float h1;
    float h2;
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
        anim.SetInteger("AnimState", 0);

        // colliders is for grounding the player, for jumping purposes.
        colliders = Physics.OverlapCapsule(transform.position, transform.position - (Vector3.up * 2), .25f, lMask, QueryTriggerInteraction.Ignore);
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
            }
            else
            {

            }
        }

        if (CTRLID != 0 && Input.GetKeyDown("joystick " + CTRLID + " button 1") && cooldowns.activeCooldowns[0]<=0)
        {
            abilities.TankMagnet(0, gameObject);
            anim.SetInteger("AnimState", 2);
        }
        else
        {
        }

        if (CTRLID != 0 && Input.GetKeyDown("joystick " + CTRLID + " button 2") && cooldowns.activeCooldowns[1] <= 0)
        {
            abilities.TankShield(gameObject);
            anim.SetInteger("AnimState", 2);

        }

        if (CTRLID != 0 && colliders.Length > 0 && Input.GetKeyDown("joystick " + CTRLID + " button 0"))
        {
            abilities.Jump(CTRLID, gameObject);
            anim.SetInteger("AnimState", 3);
        }
        else
        {
        }
        #endregion
        #region Health and Death
        if (h1 < h2)
        {
            anim.SetInteger("AnimState", 4);
            h2 = h1;
        }
        else
        {
        }

        if (h1 <= 0)
        {
            anim.SetInteger("AnimState", 5);
            walkspeed = 0;
        }
        else
        {
        }

        #endregion
    }
}
