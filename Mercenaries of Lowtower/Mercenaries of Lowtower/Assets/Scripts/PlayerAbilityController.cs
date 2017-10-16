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
        controller = GetComponent<ControllerThing>();


    }

    // Update is called once per frame
    void Update () {
    }

   //public void executeAttack(int attackID, int playerID, GameObject target)
   // {


   // }
    public void MeleeStrike(int playerID, GameObject target)
    {
        float damage = 5;
        cooldown.triggerCooldown(6, cooldown.abilityCooldowns[6]);
        Health health = target.GetComponent<Health>();
        health.modifyHealth(damage, 2);
    }
    public void RangedBolt(int playerID, GameObject target)
    {
        if (cooldown.activeCooldowns[9] <= 0)
        {
            GameObject clone = Instantiate(bolt, controller.targets[playerID].gameObject.transform.position + (Vector3.forward * 2), controller.targets[playerID].gameObject.transform.rotation);
            Destroy(clone, 3);
            cooldown.triggerCooldown(9, cooldown.abilityCooldowns[9]);
        }
    }
    public void RangedRopeBolt(int playerID, GameObject target)
    {
        if (cooldown.activeCooldowns[10] <= 0)
        {
            GameObject clone;
            clone = Instantiate(Resources.Load("RopeBolt", typeof(GameObject)), controller.targets[playerID].gameObject.transform.position + (Vector3.forward * 2), Quaternion.identity) as GameObject;
            Destroy(clone, 3);
            cooldown.triggerCooldown(10, cooldown.abilityCooldowns[10]);


        }
    }
}
