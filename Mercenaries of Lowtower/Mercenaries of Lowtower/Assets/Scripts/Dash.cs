using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour {

    public void MeleeLunge()
    {
        RaycastHit hit;

        print("MeleeAbility1");

        if (Physics.Raycast(transform.position, transform.forward, out hit, 3, 1, QueryTriggerInteraction.Ignore))
        {
            transform.position = Vector3.MoveTowards(transform.position, hit.point, 1000 * Time.deltaTime);
            Health health = hit.collider.gameObject.GetComponent<Health>();
            health.modifyHealth(3, 2);
            if (health.health <= 0)
            {
                //lungeCD = 0;
            }
        }
        else
        {
            //me.transform.position = Vector3.Lerp(me.transform.position, me.transform.position + (me.transform.forward * 10), 1);
            print("Dashing!");
            //StartCoroutine(Dash(gameObject));

        }
        //me.transform.position = Vector3.MoveTowards(me.transform.position, me.transform.position + (me.transform.forward * 100), 1000 * Time.deltaTime);
        //cooldowns.triggerCooldown(8, lungeCD);

    }

    IEnumerator DashRoutine(GameObject me)
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
