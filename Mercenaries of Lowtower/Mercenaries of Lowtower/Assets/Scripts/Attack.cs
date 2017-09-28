using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
    float timer;
    public int targetslot;
    public GameObject boss;
    public float damage;
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        // Every x seconds, attack the boss. This is a testing script to deal damage to the boss and measure threat. Attacks may be more complex later.
        if (timer > 5)
        {
           
            dealDamage(boss);
            timer = 0;
        }
	}

    // This method controls the damage done, it chooses a target, finds their health script, and applies damage as well as sends their ID.
    public void dealDamage(GameObject target)
    {
       Health health = target.GetComponent<Health>();
        health.modifyHealth(damage, targetslot);

    }

    // This just assigns the ID to the character. This is explained more in the BossTargetingAI script.
   public void assignSlot(int slotNum)
    {
        targetslot = slotNum;
    }
}
