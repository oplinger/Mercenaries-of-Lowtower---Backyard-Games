using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityController : MonoBehaviour {
    BossTargetingAI bossTargets;
    Attack playerAttack;
    PlayerCDController cooldown;
    public GameObject bolt;
    public GameObject P2BoltSpawn;
	// Use this for initialization
	void Start () {
        cooldown = GetComponent<PlayerCDController>();
        bolt = Instantiate(Resources.Load("Bolt", typeof(GameObject))) as GameObject;

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

        if (attackID == 1)
        {
            if (cooldown.activeCooldowns[attackID] <= 0)
            {

                
            }
        }

        if (attackID == 2)
        {
            if (cooldown.activeCooldowns[attackID] <= 0)
            {
                Instantiate(bolt, P2BoltSpawn.transform.position, Quaternion.identity);
                print(attackID);
            }
        }

    }
}
