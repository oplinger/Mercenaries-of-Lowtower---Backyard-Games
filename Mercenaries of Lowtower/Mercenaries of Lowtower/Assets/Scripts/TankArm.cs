﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankArm : MonoBehaviour {
    public GameObject[] armJoint;
    public GameObject target;
    public Vector3 offset;
    public Vector3[] defaultJointPosition;
	// Use this for initialization
	void Start () {
		for(int i = 0; i < armJoint.Length; i++)
        {
            defaultJointPosition[i] = armJoint[i].transform.position;
        }
	}
	
	// Update is called once per frame
	void Update () {
        Debug.DrawRay(armJoint[2].transform.position, armJoint[2].transform.forward * -100);

        if (Input.GetKeyDown("f"))
        {
            RaycastHit hit;
            Physics.Raycast(armJoint[2].transform.position, armJoint[2].transform.forward*-100, out hit);

            if (hit.collider != null)
            {
                target = hit.collider.gameObject;

                offset = armJoint[2].transform.position - armJoint[1].transform.position;
                armJoint[1].transform.position = target.transform.position - offset;
                armJoint[2].transform.localScale *= 2;
            } else
            {
                return;
            }
        }
        // Tags or names can be used to create different actions. Or call different functions. (functions would be more efficient). So the arm can grab minions, and pull them back to the tank. Replace target with an overlap sphere array
        // and you can grab multiple. 
        if (Input.GetKeyUp("f"))
        {
            if (target != null)
            {
                armJoint[2].transform.localScale = new Vector3(1,1,1);
                target.transform.parent = armJoint[2].transform;
                armJoint[1].transform.position = defaultJointPosition[1];
                target.transform.parent = null;
                target = null;
            } else
            {
                return;
            }

        }
    }
}