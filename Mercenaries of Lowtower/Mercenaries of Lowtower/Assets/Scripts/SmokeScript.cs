using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeScript : MonoBehaviour {
    float scaleRate = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.localScale += new Vector3(scaleRate * Time.deltaTime, scaleRate * Time.deltaTime, scaleRate * Time.deltaTime);
	}

    public void Dissipation(float rate)
    {
        scaleRate = rate;
    }
}
