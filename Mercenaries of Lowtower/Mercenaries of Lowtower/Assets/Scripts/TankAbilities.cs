using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAbilities : MonoBehaviour
{
    TankClass baseClass;


    #region Tank Abilities
    public void TankShield()
    {
        GameObject clone;
        clone = Instantiate(Resources.Load("Shield_Magnetable"), transform.position, transform.rotation) as GameObject;
        clone.transform.localScale = new Vector3(baseClass.shieldSize, baseClass.shieldSize, baseClass.shieldSize);
        Destroy(clone, baseClass.shieldDuration);        
        baseClass.abilityCooldowns.cooldowns["shieldCD"] = baseClass.abilityCooldowns.shieldCD;



    }

    //public void TankPerfectShield(float damage, int playerID, GameObject me, float CD, float duration, float dodgeradius)
    //{
    //    GameObject clone;
    //    clone = Instantiate(Resources.Load("shield"), me.transform.position, me.transform.rotation) as GameObject;
    //    clone.transform.localScale = new Vector3(dodgeradius, dodgeradius, dodgeradius);
    //    Destroy(clone, duration);
    //    cooldown.triggerCooldown(1, CD);

    //}
    public void TankMagnet()
    {

        Collider[] col = Physics.OverlapCapsule(transform.position, transform.position + (transform.forward * baseClass.magnetDistance), baseClass.magnetDiameter, baseClass.lMask, QueryTriggerInteraction.Collide);
        Debug.DrawLine(transform.position, transform.position + (transform.forward * baseClass.magnetDistance));
        for (int i = 0; i < col.Length; i++)
        {
            if (Vector3.Distance(col[i].gameObject.transform.position, transform.position) > 5)
            {

                col[i].gameObject.transform.position = Vector3.MoveTowards(new Vector3(col[i].gameObject.transform.position.x, col[i].gameObject.transform.position.y, col[i].gameObject.transform.position.z), new Vector3(transform.position.x, col[i].gameObject.transform.position.y, transform.position.z), baseClass.pullSpeed);
            }
        }

        //RaycastHit hit;
        ////Ray ray = new Ray(me.transform.position, me.transform.forward * 30);
        ////if (Physics.Raycast(ray, out hit, 30))



        //if (Physics.Raycast(me.transform.position, me.transform.forward, out hit, magnetdistance, lMask))
        //{
        //    GameObject target = hit.collider.gameObject;
        //    if (Vector3.Distance(target.transform.position, me.transform.position) > 3)
        //    {
        //        target.transform.position = Vector3.MoveTowards(new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z), new Vector3(me.transform.position.x, target.transform.position.y, me.transform.position.z), pullspeed);
        //        bossTargets.addThreat(damage, playerID, false);
        //    }


        //}


    }

    //public void TankReflect(float damage, int playerID, GameObject me, float CD, bool reflect, float health1, float health2, float timer, float reflectdistance, float beamwidth, float damagemultiplier)
    //{

    //    if (reflect)
    //    {
    //        if (health1 < health2)
    //        {
    //            damage = (health2 - health1) * damagemultiplier;
    //            //if (timer > 2)
    //            //{
    //            Collider[] col = Physics.OverlapCapsule(me.transform.position, me.transform.forward * reflectdistance, beamwidth, enemyMask, QueryTriggerInteraction.Ignore);
    //            GameObject cap = GameObject.CreatePrimitive(PrimitiveType.Capsule);
    //            Destroy(cap.GetComponent<CapsuleCollider>());
    //            cap.transform.position = me.transform.position + me.transform.forward * 10;
    //            cap.transform.rotation = me.transform.rotation * Quaternion.Euler(90, 0, 0);
    //            cap.transform.localScale = new Vector3(1, 10, 1);
    //            cap.transform.parent = me.transform;
    //            Destroy(cap, 1);
    //            for (int i = 0; i < col.Length; i++)
    //            {
    //                col[i].GetComponent<Health>().health -= damage;
    //            }
    //            reflect = false;
    //            //}
    //        }
    //    }
    //    else
    //    {

    //    }
    //}
    #endregion

}