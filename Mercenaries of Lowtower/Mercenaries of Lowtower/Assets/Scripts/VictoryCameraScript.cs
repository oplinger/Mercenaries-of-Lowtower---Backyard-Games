using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryCameraScript : MonoBehaviour {

    public GameObject waypoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = Vector3.MoveTowards(transform.position, waypoint.transform.position, .2f);
		
	}
}
