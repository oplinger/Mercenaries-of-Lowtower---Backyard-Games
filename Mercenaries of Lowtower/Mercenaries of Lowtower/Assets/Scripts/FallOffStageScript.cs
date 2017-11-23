using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallOffStageScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCollisionEnter(Collision col)
    {
        //IDs[i].gameObject.transform.position = GameObject.Find("P" + i + "Spawn").transform.position;
        if(col.gameObject.name == "Tank Character(Clone)")
        {
            col.gameObject.transform.position = GameObject.Find("P0Spawn").transform.position;
        }
        if (col.gameObject.name == "Healer Character(Clone)")
        {
            col.gameObject.transform.position = GameObject.Find("P1Spawn").transform.position;

        }
        if (col.gameObject.name == "Melee Character(Clone)")
        {
            col.gameObject.transform.position = GameObject.Find("P2Spawn").transform.position;

        }
        if (col.gameObject.name == "Ranged Character(Clone)")
        {
            col.gameObject.transform.position = GameObject.Find("P3Spawn").transform.position;

        }
    }
}
