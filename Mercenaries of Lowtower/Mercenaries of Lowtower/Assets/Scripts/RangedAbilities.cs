using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAbilities : MonoBehaviour {

    RangedClass baseClass;

    private void Awake()
    {
        baseClass = GetComponent<RangedClass>();
    }
    #region Ranged Abilities
    public void RangedBolt()
    {
        if (baseClass.abilityCooldowns.cooldowns["boltCD"] <= 0)
        {
            GameObject clone = Instantiate(Resources.Load("CrossbowBolt") as GameObject, baseClass.boltspawn.transform.position, transform.rotation);
            Destroy(clone, baseClass.boltRange);
            baseClass.abilityCooldowns.cooldowns["boltCD"] = baseClass.abilityCooldowns.boltCD;
            GetComponent<Animator>().SetInteger("AnimState", 5);

        }
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
        if (baseClass.abilityCooldowns.cooldowns["knockbackCD"] <=0) {
            Quaternion rotation;
            rotation = baseClass.controller.players[3].gameObject.transform.rotation;

            GameObject clone = Instantiate(Resources.Load("BluntArrow") as GameObject,  baseClass.boltspawn.transform.position, rotation );
            GameObject clone1 = Instantiate(Resources.Load("BluntArrow") as GameObject,  baseClass.boltspawn.transform.position, rotation );
            clone1.transform.Rotate(0, baseClass.spread, 0);
            GameObject clone2 = Instantiate(Resources.Load("BluntArrow") as GameObject, baseClass.boltspawn.transform.position, rotation);
            clone2.transform.Rotate(0, -baseClass.spread, 0);

            Destroy(clone, baseClass.knockbackRange);
            GetComponent<Animator>().SetInteger("AnimState", 5);

            baseClass.abilityCooldowns.cooldowns["knockbackCD"] = baseClass.abilityCooldowns.knockbackCD;
        }
    }
    #endregion
}
