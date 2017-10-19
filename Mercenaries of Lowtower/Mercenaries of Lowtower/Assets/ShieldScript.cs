using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Enemy")
        {
            other.transform.position += new Vector3(Random.Range(-25, 25), 0, Random.Range(-25, 25));
        }

        
    }

    private void OnTriggerStay(Collider other)
    {
        //if (other.tag == "Player" && Input.GetButton("DropShield"))
        //{
        //    transform.position += new Vector3(Input.GetAxis("TankHorizontal")*.15f, 0, Input.GetAxis("TankVertical")*.15f);
        //}
    }
}
