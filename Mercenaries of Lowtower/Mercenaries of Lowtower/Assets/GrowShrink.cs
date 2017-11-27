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

    // Use this for initialization
    void Start () {

        healthScript = GetComponent<Health>();

        //h2 = healthScript.health;

        platformPosition = transform.position;

    }
	
	// Update is called once per frame
	void Update () {

        if (healthScript.health > 1)
        {
            healthScript.health -= .1f;
        }


        transform.position = new Vector3 (platformPosition.x, healthScript.health,platformPosition.z);
        print(platformPosition);

        //h1 = healthScript.health;

        ////if health decreased
        //if (h1 < h2)
        //{
        //    transform.position-=new Vector3 (0,1,0);

        //    h2 = h1;
        //    //print(h2);
        //}

        ////if health increased
        //if (h2<h1)
        //{

        //    transform.position += new Vector3(0, 1, 0);

        //}


    }
}
