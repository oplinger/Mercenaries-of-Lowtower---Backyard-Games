﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovementAI : MonoBehaviour {
    BossTargetingAI targeting;
     GameObject currentTarget;
    
    public float targetDistance;
    public bool inRange;
    public float minimumDistance;
    public float maxDistance;
    float stunTimer;
    public bool stun;

    //Variable to hold the current speed of the boss
    public float speed;

    //Variable to hold the speed at which the boss rotates to orient itself toward the player
    public float rotateSpeed = 4f;

    // Gets the targeting information from the BossTargetingAI script
    void Start () {
        targeting = GetComponent<BossTargetingAI>();
        currentTarget = targeting.currentTarget;
	}

    // If the currentTarget is empty, the boss searches for another target. then determines the targets range.
    // If the target is further than a minimum distance the boss will move towards the currentTarget, but not in the Y axis.
    // When in range the bool flips to true, and the boss attack AI resumes
    void Update () {
        
        if (stun)
        {
            Stun(4);
        }
        if(currentTarget==null)
        {
            currentTarget = targeting.currentTarget;
        }
        currentTarget = targeting.currentTarget;
        targetDistance = Vector3.Distance(currentTarget.transform.position, transform.position);

        if (targetDistance < maxDistance)
        {
            Vector3 dir = currentTarget.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotateSpeed * Time.deltaTime);

            if (targetDistance > minimumDistance)
            {
                inRange = false;
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(currentTarget.transform.position.x, transform.position.y, currentTarget.transform.position.z), speed * Time.deltaTime);
                // .01f was in place of "speed"

                //Orients the boss towards the player
               

            }
            else
            {
                inRange = true;
            }
        }
        else
        {

        }
	}

    public void Stun(float duration)
    {
        
        stunTimer += Time.deltaTime;
        if (stunTimer < duration)
        {
            speed = 0;
        } else if (stunTimer > duration)
        {
            stun = false;
            speed = 10;
            stunTimer = 0;

        }
    }
}
