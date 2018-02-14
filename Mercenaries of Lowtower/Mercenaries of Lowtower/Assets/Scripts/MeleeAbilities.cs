using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAbilities : MonoBehaviour {

    MeleeClass baseClass;
    public GameObject hitbox;

    private void Awake()
    {
        baseClass = GetComponent<MeleeClass>();
    }

    public void Update()
    {
        if (baseClass.abilityCooldowns.cooldowns["meleeCD"]<=0)
        {
            hitbox.SetActive(false);
        }
    }


    public void MeleeStrikeRogue()
    {
        //MOVE TARGET LIST INTO CONTROLLER

        if (baseClass.abilityCooldowns.cooldowns["meleeCD"] <= 0)
        {

            //works with melee hitbox
            hitbox.SetActive(true);

            //for (int i = 0; i < baseClass.targetList.mTar.Count; i++)
            //{
            //    //print(baseClass.abilityCooldowns.cooldowns["meleeCD"]);

            //    //Health health = baseClass.targetList.mTar[i].GetComponent<Health>();
            //    //health.modifyHealth(baseClass.meleeDamage, baseClass.CTRLID);
            //    baseClass.targetList.mTar[i].GetComponent<IDamageable<float>>().TakeDamage(baseClass.meleeDamage);
            //}

            baseClass.abilityCooldowns.cooldowns["meleeCD"] = baseClass.abilityCooldowns.meleeCD;
        }
       
    }

    public void MeleeLunge()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, baseClass.lungeDistance, baseClass.enemyMask, QueryTriggerInteraction.Ignore) && baseClass.abilityCooldowns.cooldowns["lungeCD"] <= 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, hit.point, 1000 * Time.deltaTime);
            Health health = hit.collider.gameObject.GetComponent<Health>();
            health.modifyHealth(baseClass.lungeDamage, baseClass.CTRLID);
            if (health.health <= 0)
            {
                //baseClass.abilityCooldowns.lungeCD = 0;
            }
            baseClass.abilityCooldowns.cooldowns["lungeCD"] = baseClass.abilityCooldowns.lungeCD;

        }
        else if ( baseClass.abilityCooldowns.cooldowns["lungeCD"] <= 0)
        {
            //me.transform.position = Vector3.Lerp(me.transform.position, me.transform.position + (me.transform.forward * 10), 1);
            StartCoroutine(Dash(gameObject));
            baseClass.abilityCooldowns.cooldowns["lungeCD"] = baseClass.abilityCooldowns.lungeCD;

        }
        //me.transform.position = Vector3.MoveTowards(me.transform.position, me.transform.position + (me.transform.forward * 100), 1000 * Time.deltaTime);
        //baseClass.abilityCooldowns.cooldowns["lungeCD"] = baseClass.abilityCooldowns.lungeCD;
        //print(baseClass.abilityCooldowns.cooldowns["lungeCD"]);


    }

    IEnumerator Dash(GameObject me)
    {

        if (Physics.Raycast(me.transform.position, me.transform.forward, 2) == false)
        {
            me.transform.position = Vector3.Lerp(me.transform.position, me.transform.position + (me.transform.forward * .5f), 1);
            yield return new WaitForSeconds(.01f);
        }
        else
        {
            yield break;
        }
        if (Physics.Raycast(me.transform.position, me.transform.forward, 4) == false)
        {
            me.transform.position = Vector3.Lerp(me.transform.position, me.transform.position + (me.transform.forward * 1), 1);
            yield return new WaitForSeconds(.01f);
        }
        else
        {
            yield break;
        }
        if (Physics.Raycast(me.transform.position, me.transform.forward, 6) == false)
        {
            me.transform.position = Vector3.Lerp(me.transform.position, me.transform.position + (me.transform.forward * 1.5f), 1);
            yield return new WaitForSeconds(.01f);
        }
        else
        {
            yield break;
        }
        if (Physics.Raycast(me.transform.position, me.transform.forward, 6) == false)
        {
            me.transform.position = Vector3.Lerp(me.transform.position, me.transform.position + (me.transform.forward * 1.5f), 1);
            yield return new WaitForSeconds(.01f);
        }
        else
        {
            yield break;
        }
        if (Physics.Raycast(me.transform.position, me.transform.forward, 6) == false)
        {
            me.transform.position = Vector3.Lerp(me.transform.position, me.transform.position + (me.transform.forward * 1.5f), 1);
            yield return new WaitForSeconds(.01f);
        }
        else
        {
            yield break;
        }
        if (Physics.Raycast(me.transform.position, me.transform.forward, 4) == false)
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
            me.transform.position = Vector3.Lerp(me.transform.position, me.transform.position + (me.transform.forward * .5f), 1);
            yield return new WaitForSeconds(.01f);
        }
        else
        {
            yield break;
        }

    }
}
