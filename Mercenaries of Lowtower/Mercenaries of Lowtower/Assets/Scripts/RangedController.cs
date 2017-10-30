using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedController : MonoBehaviour
{
    public GameObject controllerThing;
    public Rigidbody playerbody;
    public float jumpForce;
    public Vector3 playermovement;
    public float walkspeed;
    public ControllerThing controller;
    public int CTRLID;
    public PlayerAbilityController abilities;
    public PlayerCDController cooldowns;
    public bool visual;

    public LayerMask lMask;
    public Collider[] colliders;

    Health health;

  


    // Use this for initialization
    void Start()
    {
        controller = controllerThing.GetComponent<ControllerThing>();
        abilities = controllerThing.GetComponent<PlayerAbilityController>();
        cooldowns = controllerThing.GetComponent<PlayerCDController>();
        LineOfFireVisual line = GetComponent<LineOfFireVisual>();
        playerbody = GetComponent<Rigidbody>();

        health = GetComponent<Health>();
        //line.DrawLine(GameObject.Find("Ranged Character"));

    }

    // Update is called once per frame
    void Update()
    {
        colliders = Physics.OverlapCapsule(transform.position, transform.position-(Vector3.up*2), .25f, lMask, QueryTriggerInteraction.Ignore);

        if (walkspeed >= 0 && CTRLID != 0)
        {
            playermovement = new Vector3(Input.GetAxis("J" + CTRLID + "Horizontal"), 0, Input.GetAxis("J" + CTRLID + "Vertical"));
            //Vector3 relpos = playermovement - transform.position;
            if (playermovement != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(playermovement);
                transform.Translate(playermovement * walkspeed * Time.deltaTime, Space.World);
            }
        }

        if (CTRLID != 0 && colliders.Length>0 && Input.GetKeyDown("joystick " + CTRLID + " button 0"))
        {

            print("something happened");
            playerbody.AddForce(0, jumpForce, 0, ForceMode.Impulse);


        }

        if (CTRLID != 0 && Input.GetKeyDown("joystick " + CTRLID + " button 1"))
        {

            abilities.RangedRopeBolt(gameObject);

        }
        if (CTRLID != 0 && Input.GetKey("joystick " + CTRLID + " button 2"))
        {



        }

        if (CTRLID != 0 && Input.GetKeyDown("joystick " + CTRLID + " button 2"))
        {
            visual = true;
            GetComponent<LineOfFireVisual>().OnBool(visual);

        }

        if (CTRLID != 0 && Input.GetKeyUp("joystick " + CTRLID + " button 2"))
        {

            visual = false;
            GetComponent<LineOfFireVisual>().OnBool(visual);

            abilities.RangedBolt(gameObject);

        }

        if (health.isDead)
        {
            playermovement = new Vector3(0, 0, 0);
        }


    }
}