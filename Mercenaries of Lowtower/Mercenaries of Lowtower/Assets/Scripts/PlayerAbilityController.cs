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
    int reviveCounter;
    #endregion

    // Use this for initialization
    void Start()
    {
        cooldown = GetComponent<PlayerCDController>();
        controller = GetComponent<ControllerThing>();




    }
    private void Update()
    {
        bossTargets = GameObject.Find("Boss").GetComponent<BossTargetingAI>();

    }

    #region General Abilities
    public void Jump(int PlayerID, GameObject player, float jumpheight)
    {
        player.GetComponent<Rigidbody>().AddForce(0, jumpheight, 0, ForceMode.Impulse);
    }

    public void Revive(int playerID, GameObject me, float reviveradius)
    {
        Collider[] col = Physics.OverlapSphere(me.transform.position, reviveradius, 1 << 8, QueryTriggerInteraction.Ignore);
        for (int i = 0; i < col.Length; i++)
        {
            print(col[i]);
        }
        Health colhealth = col[0].GetComponent<Health>();

        if (playerID != 1 && colhealth.isDead)
        {
            colhealth.health = colhealth.maxHealth / 2;
            colhealth.isDead = false;


        }
        else if (playerID == 1 && colhealth.isDead)
        {
            colhealth.health = colhealth.maxHealth;
            colhealth.isDead = false;


        }






    }
    #endregion
    #region Tank Abilities
    public void TankShield(float damage, int playerID, GameObject me, float CD, float duration, bool infiniteshield, float shieldsize)
    {
        GameObject clone;
        clone = Instantiate(Resources.Load("Shield_Magnetable"), me.transform.position, me.transform.rotation) as GameObject;
        clone.transform.localScale = new Vector3(shieldsize, shieldsize, shieldsize);


        if (!infiniteshield)
        {
            Destroy(clone, duration + 1);

        }
        cooldown.abilityCooldowns[1] = CD;
        cooldown.triggerCooldown(1, CD);


    }

    public void TankPerfectShield(float damage, int playerID, GameObject me, float CD, float duration, float dodgeradius)
    {
        GameObject clone;
        clone = Instantiate(Resources.Load("shield"), me.transform.position, me.transform.rotation) as GameObject;
        clone.transform.localScale = new Vector3(dodgeradius, dodgeradius, dodgeradius);
        Destroy(clone, duration);
        cooldown.triggerCooldown(1, CD);

    }
    public void TankMagnet(float damage, int playerID, GameObject me, float CD, LayerMask lMask, float magnetdistance, float pullspeed)
    {

        RaycastHit hit;
        //Ray ray = new Ray(me.transform.position, me.transform.forward * 30);
        //if (Physics.Raycast(ray, out hit, 30))
        if (Physics.Raycast(me.transform.position, me.transform.forward, out hit, magnetdistance, lMask))
        {
            GameObject target = hit.collider.gameObject;
            if (Vector3.Distance(target.transform.position, me.transform.position) > 3)
            {
                target.transform.position = Vector3.MoveTowards(new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z), new Vector3(me.transform.position.x, target.transform.position.y, me.transform.position.z), pullspeed);
                bossTargets.addThreat(damage, playerID, false);
            }


        }


    }

    public void TankReflect(float damage, int playerID, GameObject me, float CD, bool reflect, float health1, float health2, float timer, float reflectdistance, float beamwidth, float damagemultiplier)
    {

        if (reflect)
        {
            if (health1 < health2)
            {
                damage = (health2 - health1) * damagemultiplier;
                //if (timer > 2)
                //{
                Collider[] col = Physics.OverlapCapsule(me.transform.position, me.transform.forward * reflectdistance, beamwidth, enemyMask, QueryTriggerInteraction.Ignore);
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
                reflect = false;
                //}
            }
        }
        else
        {

        }
    }
    #endregion
    #region Healer Abilities
    public void HealerHeal(float damage, int playerID, GameObject me, float CD, GameObject beepboop, float range)
    {
        Collider[] hitColliders = Physics.OverlapSphere(me.transform.position, range, 1 << 8, QueryTriggerInteraction.Ignore);

        Destroy(beepboop.GetComponent<CapsuleCollider>());
        beepboop.transform.position = me.transform.position - new Vector3(0, 1, 0);
        beepboop.transform.localScale = new Vector3(range, 1, range);
        beepboop.transform.parent = me.transform;

        for (int i = 0; i < hitColliders.Length; i++)
        {
            Health health = hitColliders[i].gameObject.GetComponent<Health>();
            if (!health.isDead)
                health.modifyHealth(damage, 1);


        }



    }

    public void Healaport(float damage, int playerID, GameObject me, float CD, float teleportrange)
    {
        RaycastHit hit;
        Debug.DrawRay(me.transform.position, me.transform.forward * (teleportrange / 2));
        if (Physics.Raycast(me.transform.position, me.transform.forward, out hit, teleportrange, 1 << 8, QueryTriggerInteraction.Ignore))
        {
            me.transform.position = hit.point;
            cooldown.triggerCooldown(4, CD);

        }

    }

    public void HealerCC(float damage, int playerID, GameObject me, float CD, float fearrange, float runspeed, float fearduration)
    {
        //fear
        Collider[] EnemyColliders = Physics.OverlapSphere(me.transform.position, fearrange, enemyMask, QueryTriggerInteraction.Ignore);
        for (int i = 0; i < EnemyColliders.Length; i++)
        {
            //EnemyColliders[i].gameObject.transform.Translate((EnemyColliders[i].gameObject.transform.position - me.transform.position) * 3);            
            EnemyColliders[i].gameObject.GetComponent<FearScript>().Fear(me, runspeed, fearduration);

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

    public void Whirlwind(float damage, int playerID, GameObject me, float CD, float strikeinterval)
    {
        //Physics.OverlapSphere(me.transform.position, 3, enemyMask, QueryTriggerInteraction.Ignore);

        StartCoroutine(WWAttack(damage, playerID, me, CD, strikeinterval));
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
    public void MeleeLunge(float damage, int playerID, GameObject me, float CD, float lungedistance)
    {
        RaycastHit hit;

        if (Physics.Raycast(me.transform.position, me.transform.forward, out hit, lungedistance, enemyMask, QueryTriggerInteraction.Ignore))
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
            yield return new WaitForSeconds(.01f);
        }
        else
        {
            yield break;
        }
        if (Physics.Raycast(me.transform.position, me.transform.forward, 1) == false)
        {
            me.transform.position = Vector3.Lerp(me.transform.position, me.transform.position + (me.transform.forward * 1), 1);
            yield return new WaitForSeconds(.01f);
        }
        else
        {
            yield break;
        }
    }

    IEnumerator WWAttack(float damage, int playerID, GameObject me, float CD, float strikeinterval)
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
        yield return new WaitForSeconds(strikeinterval);
        Collider[] col1 = Physics.OverlapSphere(me.transform.position, 3, enemyMask, QueryTriggerInteraction.Ignore);
        for (int i = 0; i < col1.Length; i++)
        {
            Health health = col1[i].GetComponent<Health>();
            health.modifyHealth(damage, playerID);
        }
        print("WW2");
        yield return new WaitForSeconds(strikeinterval);
        Collider[] col2 = Physics.OverlapSphere(me.transform.position, 3, enemyMask, QueryTriggerInteraction.Ignore);

        for (int i = 0; i < col2.Length; i++)
        {
            Health health = col2[i].GetComponent<Health>();
            health.modifyHealth(damage, playerID);
        }
        print("WW3");
        me.GetComponent<MeleeController>().walkspeed = 10;

        Destroy(wwcyl);
        yield return new WaitForSeconds(strikeinterval);
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
    public void RangedBolt(float damage, int playerID, GameObject me, float CD, float boltrange)
    {

        GameObject clone = Instantiate(bolt, controller.IDs[3].gameObject.transform.position + (Vector3.forward * 2), controller.IDs[3].gameObject.transform.rotation);
        Destroy(clone, boltrange);
        cooldown.triggerCooldown(9, CD);

    }
    public void RangedArrow(float damage, int playerID, GameObject me, float CD, float arrowrange)
    {


        GameObject clone = Instantiate(bolt, controller.IDs[3].gameObject.transform.position + (Vector3.forward * 2), controller.IDs[3].gameObject.transform.rotation);
        Destroy(clone, arrowrange);
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

    public void SmokeBomb(float damage, int playerID, GameObject me, float CD, float cloudsize, float smokeduration, float dissipationrate)
    {
        Collider[] col = Physics.OverlapSphere(me.transform.position, cloudsize, enemyMask, QueryTriggerInteraction.Ignore);
        GameObject smoke = Instantiate(Resources.Load("smoke"), me.transform.position, me.transform.rotation) as GameObject;
        smoke.transform.localScale = new Vector3(cloudsize, cloudsize, cloudsize);
        smoke.GetComponent<SmokeScript>().Dissipation(dissipationrate);
        smoke.GetComponent<Renderer>().material.SetColor("_Color", new Vector4(.5f, .5f, .5f, .6f));
        Destroy(smoke, smokeduration);
        for (int i = 0; i < col.Length; i++)
        {
            col[i].GetComponent<BossTargetingAI>().addThreat(-col[i].GetComponent<BossTargetingAI>().combinedThreat[playerID], playerID, true);
        }
        cooldown.triggerCooldown(10, CD);
    }

    public void BluntTipArrow(float damage, int playerID, GameObject me, float CD, float knockbackrange, float spread)
    {
        Quaternion rotation;
        rotation = controller.IDs[3].gameObject.transform.rotation;

        GameObject clone = Instantiate(Resources.Load("BluntArrow") as GameObject, /*controller.IDs[3].gameObject.transform.position + (Vector3.forward * 2)*/ GameObject.Find("Bolt Spawn").transform.position, rotation /*controller.IDs[3].gameObject.transform.rotation*/);
        GameObject clone1 = Instantiate(Resources.Load("BluntArrow") as GameObject, /*controller.IDs[3].gameObject.transform.position + (Vector3.forward * 2)*/ GameObject.Find("Bolt Spawn").transform.position, rotation /*controller.IDs[3].gameObject.transform.rotation*/);
        clone1.transform.Rotate(0, spread, 0);
        GameObject clone2 = Instantiate(Resources.Load("BluntArrow") as GameObject, /*controller.IDs[3].gameObject.transform.position + (Vector3.forward * 2)*/ GameObject.Find("Bolt Spawn").transform.position, rotation /*controller.IDs[3].gameObject.transform.rotation*/);
        clone2.transform.Rotate(0, -spread, 0);

        Destroy(clone, knockbackrange);

        cooldown.triggerCooldown(11, CD);

    }
    #endregion


}
