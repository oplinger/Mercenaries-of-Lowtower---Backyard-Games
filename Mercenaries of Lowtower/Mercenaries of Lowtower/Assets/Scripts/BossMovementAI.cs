using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovementAI : MonoBehaviour {
    BossTargetingAI targeting;
    GameObject currentTarget;
    float targetDistance;
   public bool inRange;
	// Gets the targeting information from the BossTargetingAI script
	void Start () {
        targeting = GetComponent<BossTargetingAI>();
        currentTarget = targeting.currentTarget;
	}

    // If the currentTarget is empty, the boss searches for another target. then determines the targets range.
    // If the target is further than a minimum distance the boss will move towards the currentTarget, but not in the Y axis.
    // When in range the bool flips to true, and the boss attack AI resumes
    void Update () {
        if(currentTarget==null)
        {
            currentTarget = targeting.currentTarget;
        }

        targetDistance = Vector3.Distance(currentTarget.transform.position, transform.position);

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
