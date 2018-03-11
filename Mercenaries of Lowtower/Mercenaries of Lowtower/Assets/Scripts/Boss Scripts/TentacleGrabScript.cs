using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleGrabScript : MonoBehaviour {

    public bool dmgDetectorActivated;
    public GameObject dmgDetector;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        dmgDetectorActivated = dmgDetector.GetComponent<TentacleSlamDamage>().tentDown;

		if(dmgDetectorActivated == true)
        {
            gameObject.GetComponent<Collider>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<Collider>().enabled = false;
        }
	}
}
