using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamDamageScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            print("Boom");
            other.GetComponent<IDamageable<float>>().TakeDamage(40);
        }
    }
}
