using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldRotation : MonoBehaviour {
    float timer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > .75f)
        {
            transform.RotateAround(transform.position, Vector3.up, 360 * Time.deltaTime / 450);
        }
	}
}
