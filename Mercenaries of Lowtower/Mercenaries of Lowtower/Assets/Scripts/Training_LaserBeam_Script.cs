using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Training_LaserBeam_Script : MonoBehaviour {


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            other.GetComponent<IDamageable<float>>().TakeDamage(40);
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
