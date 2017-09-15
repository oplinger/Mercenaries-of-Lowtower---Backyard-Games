using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour {
    ControllerThing controller;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        controller = GameObject.FindGameObjectWithTag("Controller").GetComponent<ControllerThing>();
        controller.ModifyHealth(-5, collision.gameObject);
        Destroy(gameObject);
    }
}
