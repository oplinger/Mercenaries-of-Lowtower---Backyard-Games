using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockwaveScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.position.y < transform.position.y + 5 && other.tag=="Player")
        {
            other.GetComponent<Health>().modifyHealth(10, 9);
            other.GetComponent<Rigidbody>().AddForce((other.transform.position - transform.position) * 20);
        }
    }

    void Shockwave(float speed, float range, Vector3 position)
    {

    }
}
