using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunScript : MonoBehaviour {
    public bool isStunned;
    Vector3 stunThis;
    float runSpeed;
    float stunTimer;
    float stunDuration;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isStunned)
        {
            stunTimer += Time.deltaTime;
            //transform.Translate(new Vector3(Random.Range(-4, 4) * Time.deltaTime, 0, Random.Range(-4, 4) * Time.deltaTime));
            //transform.Translate((stunThis.normalized)*runSpeed);
            if (stunTimer >= stunDuration)
            {
                isStunned = false;
                stunTimer = 0;
            }
        }
	}
    public void Stun(GameObject me, float runspeed, float controllerStunDuration)
    {
        isStunned = true;
        stunThis = transform.position - me.transform.position;
        runSpeed = runspeed;
        stunDuration = controllerStunDuration;
    }
}
