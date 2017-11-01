using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedController : MonoBehaviour
{
    #region Variables
    public GameObject controllerThing;
    public Vector3 playermovement;
    public float walkspeed;
    public ControllerThing controller;
    public int CTRLID;
    public PlayerAbilityController abilities;
    public PlayerCDController cooldowns;
    public bool visual;

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
        controllerThing = GameObject.Find("Controller Thing");

        controller = controllerThing.GetComponent<ControllerThing>();
        abilities = controllerThing.GetComponent<PlayerAbilityController>();
        cooldowns = controllerThing.GetComponent<PlayerCDController>();
        LineOfFireVisual line = GetComponent<LineOfFireVisual>();
        health = GetComponent<Health>();
        anim = GetComponent<Animator>();
        h2 = health.health;
    }

    // Update is called once per frame
    void Update()
    {
        // colliders is for grounding the player, for jumping purposes.

        colliders = Physics.OverlapCapsule(transform.position, transform.position-(Vector3.up*2), .25f, lMask, QueryTriggerInteraction.Ignore);
        h1 = health.health;
        #region Controls
        if (walkspeed >= 0 && CTRLID != 0)
        {
            playermovement = new Vector3(Input.GetAxis("J" + CTRLID + "Horizontal"), 0, Input.GetAxis("J" + CTRLID + "Vertical"));
            if (playermovement != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(playermovement);
                transform.Translate(playermovement * walkspeed * Time.deltaTime, Space.World);
                anim.SetInteger("Idle", 0);
                anim.SetInteger("Walk", 1);

            }
            else
            {
                anim.SetInteger("Idle", 1);
                anim.SetInteger("Walk", 0);


            }
        }
        

        if (CTRLID != 0 && colliders.Length>0 && Input.GetKeyDown("joystick " + CTRLID + " button 0"))
        {

            abilities.Jump(CTRLID, gameObject);
            anim.SetInteger("Jump", 1);



        }
        else
        {
            anim.SetInteger("Jump", 0);

        


    }

        if (CTRLID != 0 && Input.GetKeyDown("joystick " + CTRLID + " button 1") && cooldowns.activeCooldowns[10] <= 0)
        {

            abilities.RangedRopeBolt(3, gameObject);
            anim.SetInteger("Attack", 1);


        }
        else
        {
            anim.SetInteger("Attack", 0);

        }
        if (CTRLID != 0 && Input.GetKey("joystick " + CTRLID + " button 2"))
        {



        }

        if (CTRLID != 0 && Input.GetKeyDown("joystick " + CTRLID + " button 2") && cooldowns.activeCooldowns[9] <= 0)
        {
            visual = true;
            GetComponent<LineOfFireVisual>().OnBool(visual);

        }

        if (CTRLID != 0 && Input.GetKeyUp("joystick " + CTRLID + " button 2") && cooldowns.activeCooldowns[9] <= 0)
        {

            visual = false;
            GetComponent<LineOfFireVisual>().OnBool(visual);

            abilities.RangedBolt(3, gameObject);
            anim.SetInteger("Attack", 1);


        }
        else
        {
            anim.SetInteger("Attack", 0);

        }
        #endregion
        #region Health and Death
        if (h1 < h2)
        {
            anim.SetInteger("GetHurt", 1);
            h2 = h1;

        }
        else
        {
            anim.SetInteger("GetHurt", 0);

        }

        if (h1 <= 0)
        {
            anim.SetInteger("Death", 1);
            walkspeed = 0;

        }
        else
        {
            anim.SetInteger("Death", 0);

        }

        #endregion
    }
}