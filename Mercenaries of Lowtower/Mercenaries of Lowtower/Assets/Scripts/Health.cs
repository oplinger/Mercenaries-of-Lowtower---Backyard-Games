using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
   public float health;

	// Use this for initialization
	void Start () {
        health = 100;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void modifyHealth(float dam, int ID)
    {
        health -= dam;
        print(dam + "damage done!");
        if (gameObject.tag == "Enemy")
        {
           BossTargetingAI threat = GetComponent<BossTargetingAI>();
            threat.addThreat(dam, ID);
           // print("Boss Adding Threat");
        }
    }
}
