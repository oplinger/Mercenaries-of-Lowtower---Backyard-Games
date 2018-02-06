using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleClass : BossClass {
    public GameObject boss;
	// Use this for initialization
	void Start () {
        maxHealth = 1000;
        currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("j"))
        {
            print("damaged boss");
            TakeDamage(5);
        }
	}

    public new void TakeDamage(float damageTaken)
    {
        boss.GetComponent<BossClass>().currentHealth -= damageTaken;
    }
}
