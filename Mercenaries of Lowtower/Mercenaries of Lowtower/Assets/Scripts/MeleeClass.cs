using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class MeleeClass : PlayerClass
{
    delegate void MeleeLungeDel();
    delegate void SmokeDel();

    [SerializeField]
    int grounded;
    [Header("Lunge Settings")]
    [Range(0, 10)]
    public float lungeDamage;
    [Range(0, 20)]
    public float lungeDistance;
    [Range(0, 10)]
    public float lungeCD;
    // Use this for initialization
    void Start()
    {


        ability1 = MeleeLunge;
        ability1 += Smoke;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("joystick "+ CTRLID +" button 0"))
        {
            buttonAfunction();
        }
        if (Input.GetKeyDown("joystick " + CTRLID + " button 1"))
        {
            buttonBfunction();
        }
        if (Input.GetKeyDown("joystick " + CTRLID + " button 2"))
        {
            buttonXfunction();
        }
        if (Input.GetKeyDown("joystick " + CTRLID + " button 3"))
        {
            buttonYfunction();
        }


        //grounded = JumpCheck();

        //if (grounded > 0)
        //{

        //    Jump(5);
        //}
        //else
        //{
        //    Jump(0);
        //}
    }

    public void MeleeLunge()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, lungeDistance, enemyMask, QueryTriggerInteraction.Ignore))
        {
            transform.position = Vector3.MoveTowards(transform.position, hit.point, 1000 * Time.deltaTime);
            Health health = hit.collider.gameObject.GetComponent<Health>();
            health.modifyHealth(lungeDamage, CTRLID);
            if (health.health <= 0)
            {
                lungeCD = 0;
            }
        }
        else
        {
            //me.transform.position = Vector3.Lerp(me.transform.position, me.transform.position + (me.transform.forward * 10), 1);
            StartCoroutine(Dash(gameObject));

        }
        //me.transform.position = Vector3.MoveTowards(me.transform.position, me.transform.position + (me.transform.forward * 100), 1000 * Time.deltaTime);
        cooldowns.triggerCooldown(8, lungeCD);

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

    void Smoke()
    {
        Instantiate(Resources.Load("smoke"));
    }
}
