using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityController : MonoBehaviour {
    ControllerThing controller;
   public BossTargetingAI bossTargets;
    Attack playerAttack;
    PlayerCDController cooldown;
    public GameObject bolt;
    public GameObject P2BoltSpawn;
	// Use this for initialization
	void Start () {
       cooldown = GetComponent<PlayerCDController>();
        controller = bossTargets.controller;
        

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
                GameObject clone = Instantiate(bolt, P2BoltSpawn.transform.position, controller.targets[0].gameObject.transform.rotation);
                Destroy(clone, 3);
                    
                cooldown.triggerCooldown(attackID, 3);
            }
        }

        if (attackID == 3)
        {
            if (cooldown.activeCooldowns[attackID] <= 0)
            {
                GameObject clone;
                clone = Instantiate(Resources.Load("RopeBolt", typeof(GameObject)), controller.targets[0].gameObject.transform.position + (Vector3.forward*2), Quaternion.identity) as GameObject;
                Destroy(clone, 3);
                cooldown.triggerCooldown(attackID, 5);
                Debug.DrawRay(controller.targets[0].gameObject.transform.position, Vector3.forward * 1000, Color.white, 1);
                

            }
        }

    }
}
