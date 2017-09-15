using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attraction : MonoBehaviour {
    ControllerThing controller;
	// Use this for initialization
	void Start () {
        controller = GameObject.FindGameObjectWithTag("Controller").GetComponent<ControllerThing>();

    }

    // Update is called once per frame
    void Update () {
		if (Input.GetKey("r"))
        {
            Debug.DrawRay(transform.position, transform.forward * 10000);
            controller.CastRay(gameObject, transform.forward, 0, 1000, "Attract");

        }
	}
    public void Attract(GameObject target, float attractspeed)
    {
        target.transform.position = Vector3.MoveTowards(target.transform.position, transform.position, attractspeed);
    }

}
