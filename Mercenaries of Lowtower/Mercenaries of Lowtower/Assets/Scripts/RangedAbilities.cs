using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAbilities : MonoBehaviour {

    RangedClass baseClass;


    #region Ranged Abilities
    public void RangedBolt()
    {

        GameObject clone = Instantiate(Resources.Load("Bolt") as GameObject, transform.position + (Vector3.forward * 2), transform.rotation);
        Destroy(clone, baseClass.boltRange);
        baseClass.abilityCooldowns.cooldowns["boltCD"] = baseClass.abilityCooldowns.boltCD;

    }
    //public void RangedArrow(float damage, int playerID, GameObject me, float CD, float arrowrange)
    //{


    //    GameObject clone = Instantiate(bolt, controller.IDs[3].gameObject.transform.position + (Vector3.forward * 2), controller.IDs[3].gameObject.transform.rotation);
    //    Destroy(clone, arrowrange);
    //    baseClass.abilityCooldowns.cooldowns["boltCD"] = baseClass.abilityCooldowns.boltCD;

    //}
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

    //public void SmokeBomb(float damage, int playerID, GameObject me, float CD, float cloudsize, float smokeduration, float dissipationrate)
    //{
    //    Collider[] col = Physics.OverlapSphere(me.transform.position, cloudsize, enemyMask, QueryTriggerInteraction.Ignore);
    //    GameObject smoke = Instantiate(Resources.Load("smoke"), me.transform.position, me.transform.rotation) as GameObject;
    //    smoke.transform.localScale = new Vector3(cloudsize, cloudsize, cloudsize);
    //    smoke.GetComponent<SmokeScript>().Dissipation(dissipationrate);
    //    smoke.GetComponent<Renderer>().material.SetColor("_Color", new Vector4(.5f, .5f, .5f, .6f));
    //    Destroy(smoke, smokeduration);
    //    for (int i = 0; i < col.Length; i++)
    //    {
    //        col[i].GetComponent<BossTargetingAI>().addThreat(-col[i].GetComponent<BossTargetingAI>().combinedThreat[playerID], playerID, true);
    //    }
    //    cooldown.triggerCooldown(10, CD);
    //}

    public void BluntTipArrow()
    {
        Quaternion rotation;
        rotation = baseClass.controller.players[3].gameObject.transform.rotation;

        GameObject clone = Instantiate(Resources.Load("BluntArrow") as GameObject, /*controller.IDs[3].gameObject.transform.position + (Vector3.forward * 2)*/ GameObject.Find("Bolt Spawn").transform.position, rotation /*controller.IDs[3].gameObject.transform.rotation*/);
        GameObject clone1 = Instantiate(Resources.Load("BluntArrow") as GameObject, /*controller.IDs[3].gameObject.transform.position + (Vector3.forward * 2)*/ GameObject.Find("Bolt Spawn").transform.position, rotation /*controller.IDs[3].gameObject.transform.rotation*/);
        clone1.transform.Rotate(0, baseClass.spread, 0);
        GameObject clone2 = Instantiate(Resources.Load("BluntArrow") as GameObject, /*controller.IDs[3].gameObject.transform.position + (Vector3.forward * 2)*/ GameObject.Find("Bolt Spawn").transform.position, rotation /*controller.IDs[3].gameObject.transform.rotation*/);
        clone2.transform.Rotate(0, -baseClass.spread, 0);

        Destroy(clone, baseClass.knockbackRange);

        baseClass.abilityCooldowns.cooldowns["knockbackCD"] = baseClass.abilityCooldowns.knockbackCD;

    }
    #endregion
}
