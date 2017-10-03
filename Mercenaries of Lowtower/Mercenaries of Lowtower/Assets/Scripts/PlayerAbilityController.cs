using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityController : MonoBehaviour {
    Attack playerAttack;
    PlayerCDController cooldown;
	// Use this for initialization
	void Start () {
        cooldown = GetComponent<PlayerCDController>();
    }
	
	// Update is called once per frame
	void Update () {

	}

   public void executeAttack(int attackID, int playerID, GameObject target)
    {
        //do attack thing based on attack ID
        if (attackID == 0 && playerID == 2)
        {
            if (cooldown.activeCooldowns[attackID] <= 0)
            {

                float damage = 5;
                cooldown.triggerCooldown(0, cooldown.abilityCooldowns[attackID]);
                Health health = target.GetComponent<Health>();
                health.modifyHealth(damage, 2);
            }
        }

    }
}
