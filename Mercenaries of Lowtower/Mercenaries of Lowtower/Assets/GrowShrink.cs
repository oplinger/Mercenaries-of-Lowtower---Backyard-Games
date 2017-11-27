using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowShrink : MonoBehaviour {

    Health healthScript;

    float h1;
    float h2;

    Transform platformHeight;

    Vector3 platformPosition;
    //GameObject platform;

    public Transform waypointTop;
    public Transform waypointBottom;

    // Use this for initialization
    void Start () {

        healthScript = GetComponent<Health>();

        //h2 = healthScript.health;

        transform.position = waypointBottom.position;

    }
	
	// Update is called once per frame
	void Update () {

        if (healthScript.health > 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypointTop.position, 2*Time.deltaTime);
            healthScript.health -= .1f;
        }

        if (healthScript.health<=1)
        {

            transform.position = Vector3.MoveTowards(transform.position, waypointBottom.position, 2 * Time.deltaTime);
        }


        //transform.position = new Vector3 (platformPosition.x, healthScript.health*.1f,platformPosition.z);
        print(platformPosition);

    

    }
}
