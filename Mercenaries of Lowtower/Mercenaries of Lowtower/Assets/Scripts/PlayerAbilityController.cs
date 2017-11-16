using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityController : MonoBehaviour
{
    #region Variables
    ControllerThing controller;
    public BossTargetingAI bossTargets;
    PlayerCDController cooldown;
    public GameObject bolt;
    public GameObject P2BoltSpawn;
    public LayerMask enemyMask;
    #endregion

    // Use this for initialization
    void Start()
    {
        cooldown = GetComponent<PlayerCDController>();
        controller = GetComponent<ControllerThing>();

        if (GameObject.Find("Boss") == null)
        {

        }
        else
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
    public void TankShield(float damage, int playerID, GameObject me, float CD, float duration, bool infiniteshield)
    {
        GameObject clone;
        clone = Instantiate(Resources.Load("Shield_Magnetable"), me.transform.position, me.transform.rotation) as GameObject;

        if (!infiniteshield)
        {
            Destroy(clone, duration);

        }
        cooldown.abilityCooldowns[1] = CD;
        cooldown.triggerCooldown(1, CD);

    }

    public void TankPerfectShield(float damage, int playerID, GameObject me, float CD, float duration)
    {
        GameObject clone;
        clone = Instantiate(Resources.Load("shield"), me.transform.position, me.transform.rotation) as GameObject;
        clone.transform.localScale = new Vector3(5f, 5f, 5f);
        Destroy(clone, duration);
        cooldown.triggerCooldown(1, CD);

    }
    public void TankMagnet(float damage, int playerID, GameObject me, float CD, LayerMask lMask)
    {

        RaycastHit hit;
        //Ray ray = new Ray(me.transform.position, me.transform.forward * 30);
        //if (Physics.Raycast(ray, out hit, 30))
        if (Physics.Raycast(me.transform.position, me.transform.forward, out hit, 30, lMask))
        {
            GameObject target = hit.collider.gameObject;
            if (Vector3.Distance(target.transform.position, me.transform.position) > 3)
            {
                target.transform.position = Vector3.MoveTowards(target.transform.position, me.transform.position, .25f);
                bossTargets.addThreat(damage, playerID, false);
            }


        }
        cooldown.triggerCooldown(0, CD);

    }

    public void TankReflect(float damage, int playerID, GameObject me, float CD, bool reflect, float health1, float health2, float timer)
    {

        if (reflect)
        {
            if (health1 < health2)
            {
                damage = (health2 - health1) * 2;
                //if (timer > 2)
                //{
                Collider[] col = Physics.OverlapCapsule(me.transform.position, me.transform.forward * 20, .5f, enemyMask, QueryTriggerInteraction.Ignore);
                GameObject cap = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                Destroy(cap.GetComponent<CapsuleCollider>());
                cap.transform.position = me.transform.position + me.transform.forward * 10;
                cap.transform.rotation = me.transform.rotation * Quaternion.Euler(90, 0, 0);
                cap.transform.localScale = new Vector3(1, 10, 1);
                cap.transform.parent = me.transform;
                Destroy(cap, 1);
                for (int i = 0; i < col.Length; i++)
                {
                    col[i].GetComponent<Health>().health -= damage;
                }

                //}
            }
            cooldown.abilityCooldowns[2] = CD;
            cooldown.triggerCooldown(2, CD);
        }
        else
        {

        }
    }
    #endregion
    #region Healer Abilities
    public void HealerHeal(float damage, int playerID, GameObject me, float CD, GameObject beepboop, float range)
    {
        Collider[] hitColliders = Physics.OverlapSphere(me.transform.position, 100, 1 << 8, QueryTriggerInteraction.Ignore);

        Destroy(beepboop.GetComponent<CapsuleCollider>());
        beepboop.transform.position = me.transform.position - new Vector3(0, 1, 0);
        beepboop.transform.localScale = new Vector3(100, 1, 100);
        beepboop.transform.parent = me.transform;

        for (int i = 0; i < hitColliders.Length; i++)
        {
            Health health = hitColliders[i].gameObject.GetComponent<Health>();
            health.modifyHealth(damage, 1);


        }

        cooldown.triggerCooldown(3, CD);

    }

    public void Healaport(float damage, int playerID, GameObject me, float CD)
    {
        RaycastHit hit;
        Debug.DrawRay(me.transform.position, me.transform.forward * 10);
        if (Physics.Raycast(me.transform.position, me.transform.forward, out hit, 20, 1 << 8, QueryTriggerInteraction.Ignore))
        {
            me.transform.position = hit.point;
        }
        cooldown.triggerCooldown(4, CD);

    }

    public void HealerCC(float damage, int playerID, GameObject me, float CD)
    {
        //fear
        Collider[] EnemyColliders = Physics.OverlapSphere(transform.position, 100, enemyMask, QueryTriggerInteraction.Ignore);
        for (int i = 0; i < EnemyColliders.Length; i++)
        {
            EnemyColliders[i].gameObject.transform.Translate((EnemyColliders[i].gameObject.transform.position - me.transform.position) * 3);
        }

        cooldown.triggerCooldown(5, CD);
    }

    // Creates 2 spheres, one for finding players one for finding enemies, loops through both to add damage to both.
    public void HealerAbsorb(float damage, int playerID, GameObject me, float CD)
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
        cooldown.triggerCooldown(4, CD);


    }
    #endregion
    #region Melee Abilities
    public void MeleeStrikeBerserker(float damage, int playerID, GameObject me, List<Collider> mtar, int attacknum, float CD, int attacknummax, float speedinterval)
    {


        for (int i = 0; i < mtar.Count; i++)
        {
            Health health = mtar[i].GetComponent<Health>();
            health.modifyHealth(damage, playerID);
        }

        cooldown.triggerCooldown(6, CD - (speedinterval * Mathf.Clamp(attacknum, 0, attacknummax)));

    }
    public void MeleeStrikeRogue(float damage, int playerID, GameObject me, List<Collider> mtar, int attacknum, float CD)
    {

        for (int i = 0; i < mtar.Count; i++)
        {
            Health health = mtar[i].GetComponent<Health>();
            health.modifyHealth(damage, playerID);
        }

        cooldown.triggerCooldown(6, CD);
    }

    public void Whirlwind(float damage, int playerID, GameObject me, float CD)
    {
        //Physics.OverlapSphere(me.transform.position, 3, enemyMask, QueryTriggerInteraction.Ignore);

        StartCoroutine(WWAttack(damage, playerID, me, CD, 1f));
        cooldown.triggerCooldown(7, CD);
        //} else
        //{
        //    GameObject wwcyl = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        //    Destroy(wwcyl.GetComponent<CapsuleCollider>());
        //    wwcyl.transform.position = me.transform.position - new Vector3(0, 1, 0);
        //    wwcyl.transform.localScale = new Vector3(3, .5f, 3);
        //    wwcyl.transform.parent = me.transform;
        //    Destroy(wwcyl, 3f);
        //}
    }
    public void MeleeLunge(float damage, int playerID, GameObject me, float CD)
    {
        RaycastHit hit;

        if (Physics.Raycast(me.transform.position, me.transform.forward, out hit, 20, enemyMask, QueryTriggerInteraction.Ignore))
        {
            me.transform.position = Vector3.MoveTowards(me.transform.position, hit.point, 1000 * Time.deltaTime);
            Health health = hit.collider.gameObject.GetComponent<Health>();
            health.modifyHealth(damage, playerID);
            if (health.health <= 0)
            {
                CD = 0;
            }
        }
        else
        {
            //me.transform.position = Vector3.Lerp(me.transform.position, me.transform.position + (me.transform.forward * 10), 1);
            StartCoroutine(Dash(me));

        }
        //me.transform.position = Vector3.MoveTowards(me.transform.position, me.transform.position + (me.transform.forward * 100), 1000 * Time.deltaTime);
        cooldown.triggerCooldown(8, CD);

    }

    IEnumerator Dash(GameObject me)
    {
        if (Physics.Raycast(me.transform.position, me.transform.forward, 1) == false)
        {
            me.transform.position = Vector3.Lerp(me.transform.position, me.transform.position + (me.transform.forward * 1), 1);
            yield return new WaitForSeconds(.01f);
        }
        else
        {
            yield break;
        }
        if (Physics.Raycast(me.transform.position, me.transform.forward, 2) == false)
        {
            me.transform.position = Vector3.Lerp(me.transform.position, me.transform.position + (me.transform.forward * 2), 1);
            yield return new WaitForSeconds(.01f);
        }
        else
        {
            yield break;
        }
        if (Physics.Raycast(me.transform.position, me.transform.forward, 4) == false)
        {
            me.transform.position = Vector3.Lerp(me.transform.position, me.transform.position + (me.transform.forward * 4), 1);
            yield return new WaitForSeconds(.01f);
        }
        else
        {
            yield break;
        }
        if (Physics.Raycast(me.transform.position, me.transform.forward, 6) == false)
        {
            me.transform.position = Vector3.Lerp(me.transform.position, me.transform.position + (me.transform.forward * 6), 1);
            yield return new WaitForSeconds(.01f);
        }
        else
        {
            yield break;
        }
        if (Physics.Raycast(me.transform.position, me.transform.forward, 6) == false)
        {
            me.transform.position = Vector3.Lerp(me.transform.position, me.transform.position + (me.transform.forward * 6), 1);
            yield return new WaitForSeconds(.01f);
        }
        else
        {
            yield break;
        }
        if (Physics.Raycast(me.transform.position, me.transform.forward, 6) == false)
        {
            me.transform.position = Vector3.Lerp(me.transform.position, me.transform.position + (me.transform.forward * 6), 1);
            yield return new WaitForSeconds(.01f);
        }
        else
        {
            yield break;
        }
        if (Physics.Raycast(me.transform.position, me.transform.forward, 4) == false)
        {
            me.transform.position = Vector3.Lerp(me.transform.position, me.transform.position + (me.transform.forward * 4), 1);
            yield return new WaitForSeconds(.01f);
        }
        else
        {
            yield break;
        }
        if (Physics.Raycast(me.transform.position, me.transform.forward, 2) == false)
        {
            me.transform.position = Vector3.Lerp(me.transform.position, me.transform.position + (me.transform.forward * 2), 1);
            yield return new WaitForSeconds(.1f);
        }
        else
        {
            yield break;
        }
        if (Physics.Raycast(me.transform.position, me.transform.forward, 1) == false)
        {
            me.transform.position = Vector3.Lerp(me.transform.position, me.transform.position + (me.transform.forward * 1), 1);
            yield return new WaitForSeconds(.1f);
        }
        else
        {
            yield break;
        }
    }

    IEnumerator WWAttack(float damage, int playerID, GameObject me, float CD, float StrikeInterval)
    {
        Collider[] col = Physics.OverlapSphere(me.transform.position, 3, enemyMask, QueryTriggerInteraction.Ignore);
        me.GetComponent<MeleeController>().walkspeed = 15;
        GameObject wwcyl = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        Destroy(wwcyl.GetComponent<CapsuleCollider>());
        wwcyl.transform.position = me.transform.position - new Vector3(0, 1, 0);
        wwcyl.transform.localScale = new Vector3(3, .5f, 3);
        wwcyl.transform.parent = me.transform;
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
        me.GetComponent<MeleeController>().walkspeed = 10;

        Destroy(wwcyl);
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
        cooldown.triggerCooldown(9, CD);

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

    public void SmokeBomb(float damage, int playerID, GameObject me, float CD)
    {
        Collider[] col = Physics.OverlapSphere(me.transform.position, 10, enemyMask, QueryTriggerInteraction.Ignore);
        GameObject smoke = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        Destroy(smoke.GetComponent<SphereCollider>());
        smoke.transform.localScale = new Vector3(10, 10, 10);
        smoke.transform.position = me.transform.position;
        smoke.GetComponent<Renderer>().material.SetColor("_Color", new Vector4(.5f, .5f, .5f, .6f));
        Destroy(smoke, 5);
        for (int i = 0; i < col.Length; i++)
        {
            col[i].GetComponent<BossTargetingAI>().addThreat(-col[i].GetComponent<BossTargetingAI>().combinedThreat[playerID], playerID, true);
        }
        cooldown.triggerCooldown(10, CD);
    }

    public void BluntTipArrow(float damage, int playerID, GameObject me, float CD)
    {
        Quaternion rotation;
        rotation = controller.IDs[3].gameObject.transform.rotation;

        GameObject clone = Instantiate(Resources.Load("BluntArrow") as GameObject, /*controller.IDs[3].gameObject.transform.position + (Vector3.forward * 2)*/ GameObject.Find("Bolt Spawn").transform.position, rotation /*controller.IDs[3].gameObject.transform.rotation*/);
        GameObject clone1 = Instantiate(Resources.Load("BluntArrow") as GameObject, /*controller.IDs[3].gameObject.transform.position + (Vector3.forward * 2)*/ GameObject.Find("Bolt Spawn").transform.position, rotation /*controller.IDs[3].gameObject.transform.rotation*/);
        clone1.transform.Rotate(0, 5, 0);
        GameObject clone2 = Instantiate(Resources.Load("BluntArrow") as GameObject, /*controller.IDs[3].gameObject.transform.position + (Vector3.forward * 2)*/ GameObject.Find("Bolt Spawn").transform.position, rotation /*controller.IDs[3].gameObject.transform.rotation*/);
        clone2.transform.Rotate(0, -5, 0);

        Destroy(clone, 3);

        cooldown.triggerCooldown(11, CD);

    }
    #endregion


}
