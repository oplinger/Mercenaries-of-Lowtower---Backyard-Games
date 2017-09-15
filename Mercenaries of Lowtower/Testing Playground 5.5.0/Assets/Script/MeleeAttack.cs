using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour {
    ControllerThing controller;
	// Use this for initialization
	void Start () {
        controller = GameObject.FindGameObjectWithTag("Controller").GetComponent<ControllerThing>();
    }

    // Update is called once per frame
    void Update () {
		if (Input.GetKeyDown("m"))
        {
            controller.CastRay(gameObject, transform.forward, 3, 1, "Attack");
        }
        if (Input.GetKeyDown("t"))
        {
            controller.CastRay(gameObject, transform.forward, 10, 2, "Attack");
        }
    }
}
