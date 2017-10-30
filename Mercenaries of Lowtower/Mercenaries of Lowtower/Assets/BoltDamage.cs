using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltDamage : MonoBehaviour {
   public Health health;
    public GameObject controller;
	// Use this for initialization
	void Start () {
        controller = GameObject.Find("Controller Thing");
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
            ControllerThing CT = controller.GetComponent<ControllerThing>();
            int TID = System.Array.IndexOf(CT.targets, GameObject.Find("Ranged Character").GetComponent<Collider>());
            print(TID);
            health.modifyHealth(10, TID);
        }
    }
}
