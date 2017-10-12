﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashScript : MonoBehaviour {
    public float speed;
    public float dashSpeed;
    public float jumpSpeed;
    public float gravity;
    private Vector3 moveDirection = Vector3.zero;
    Vector3 dashVector = Vector3.zero;
    float timer;

    public bool isDashing=false;
    public float dashLength;
    public float tempDashLength;

    public float tempDashSpeed;

    Rigidbody playerbody;

    GameObject player;

    MovementRigidbody moveRbScript;
    

    private void Start()
    {

        playerbody = GetComponent<Rigidbody>();
        player = this.gameObject;
        moveRbScript = player.GetComponent<MovementRigidbody>();
    }

    void Update()
    {
        //CharacterController controller = GetComponent<CharacterController>();

        //print(moveRbScript.playerbody.gameObject.transform.Translate);

        if (Input.GetAxis("Dash") == 1 && !isDashing)
        {
            isDashing = true;

           // moveRbScript.playerbody.velocity=moveRbScript.playermovement*dashSpeed;

            /*if (Input.GetAxis("Horizontal") > 0)
            {
                dashVector.x=dashSpeed;
            }
            if (Input.GetAxis("Horizontal") < 0)
            {
                dashVector.x = dashSpeed*-1;
            }

            if (Input.GetAxis("Vertical") > 0)
            {
                dashVector.z = dashSpeed;
            }
            if (Input.GetAxis("Vertical") < 0)
            {
                dashVector.z = dashSpeed * -1;
            }*/

            //moveRbScript.playerbody.velocity = Vector3.Lerp(moveRbScript.playermovement, moveRbScript.playermovement * dashSpeed, tempDashLength);

            tempDashLength = dashLength;
            tempDashSpeed = dashSpeed;
        }

        if (isDashing)
        {
            tempDashLength--;
            //moveRbScript.playerbody.AddForce(transform.forward * dashSpeed, ForceMode.Impulse);
            transform.position = Vector3.MoveTowards(transform.position, transform.position+(transform.forward*10), 100 * Time.deltaTime);
            print(transform.position + (Vector3.forward * 3));
            if (tempDashLength <= 0)
            {
                isDashing = false;
                tempDashSpeed = 0;
            }
        }
        
        
        moveDirection.y -= gravity * Time.deltaTime;

       // Debug.Log("" + dashVector);
        //transform.rotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0, moveDirection.z));

    }
}