using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FireCannon : MonoBehaviour {

    public GameObject cannonball;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)

    {

        if (other.name == "cannonball")
        {

            print("is touching");
            Destroy(other.gameObject);
            //other.transform.position = this.gameObject.transform.position;
            //Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            //rb.AddForce(transform.forward * 2);
        }
    }
}
