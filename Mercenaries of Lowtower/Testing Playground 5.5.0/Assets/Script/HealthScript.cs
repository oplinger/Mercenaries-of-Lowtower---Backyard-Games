using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour {

    int health;

	// Use this for initialization
	void Start () {
        health = 100;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeHealth(int modifier)
    {
        health += modifier;
        print("HEALTH CHANGED BY: " + modifier);
    }
}
