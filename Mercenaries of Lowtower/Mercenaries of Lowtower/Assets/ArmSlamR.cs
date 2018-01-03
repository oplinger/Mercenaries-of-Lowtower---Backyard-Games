﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ArmSlamR : MonoBehaviour {


    public float timeUntilSlam;
    public Transform waypointTop;
    public Transform waypointBottom;

    public float groundedTime;

    public bool attacking;

    public float tempTimeUntilSlam;
    public float tempGroundedTime;

    Renderer armRenderer;

    float damageTimer;
    public float tempDamageTimer;

    public GameObject hitbox;

    public bool damageOn;

    Health healthScript;

    float h1;
    float h2;

    // Use this for initialization
    void Start () {

        tempTimeUntilSlam = timeUntilSlam;

        tempGroundedTime = groundedTime;

        armRenderer = GetComponent<Renderer>();

        damageTimer = 30;
        tempDamageTimer = damageTimer;

        //RE flashing red when damaged
        healthScript = GetComponent<Health>();
        h2 = healthScript.health;


    }

    // Update is called once per frame
    void Update() {

        tempTimeUntilSlam -= 1;
        float t = 0.2f;

        if (Input.GetKeyDown(KeyCode.K))
        {

            transform.position = waypointBottom.position;
            //transform.position = Vector3.MoveTowards(transform.position, waypointBottom.position, 15 * Time.deltaTime);
            //tempGroundedTime -= 1;

        }


        //if (transform.position.y == waypointBottom.position.y)
        //{
        //    //makes the arm flash blue
        //    armRenderer.material.color = Color.Lerp(Color.white, Color.blue, Mathf.PingPong(Time.time * .5f, .5f));
        //}


        if (Input.GetKeyDown(KeyCode.O))
        {
            transform.position = waypointTop.position;
            //attacking = false;
            //transform.position = Vector3.MoveTowards(transform.position, waypointTop.position, 2 * Time.deltaTime);
            //Destroy(this.gameObject);
        }


        if (damageOn)
        {
            hitbox.SetActive(true);

            //tempDamageTimer = damageTimer;

            tempDamageTimer -= 1;
            
        }

        if (tempDamageTimer <= 0)
        {
            hitbox.SetActive(false);
            damageOn = false;
            tempDamageTimer = 30;
        }

        //makes object flash red when it takes damage
        h1 = healthScript.health;

        if (h1 < h2)
        {
            //armRenderer.material.SetColor("_EmissionColor", Color.red);
            armRenderer.material.color = Color.red;

            h2 = h1;
            //print("H2 = " + h2);
        }


    }
    

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Ground")
        {
            
            
            //makes the arm flash blue
            armRenderer.material.color = Color.Lerp(Color.white, Color.blue, Mathf.PingPong(Time.time * .5f, .5f));

        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Ground")
        {

            damageOn = true;

        }
    }



}
