﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAbilities : MonoBehaviour {

    MeleeClass baseClass;

    private void Awake()
    {
        baseClass = GetComponent<MeleeClass>();
    }

    public void Smoke()
    {
        Instantiate(Resources.Load("smoke"), transform.position, Quaternion.identity);
    }

    public void MeleeStrikeRogue()
    {
        //MOVE TARGET LIST INTO CONTROLLER
        for (int i = 0; i < baseClass.targetList.mTar.Count; i++)
        {
            Health health = baseClass.targetList.mTar[i].GetComponent<Health>();
            health.modifyHealth(baseClass.meleeDamage, baseClass.CTRLID);
        }

        baseClass.abilityCooldowns.cooldowns["meleeCD"] = baseClass.abilityCooldowns.meleeCD;
    }

    public void MeleeLunge()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, baseClass.lungeDistance, baseClass.enemyMask, QueryTriggerInteraction.Ignore))
        {
            transform.position = Vector3.MoveTowards(transform.position, hit.point, 1000 * Time.deltaTime);
            Health health = hit.collider.gameObject.GetComponent<Health>();
            health.modifyHealth(baseClass.lungeDamage, baseClass.CTRLID);
            if (health.health <= 0)
            {
                baseClass.lungeCD = 0;
            }
        }
        else
        {
            //me.transform.position = Vector3.Lerp(me.transform.position, me.transform.position + (me.transform.forward * 10), 1);
            StartCoroutine(Dash(gameObject));

        }
        //me.transform.position = Vector3.MoveTowards(me.transform.position, me.transform.position + (me.transform.forward * 100), 1000 * Time.deltaTime);
        baseClass.abilityCooldowns.cooldowns["lungeCD"] = baseClass.abilityCooldowns.lungeCD;
        //print(baseClass.abilityCooldowns.cooldowns["lungeCD"]);


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
}
