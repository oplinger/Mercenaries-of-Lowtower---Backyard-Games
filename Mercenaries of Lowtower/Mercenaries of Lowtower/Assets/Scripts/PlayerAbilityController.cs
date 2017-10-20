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
    public Collider[] colliderss;
    public int L1 = 1<<0;
    public int L2 = 1<<3;
    public int L3;
    public LayerMask Lall;



    public int overlapSphereRadius;


    // Use this for initialization
    void Start () {
       cooldown = GetComponent<PlayerCDController>();
        controller = GetComponent<ControllerThing>();


    }

    // Update is called once per frame
    void Update () {
        print(LayerMask.LayerToName(Lall));

    }

    //public void executeAttack(int attackID, int playerID, GameObject target)
    // {


    // }
    public void MeleeStrike(int playerID, GameObject me)
    {
        float damage = 10;
        //RaycastHit hit;


        //Debug.DrawRay(me.transform.position, me.transform.forward * 30, Color.blue);

        //if (Physics.Raycast(me.transform.position, me.transform.forward * 30, out hit))
        //   {

        //       if (hit.collider.gameObject.tag == "Enemy")
        //       {
        //           GameObject target = hit.collider.gameObject;
        //           Health health = target.GetComponent<Health>();
        //           print("got em" + target);
        //           health.modifyHealth(damage, 2);

        //       }
        //   }


        ////////////////////////////////////////////
        ////overlap sphere works to an extent
        ///////////////////////////////////////////
        Collider[] hitColliders = Physics.OverlapBox(me.transform.position + new Vector3(0, 0, 1.4f), new Vector3(2, 1, 5), Quaternion.identity, Lall);
        
        colliderss = hitColliders;
        for (int i = 0; i < hitColliders.Length; i++)
        {
            GameObject target = hitColliders[i].gameObject;
            Health health = target.GetComponent<Health>();
            //health.modifyHealth(damage, 2);
            if (target.name == "smol boi")
            {
                health.health -= damage;
            }
            if (target.name == "big boi")
            {
               
            }
        }




        cooldown.triggerCooldown(6, cooldown.abilityCooldowns[6]);


        
    }
    public void MeleeDash(int playerID, GameObject target)
    {
        target.transform.position = Vector3.MoveTowards(target.transform.position, target.transform.position + (target.transform.forward * 100), 1000 * Time.deltaTime);
    }
    public void RangedBolt(GameObject target)
    {
        if (cooldown.activeCooldowns[9]<=0)
        {
            GameObject clone = Instantiate(bolt, GameObject.Find("Bolt Spawn").transform.position, controller.IDs[3].gameObject.transform.rotation);
            Destroy(clone, 3);
            cooldown.triggerCooldown(9, cooldown.abilityCooldowns[9]);

        }
    }
    public void RangedRopeBolt(GameObject target)
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
            health.modifyHealth(-20, System.Array.IndexOf(controller.targets, "Healer Character"));
        }
    }
    public void HealerAbsorb()
    {
        int dam = 10;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 100, 1 << 8, QueryTriggerInteraction.Ignore);
        Collider[] EnemyColliders = Physics.OverlapSphere(transform.position, 100, 1 << 7, QueryTriggerInteraction.Ignore);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            Health health = hitColliders[i].gameObject.GetComponent<Health>();
            health.modifyHealth(-dam / hitColliders.Length, System.Array.IndexOf(controller.targets, "Healer Character"));
        }
        for (int i = 0; i < EnemyColliders.Length; i++)
        {
            Health health = EnemyColliders[i].gameObject.GetComponent<Health>();
            health.modifyHealth(dam, System.Array.IndexOf(controller.targets, "Healer Character"));
        }

    }

    ////////////////////////////////////
    //trying to visualize the overlap sphere
    ///////////////////////////////////
    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    // //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
    // Gizmos.DrawWireSphere(transform.position + new Vector3(0, 0, 1.4f), overlapSphereRadius);
    //}
}
