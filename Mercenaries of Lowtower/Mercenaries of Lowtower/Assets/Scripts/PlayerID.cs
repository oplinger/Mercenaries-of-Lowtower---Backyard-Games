using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerID : MonoBehaviour {
    public int playerID;
    public ControllerThing controller;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void assignID(int slotNum)
    {
        playerID = slotNum;

    }
}
