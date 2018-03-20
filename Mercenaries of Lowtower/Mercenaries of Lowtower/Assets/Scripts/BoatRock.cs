using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatRock : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(Mathf.Sin(Time.time*.125f)*.001f, Mathf.Sin(Time.time * .062f) * .00025f, Mathf.Sin(Time.time *.25f) * .001f);
        transform.rotation *= Quaternion.Euler(new Vector3(Mathf.Sin(Time.time * .125f) * .001f, Mathf.Sin(Time.time * .062f) * .00025f, Mathf.Sin(Time.time * .25f) * .001f));
	}
}
