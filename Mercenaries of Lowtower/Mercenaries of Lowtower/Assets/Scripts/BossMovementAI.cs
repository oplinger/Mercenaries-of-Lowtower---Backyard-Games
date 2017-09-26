using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovementAI : MonoBehaviour {
    BossTargetingAI targeting;
    GameObject currentTarget;
    float targetDistance;
   public bool inRange;
	// Use this for initialization
	void Start () {
        targeting = GetComponent<BossTargetingAI>();
        currentTarget = targeting.currentTarget;
	}
	
	// Update is called once per frame
	void Update () {
        if(currentTarget==null)
        {
            currentTarget = targeting.currentTarget;
        }

        targetDistance = Vector3.Distance(currentTarget.transform.position, transform.position);
        //print(targetDistance);
        if (targetDistance > 10)
        {
            inRange = false;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(currentTarget.transform.position.x, transform.position.y, currentTarget.transform.position.z), .01f);
        } else
        {
            inRange = true;
        }
	}
}
