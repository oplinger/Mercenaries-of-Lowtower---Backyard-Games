﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2MovementRigidbody : MonoBehaviour
{
    public Rigidbody playerbody;
    public GameObject player;
    public float walkspeed;
    public Vector3 playermovement;

    ControllerThing controller;

    bool climbing;
    float testtime;
    public bool isGrounded;
    public bool isWalled;
    public float jumpspeed;
    int jumpcount;
    Vector3 wallDir;
    Vector3 jumpDir;

    public GameObject wall;

    // Use this for initialization
    void Start()
    {
        playerbody = GetComponent<Rigidbody>();
        controller = GameObject.FindGameObjectWithTag("Controller").GetComponent<ControllerThing>();
        player = this.gameObject;


    }

    // Update is called once per frame
    void Update()
    {
        //Debug.DrawRay(gameObject.transform.position, transform.up * -10, Color.green);

        if (isGrounded)
        {
            isWalled = false;
        }
        if (isGrounded && jumpDir == Vector3.zero)
        {
            //controller.CastRay(gameObject, transform.up * -10, 0, 1, "P2Jump");
            print("anything");
        }
        if (!climbing)
        {
            playermovement = new Vector3(Input.GetAxis("P2Horizontal") * walkspeed * Time.deltaTime, 0, Input.GetAxis("P2Vertical") * walkspeed * Time.deltaTime);
            transform.Translate(playermovement);

        }
        if (climbing)
        {
            playermovement = new Vector3(0, Input.GetAxis("P2Vertical") / 10, 0);
            transform.Translate(playermovement);

        }


        // playermovement.y -= gravity * Time.deltaTime;
        if (Input.GetButton("P2Jump"))
        {
            PlayerJump(jumpDir);

            //if (isGrounded || isWalled)
            //{
            //    PlayerJump(jumpDir);
            //}
        }

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Climbable")

        {
            climbing = true;
            playerbody.useGravity = false;
        }
        if (other.tag == "Ground")
        {
            isGrounded = true;
            jumpcount = 0;
            //controller.CastRay(gameObject, transform.up * -1, 0, 1, "P2Jump");
        }
        if (other.tag == "Wall" && jumpcount < 1)
        {
            isWalled = true;
            // controller.CastRay(gameObject, other.transform.position - transform.position, 0, 1, "Jump");

            //controller.CastRay(gameObject, other.transform.position - transform.position, 0, 1, "P2Jump");

        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Climbable")
        {
            climbing = false;
            playerbody.useGravity = true;
        }
        if (other.tag == "Ground")
        {
            isGrounded = false;
            jumpDir = Vector3.zero;
        }
        if (other.tag == "Wall")
        {
            isWalled = false;
            //jumpcount++;
            jumpDir = Vector3.zero;
        }
    }
    public void PlayerJump(Vector3 jumpDirection)
    {


        if (isGrounded)
        {

            playerbody.AddForce(jumpDirection.normalized * jumpspeed, ForceMode.Impulse);

        }

        if (isWalled)
        {
            jumpDirection.y = 1f;
            playerbody.AddForce(jumpDirection.normalized * jumpspeed, ForceMode.Impulse);


        }
    }
    public void SetDirection(Vector3 direction)
    {
        jumpDir = direction;
    }


}
