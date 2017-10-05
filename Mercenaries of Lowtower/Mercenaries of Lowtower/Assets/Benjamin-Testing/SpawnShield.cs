using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShield : MonoBehaviour {

    public GameObject shield;
    public bool shieldUp;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButton("DropShield" )&& shieldUp==false)
        {
            Instantiate(shield, transform.position, transform.rotation);
            shieldUp = true;
        }
		
	}
}
