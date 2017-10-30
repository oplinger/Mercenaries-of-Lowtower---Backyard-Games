using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeController : MonoBehaviour {
    public GameObject controllerThing;
    public Vector3 playermovement;
    public float walkspeed;
    public ControllerThing controller;
    public int CTRLID;
    public PlayerAbilityController abilities;
    public PlayerCDController cooldowns;
    public LayerMask lMask;
    public Collider[] colliders;
    public bool visual;

    float timer;

    Health healthScript;

    // Use this for initialization
    void Start()
    {
        controller = controllerThing.GetComponent<ControllerThing>();
        abilities = controllerThing.GetComponent<PlayerAbilityController>();
        cooldowns = controllerThing.GetComponent<PlayerCDController>();


        healthScript = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;

        colliders = Physics.OverlapCapsule(transform.position, transform.position - (Vector3.up * 2), .25f, lMask, QueryTriggerInteraction.Ignore);

       

        if (walkspeed>= 0 && CTRLID != 0)
        {
            playermovement = new Vector3(Input.GetAxis("J"+ CTRLID + "Horizontal"), 0, Input.GetAxis("J"+CTRLID+"Vertical"));
            //Vector3 relpos = playermovement - transform.position;
            if (playermovement != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(playermovement);
                transform.Translate(playermovement * walkspeed * Time.deltaTime, Space.World);
            }

            if (healthScript.isDead)
            {
               // playermovement = new Vector3 (0,0,0);
            }
        }

        if (CTRLID != 0 && colliders.Length > 0 && Input.GetKeyDown("joystick " + CTRLID + " button 0"))
        {

            print("something happened");
            abilities.Jump(CTRLID, gameObject);


        }


        if (CTRLID != 0 && Input.GetKeyDown("joystick " + CTRLID + " button 1"))
        {
            
            
                abilities.MeleeDash(System.Array.IndexOf(controller.targets, GameObject.Find("Melee Character").GetComponent<Collider>()), gameObject);
            

        }
        if (CTRLID != 0 && Input.GetKeyDown("joystick " + CTRLID + " button 2"))
        {

            visual = true;
            GetComponent<MeleeVisualization>().OnBool(visual);


        }
        if (CTRLID != 0 && Input.GetKeyUp("joystick " + CTRLID + " button 2"))
        {

            visual = false;
            GetComponent<MeleeVisualization>().OnBool(visual);

            abilities.MeleeStrike(System.Array.IndexOf(controller.targets, GameObject.Find("Melee Character").GetComponent<Collider>()), gameObject);


        }
        print(System.Array.IndexOf(controller.targets, GameObject.Find("Melee Character").GetComponent<Collider>()));

    }
}
