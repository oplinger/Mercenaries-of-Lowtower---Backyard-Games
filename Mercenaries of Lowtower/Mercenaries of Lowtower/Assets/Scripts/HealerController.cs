using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealerController : MonoBehaviour
{
    public GameObject controllerThing;
    public Vector3 playermovement;
    public float walkspeed;
    public ControllerThing controller;
    public int CTRLID;
    public PlayerAbilityController abilities;
    public PlayerCDController cooldowns;
    float timer;
    Animator anim;
    Health health;
    float health2 = 100;


    // Use this for initialization
    void Start()
    {
        controller = controllerThing.GetComponent<ControllerThing>();
        abilities = controllerThing.GetComponent<PlayerAbilityController>();
        cooldowns = controllerThing.GetComponent<PlayerCDController>();
        anim = GetComponent<Animator>();
        health = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, Vector3.forward * 50);
        if (walkspeed >= 0 && CTRLID != 0)
        {
            playermovement = new Vector3(Input.GetAxis("J" + CTRLID + "Horizontal"), 0, Input.GetAxis("J" + CTRLID + "Vertical"));
            //Vector3 relpos = playermovement - transform.position;
            if (playermovement != Vector3.zero)
            {
                anim.SetInteger("Walk", 1);
                anim.SetInteger("Idle", 0);



                transform.rotation = Quaternion.LookRotation(playermovement);
                transform.Translate(playermovement * walkspeed * Time.deltaTime, Space.World);
            }
            else
            {
                anim.SetInteger("Walk", 0);
                anim.SetInteger("Idle", 1);

            }
        }

        if (CTRLID != 0 && Input.GetKeyDown("joystick " + CTRLID + " button 1"))
        {
            anim.SetInteger("Attack", 1);

            abilities.HealerAbsorb();

        }
        else
        {
            anim.SetInteger("Attack", 0);

        }
        if (CTRLID != 0 && Input.GetKeyDown("joystick " + CTRLID + " button 2"))
        {
            anim.SetInteger("Attack", 1);

            abilities.HealerHeal();

        } else
        {
            anim.SetInteger("Attack", 0);

        }
        if (CTRLID != 0 && Input.GetKeyDown("joystick " + CTRLID + " button 0"))
        {
            anim.SetInteger("Jump", 1);

            abilities.Jump(CTRLID, gameObject);

        }


        CheckHealth();

        if (health.health <= 0)
        {
            anim.SetInteger("Idle", 0);
            anim.SetInteger("GetHurt", 0);
            anim.SetInteger("Walk", 0);
            anim.SetInteger("Jump", 0);
            anim.SetInteger("Attack", 0);
            anim.SetInteger("Death", 1);

        }



    }
    void CheckHealth()
    {
        if (health.health<health2)
        {
            anim.SetInteger("GetHurt", 1);
        }
         else
        {

            anim.SetInteger("GetHurt", 0);
        }
        health2 = health.health;
    }
}
