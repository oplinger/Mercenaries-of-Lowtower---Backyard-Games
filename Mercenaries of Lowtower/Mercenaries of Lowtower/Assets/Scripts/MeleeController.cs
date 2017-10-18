using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeController : MonoBehaviour {
    public int CTRLID;
	// Use this for initialization
	void Start () {
        CTRLID += 1;
	}
	
	// Update is called once per frame
	void Update () {
        
		if(Input.GetKeyDown("joystick " + CTRLID + " button 0"))
        {
            print("OFCK");
        }
	}
}
