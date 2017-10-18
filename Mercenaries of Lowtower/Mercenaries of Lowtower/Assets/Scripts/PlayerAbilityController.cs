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
    public void MeleeDash(int playerID, GameObject target)
    {
        target.transform.position = Vector3.MoveTowards(transform.position, transform.position + (transform.forward * 10), 100 * Time.deltaTime);
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

    public void TankShield()
    {
        Instantiate(Resources.Load("shield"), transform.position, transform.rotation);
    }
    public void TankMagnet(GameObject target)
    {

        RaycastHit hit;
        Ray ray = new Ray(gameObject.transform.position, transform.forward*30);
        if (Physics.Raycast(ray, out hit, 30))
        {
            target = hit.collider.gameObject;
            target.transform.position = Vector3.MoveTowards(target.transform.position, transform.position, 5);
        }
    }

    public void HealerHeal()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 100, 1 << 8, QueryTriggerInteraction.Ignore);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            Health health = hitColliders[i].gameObject.GetComponent<Health>();
            health.modifyHealth(-20, System.Array.IndexOf(controller.targets, "Healer Character"));
        }
    }
    public void HealerAbsorb()
    {
        int dam = 10;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 100, 1 << 8, QueryTriggerInteraction.Ignore);
        Collider[] EnemyColliders = Physics.OverlapSphere(transform.position, 100, 1 << 9, QueryTriggerInteraction.Ignore);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            Health health = hitColliders[i].gameObject.GetComponent<Health>();
            health.modifyHealth(-dam / hitColliders.Length, System.Array.IndexOf(controller.targets, "Healer Character"));
        }
        for (int i = 0; i < EnemyColliders.Length; i++)
        {
            Health health = hitColliders[i].gameObject.GetComponent<Health>();
            health.modifyHealth(dam, System.Array.IndexOf(controller.targets, "Healer Character"));
        }
    }
}
