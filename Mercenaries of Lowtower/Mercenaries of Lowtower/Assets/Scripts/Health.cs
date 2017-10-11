using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
   public float health;

	// Initializes the gameObject with 100 health. Can be tweaked with If statements or a health Method.
	void Start () {
        health = 100;
	}

    // This method takes passed in data and manipulates the health value. Damage is the amount of health lost or gained (negative values are healing) 
    //and the ID is the character ID that is doing the damage. These are assigned to players by the boss on start.
    public void modifyHealth(float dam, int ID)
    {
        if(health > 0)
        {
            health -= dam;
        }
        else if(health <= 0)
        {
            Debug.Log("Player is dead.");
            GetComponent<DeathScript>().PlayerDeath();
        }
       
        // If the target is an enemy, it will convert any damage done to it to threat, for targeting purposes.
        if (gameObject.tag == "Enemy")
        {
           BossTargetingAI threat = GetComponent<BossTargetingAI>();
            threat.addThreat(dam, ID);         
        }
    }
}
