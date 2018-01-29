using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealerAbilities : MonoBehaviour
{


    HealerClass baseClass;

    private void Awake()
    {
        baseClass = GetComponent<HealerClass>();
    }

    private void Update()
    {
        if (Input.GetKey("joystick " + baseClass.CTRLID + " button 2"))
        {

            if (Input.GetAxis("J" + baseClass.CTRLID + "Horizontal") > -1 && Input.GetAxis("J" + baseClass.CTRLID + "Horizontal") < 0)
            {
                if (Input.GetAxis("J" + baseClass.CTRLID + "Vertical") > 0 && Input.GetAxis("J" + baseClass.CTRLID + "Vertical") < 1)
                {
                    baseClass.healObject = baseClass.controller.players[0];
                    // transform.rotation = Quaternion.LookRotation(controller.IDs[0].gameObject.transform.position);
                    transform.LookAt(baseClass.controller.players[0].transform);

                    print(baseClass.healObject);
                }

            }
            if (Input.GetAxis("J" + baseClass.CTRLID + "Horizontal") > 0 && Input.GetAxis("J" + baseClass.CTRLID + "Horizontal") < 1)
            {
                if (Input.GetAxis("J" + baseClass.CTRLID + "Vertical") > 0 && Input.GetAxis("J" + baseClass.CTRLID + "Vertical") < 1)
                {
                    baseClass.healObject = baseClass.controller.players[1];
                    //transform.rotation = Quaternion.LookRotation(controller.IDs[1].gameObject.transform.position);
                    transform.LookAt(baseClass.controller.players[1].transform);


                    print(baseClass.healObject);
                }

            }
            if (Input.GetAxis("J" + baseClass.CTRLID + "Horizontal") > -1 && Input.GetAxis("J" + baseClass.CTRLID + "Horizontal") < 0)
            {
                if (Input.GetAxis("J" + baseClass.CTRLID + "Vertical") < 0 && Input.GetAxis("J" + baseClass.CTRLID + "Vertical") > -1)
                {
                    baseClass.healObject = baseClass.controller.players[2];
                    //transform.rotation = Quaternion.LookRotation(controller.IDs[2].gameObject.transform.position);
                    transform.LookAt(baseClass.controller.players[2].transform);


                    print(baseClass.healObject);
                }

            }
            if (Input.GetAxis("J" + baseClass.CTRLID + "Horizontal") > 0 && Input.GetAxis("J" + baseClass.CTRLID + "Horizontal") < 1)
            {
                if (Input.GetAxis("J" + baseClass.CTRLID + "Vertical") < 0 && Input.GetAxis("J" + baseClass.CTRLID + "Vertical") > -1)
                {
                    baseClass.healObject = baseClass.controller.players[3];
                    //transform.rotation = Quaternion.LookRotation(controller.IDs[3].gameObject.transform.position);
                    transform.LookAt(baseClass.controller.players[3].transform);


                    print(baseClass.healObject);
                }

            }

        }
        if (Input.GetKeyUp("joystick " + baseClass.CTRLID + " button 2") && baseClass.abilityCooldowns.cooldowns["healCD"] <= 0)
        {
            baseClass.healTarget = baseClass.healObject;

            baseClass.abilities.TargetedHeal();
            baseClass.stopTimer = 0;
        }
    }

    //    public void HealerHeal()
    //    {
    //        Collider[] hitColliders = Physics.OverlapSphere(me.transform.position, range, 1 << 8, QueryTriggerInteraction.Ignore);

    //        Destroy(beepboop.GetComponent<CapsuleCollider>());
    //        beepboop.transform.position = me.transform.position - new Vector3(0, 1, 0);
    //        beepboop.transform.localScale = new Vector3(range, 1, range);
    //        beepboop.transform.parent = me.transform;

    //        for (int i = 0; i < hitColliders.Length; i++)
    //        {
    //            Health health = hitColliders[i].gameObject.GetComponent<Health>();
    //            if (!health.isDead)
    //                health.modifyHealth(damage, 1);


    //        }



    //    }

    public void Healaport()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * (baseClass.teleportDistance / 2));
        if (Physics.Raycast(transform.position, transform.forward, out hit, baseClass.teleportDistance, 1 << 8, QueryTriggerInteraction.Ignore))
        {
            transform.position = hit.point;
            baseClass.abilityCooldowns.cooldowns["teleportCD"] = baseClass.abilityCooldowns.teleportCD;

        }

    }

    //    public void HealerCC()
    //    {
    //        //fear
    //        Collider[] EnemyColliders = Physics.OverlapSphere(me.transform.position, fearrange, enemyMask, QueryTriggerInteraction.Ignore);
    //        for (int i = 0; i < EnemyColliders.Length; i++)
    //        {
    //            //EnemyColliders[i].gameObject.transform.Translate((EnemyColliders[i].gameObject.transform.position - me.transform.position) * 3);            
    //            EnemyColliders[i].gameObject.GetComponent<FearScript>().Fear(me, runspeed, fearduration);

    //        }

    //        cooldown.triggerCooldown(5, CD);
    //    }

    //    // Creates 2 spheres, one for finding players one for finding enemies, loops through both to add damage to both.
    //    public void HealerAbsorb()
    //    {
    //        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 100, 1 << 8, QueryTriggerInteraction.Ignore);
    //        Collider[] EnemyColliders = Physics.OverlapSphere(transform.position, 100, enemyMask, QueryTriggerInteraction.Ignore);
    //        for (int i = 0; i < hitColliders.Length; i++)
    //        {

    //            Health health = hitColliders[i].gameObject.GetComponent<Health>();
    //            print(health.health);
    //            health.modifyHealth(-damage / hitColliders.Length, 1);
    //            print(health.health);
    //        }
    //        for (int i = 0; i < EnemyColliders.Length; i++)
    //        {
    //            Health health = EnemyColliders[i].gameObject.GetComponent<Health>();
    //            print(EnemyColliders[i]);
    //            health.modifyHealth(damage, 1);
    //        }
    //        cooldown.triggerCooldown(4, CD);


    //    }

    public void TargetedHeal()
    {

        GameObject Horb = Resources.Load("Healing Orb") as GameObject;
        GameObject clone = Instantiate(Horb, transform.position, Quaternion.identity);

        clone.GetComponent<Orbscript>().OrbBehavior(gameObject, baseClass.healTarget, baseClass.healAmount, baseClass.orbSpeed, baseClass.CTRLID);
        baseClass.abilityCooldowns.cooldowns["healCD"] = baseClass.abilityCooldowns.healCD;
    }


}
