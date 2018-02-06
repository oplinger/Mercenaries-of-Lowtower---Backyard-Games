using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleDamage : MonoBehaviour {

    public bool armDownCheck;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        armDownCheck = GetComponentInParent<BossArmScript>().armDown;
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !armDownCheck)
        {
            print("Boom");
            other.GetComponent<IDamageable<float>>().TakeDamage(60);
        }
    }
}
