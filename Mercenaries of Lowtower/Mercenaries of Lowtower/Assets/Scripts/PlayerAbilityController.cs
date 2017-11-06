using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityController : MonoBehaviour {
    #region Variables
    ControllerThing controller;
   public BossTargetingAI bossTargets;
    PlayerCDController cooldown;
    public GameObject bolt;
    public GameObject P2BoltSpawn;
    public LayerMask enemyMask;
    #endregion

    // Use this for initialization
    void Start () {
       cooldown = GetComponent<PlayerCDController>();
        controller = GetComponent<ControllerThing>();

        if(GameObject.Find("Boss") == null)
        {
            
        } else
        {
            bossTargets = GameObject.Find("Boss").GetComponent<BossTargetingAI>();

        }


    }

    #region General Abilities
    public void Jump(int PlayerID, GameObject player)
    {           
                player.GetComponent<Rigidbody>().AddForce(0, 20, 0, ForceMode.Impulse);
    }
#endregion
    #region Tank Abilities
    public void TankShield(GameObject me)
    {
        Instantiate(Resources.Load("shield"), me.transform.position, me.transform.rotation);
        cooldown.triggerCooldown(1, cooldown.abilityCooldowns[1]);
    }
    public void TankMagnet(int playerID, GameObject me)
    {

        RaycastHit hit;
        Ray ray = new Ray(me.transform.position, me.transform.forward * 30);
        if (Physics.Raycast(ray, out hit, 30))
        {
            GameObject target = hit.collider.gameObject;
            target.transform.position = Vector3.MoveTowards(target.transform.position, me.transform.position, 5);
            bossTargets.addThreat(1, playerID);

        }
        cooldown.triggerCooldown(0, cooldown.abilityCooldowns[0]);

    }
    #endregion
    #region Healer Abilities
    public void HealerHeal()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 100, 1 << 8, QueryTriggerInteraction.Ignore);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            Health health = hitColliders[i].gameObject.GetComponent<Health>();
            health.modifyHealth(-20, 1);


        }
        bossTargets.addThreat(20, 1);
        cooldown.triggerCooldown(3, cooldown.abilityCooldowns[3]);

    }

    // Creates 2 spheres, one for finding players one for finding enemies, loops through both to add damage to both.
    public void HealerAbsorb()
    {
        int dam = 10;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 100, 1 << 8, QueryTriggerInteraction.Ignore);
        Collider[] EnemyColliders = Physics.OverlapSphere(transform.position, 100, enemyMask, QueryTriggerInteraction.Ignore);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            
            Health health = hitColliders[i].gameObject.GetComponent<Health>();
            print(health.health);
            health.modifyHealth(-dam / hitColliders.Length, 1);
            print(health.health);
        }
        for (int i = 0; i < EnemyColliders.Length; i++)
        {
            Health health = EnemyColliders[i].gameObject.GetComponent<Health>();
            print(EnemyColliders[i]);
            health.modifyHealth(dam, 1);
        }
        cooldown.triggerCooldown(4, cooldown.abilityCooldowns[4]);


    }
    #endregion
    #region Melee Abilities
    public void MeleeStrikeBerserker(float damage, int playerID, GameObject me, List<Collider> mtar, int attacknum, float CD)
    {
        
        
        for(int i = 0; i<mtar.Count; i++)
        {
            Health health = mtar[i].GetComponent<Health>();
            health.modifyHealth(damage, playerID);
        }

        cooldown.triggerCooldown(6, cooldown.abilityCooldowns[6]-(.05f*attacknum));

    }
    public void MeleeStrikeRogue(float damage, int playerID, GameObject me, List<Collider> mtar, int attacknum, float CD)
    {

        for (int i = 0; i < mtar.Count; i++)
        {
            Health health = mtar[i].GetComponent<Health>();
            health.modifyHealth(damage, playerID);
        }

        cooldown.triggerCooldown(6, cooldown.abilityCooldowns[6]);
    }

    public void Whirlwind(float damage, int playerID, GameObject me, float CD)
    {
        if(Physics.OverlapSphere(me.transform.position, 3, enemyMask, QueryTriggerInteraction.Ignore).Length > 0){
            StartCoroutine(WWAttack(damage, playerID, me, CD, 1f));
            cooldown.triggerCooldown(6, CD);
        }
    }
    public void MeleeLunge(float damage, int playerID, GameObject me, float CD)
    {
        RaycastHit hit;

        if(Physics.Raycast(me.transform.position, me.transform.forward * 20, out hit))
        {
            me.transform.position = Vector3.MoveTowards(me.transform.position, hit.point, 1000*Time.deltaTime);
           Health health = hit.collider.gameObject.GetComponent<Health>();
            health.modifyHealth(damage, playerID);
            if (health.health == 0)
            {
                CD = 0;
            }
        }
        //me.transform.position = Vector3.MoveTowards(me.transform.position, me.transform.position + (me.transform.forward * 100), 1000 * Time.deltaTime);
        cooldown.triggerCooldown(7, CD);

    }
    IEnumerator WWAttack(float damage, int playerID, GameObject me, float CD, float StrikeInterval)
    {
        Collider[] col = Physics.OverlapSphere(me.transform.position, 3, enemyMask, QueryTriggerInteraction.Ignore);
        for (int i = 0; i < col.Length; i++)
        {
            Health health = col[i].GetComponent<Health>();
           health.modifyHealth(damage, playerID);
        }
        print("WW1");
        yield return new WaitForSeconds(StrikeInterval);
        Collider[] col1 = Physics.OverlapSphere(me.transform.position, 3, enemyMask, QueryTriggerInteraction.Ignore);
        for (int i = 0; i < col1.Length; i++)
        {
            Health health = col[i].GetComponent<Health>();
            health.modifyHealth(damage, playerID);
        }
        print("WW2");
        yield return new WaitForSeconds(StrikeInterval);
        Collider[] col2 = Physics.OverlapSphere(me.transform.position, 3, enemyMask, QueryTriggerInteraction.Ignore);

        for (int i = 0; i < col2.Length; i++)
        {
            Health health = col[i].GetComponent<Health>();
            health.modifyHealth(damage, playerID);
        }
        print("WW3");
        yield return new WaitForSeconds(StrikeInterval);
    }
    // IEnumerator WW(float damage, int playerID, GameObject me, float CD)
    //{
    //    Collider[] col = Physics.OverlapSphere(me.transform.position, 3);
    //    for (int i = 0; i < col.Length; i++)
    //    {
    //        Health health = col[i].GetComponent<Health>();
    //        health.modifyHealth(damage, playerID);
    //    }
        
    //    yield return new WaitForSeconds(1);
    //}
    #endregion
    #region Ranged Abilities
    public void RangedBolt(float damage, int playerID, GameObject me, float CD)
    {

            GameObject clone = Instantiate(bolt, controller.IDs[3].gameObject.transform.position + (Vector3.forward * 2), controller.IDs[3].gameObject.transform.rotation);
            Destroy(clone, 3);
            cooldown.triggerCooldown(9, CD);
        
    }
    public void RangedArrow(float damage, int playerID, GameObject me, float CD)
    {
        

        GameObject clone = Instantiate(bolt, controller.IDs[3].gameObject.transform.position + (Vector3.forward * 2), controller.IDs[3].gameObject.transform.rotation);
        Destroy(clone, 3);
        cooldown.triggerCooldown(9,CD);
        print(damage);

    }
    //public void RangedRopeBolt(int playerID, GameObject target)
    //{
    //    if (cooldown.activeCooldowns[10] <= 0)
    //    {
    //        GameObject clone;
    //        clone = Instantiate(Resources.Load("RopeBolt", typeof(GameObject)), controller.IDs[3].gameObject.transform.position + (Vector3.forward * 2), Quaternion.identity) as GameObject;
    //        Destroy(clone, 3);
    //        cooldown.triggerCooldown(10, cooldown.abilityCooldowns[10]);


    //    }
    //}

    public void SmokeBomb()
    {

    }
    #endregion


}
