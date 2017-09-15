using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingAura : MonoBehaviour {
    bool onoff;
    Collider[] healtargets;
    ControllerThing controller;
    float timer;
	// Use this for initialization
	void Start () {
        controller = GameObject.FindGameObjectWithTag("Controller").GetComponent<ControllerThing>();

    }

    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
		if (Input.GetKeyDown("h"))
        {
            onoff = !onoff;
        }

        if (onoff && timer>2)
        {

            healtargets = Physics.OverlapSphere(transform.position, 10, 2, QueryTriggerInteraction.Ignore);
            for (int i = 0; i < healtargets.Length; i++)
            {
                controller.ModifyHealth(5, healtargets[i].gameObject);

            }
            timer = 0;
        }
	}
}
