using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltDamage : MonoBehaviour {
   public Health health;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Enemy")
        {
            print("HIT BOSS");
            health = other.GetComponent<Health>();
            health.modifyHealth(10, 3);
        }
    }
}
