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
    public LayerMask enemyMask;

	// Use this for initialization
	void Start () {
       cooldown = GetComponent<PlayerCDController>();
        controller = GetComponent<ControllerThing>();
        bossTargets = GameObject.Find("Boss").GetComponent<BossTargetingAI>();


    }

    // Update is called once per frame
    void Update () {
    }

   //public void executeAttack(int attackID, int playerID, GameObject target)
   // {


   // }

        public void Jump(int PlayerID, GameObject player)
    {
        
           
                player.GetComponent<Rigidbody>().AddForce(0, 20, 0, ForceMode.Impulse);
        
    }

    public void MeleeStrike(int playerID, GameObject me)
    {
        float damage = 5;
        RaycastHit hit;
        if (Physics.Raycast(me.transform.position, me.transform.forward * 30, out hit))
        {
            if(hit.collider.gameObject.tag == "Enemy")
            {
                GameObject target = hit.collider.gameObject;
                Health health = target.GetComponent<Health>();
                health.modifyHealth(damage, playerID);

            }
        }
        cooldown.triggerCooldown(6, cooldown.abilityCooldowns[6]);


    }
    public void MeleeDash(int playerID, GameObject target)
    {
        target.transform.position = Vector3.MoveTowards(target.transform.position, target.transform.position + (target.transform.forward * 100), 1000 * Time.deltaTime);
    }
    public void RangedBolt(int playerID , GameObject target)
    {

            GameObject clone = Instantiate(bolt, controller.IDs[3].gameObject.transform.position + (Vector3.forward * 2), controller.IDs[3].gameObject.transform.rotation);
            Destroy(clone, 3);
            cooldown.triggerCooldown(9, cooldown.abilityCooldowns[9]);
        
    }
    public void RangedRopeBolt(int playerID, GameObject target)
    {
        if (cooldown.activeCooldowns[10] <= 0)
        {
            GameObject clone;
            clone = Instantiate(Resources.Load("RopeBolt", typeof(GameObject)), controller.IDs[3].gameObject.transform.position + (Vector3.forward * 2), Quaternion.identity) as GameObject;
            Destroy(clone, 3);
            cooldown.triggerCooldown(10, cooldown.abilityCooldowns[10]);


        }
    }

    public void TankShield(GameObject me)
    {
        Instantiate(Resources.Load("shield"), me.transform.position, me.transform.rotation);
    }
    public void TankMagnet()
    {

        RaycastHit hit;
        Ray ray = new Ray(gameObject.transform.position, transform.forward*30);
        if (Physics.Raycast(ray, out hit, 30))
        {
           GameObject target = hit.collider.gameObject;
            target.transform.position = Vector3.MoveTowards(target.transform.position, transform.position, 5);
        }
    }

    public void HealerHeal()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 100, 1 << 8, QueryTriggerInteraction.Ignore);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            Health health = hitColliders[i].gameObject.GetComponent<Health>();
            health.modifyHealth(-20, 1);
            

        }
        bossTargets.addThreat(20, 1);
    }
    public void HealerAbsorb()
    {
        int dam = 10;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 100, 1 << 8, QueryTriggerInteraction.Ignore);
        Collider[] EnemyColliders = Physics.OverlapSphere(transform.position, 100, enemyMask, QueryTriggerInteraction.Ignore);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            Health health = hitColliders[i].gameObject.GetComponent<Health>();
            health.modifyHealth(-dam / hitColliders.Length, 1);
        }
        for (int i = 0; i < EnemyColliders.Length; i++)
        {
            Health health = EnemyColliders[i].gameObject.GetComponent<Health>();
            print(EnemyColliders[i]);
            health.modifyHealth(dam, 1);
        }

    }
}
