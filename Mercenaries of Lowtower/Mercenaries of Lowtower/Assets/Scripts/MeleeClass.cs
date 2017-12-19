using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MeleeAbilities))]
[RequireComponent(typeof(MeleeCooldowns))]






public class MeleeClass : PlayerClass
{
    //public GameObject smoke;
     public MeleeAbilities abilities;
     public MeleeCooldowns abilityCooldowns;

    [SerializeField]
    int grounded;
    public LayerMask enemyMask;
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
        abilities = GetComponent<MeleeAbilities>();
        abilityCooldowns = GetComponent<MeleeCooldowns>();
        CTRLID = 2;
        //self = gameObject;
        //smoke = Resources.Load("smoke") as GameObject;

        //gameObject.AddComponent<Smoke>();
        //Smoke smokeability = GetComponent<Smoke>();

        //DOWNCASTING EXAMPLE
        //MeleeClass mC = new MeleeAbilities();
        //MeleeAbilities mA;
        //mA = (MeleeAbilities)mC;

        jumpheight = 5;

        ability1 = Jump;
        ability2 += abilities.Smoke;
        ability2 += abilities.MeleeLunge;
    }

    void Update()
    {
        grounded = JumpCheck();

        Movement();
        if (Input.GetKeyDown("joystick " + CTRLID + " button " + buttons["Abutton"]))
        {
            buttonA();
        }
        if (Input.GetKeyDown("joystick " + CTRLID + " button " + buttons["Bbutton"]))
        {
            buttonB();
        }
        if (Input.GetKeyDown("joystick " + CTRLID + " button " + buttons["Xbutton"]))
        {
            buttonX();
        }
        if (Input.GetKeyDown("joystick " + CTRLID + " button " + buttons["Ybutton"]))
        {
            buttonY();
        }



    }

    //public void MeleeLunge()
    //{
    //    RaycastHit hit;

    //    if (Physics.Raycast(transform.position, transform.forward, out hit, lungeDistance, enemyMask, QueryTriggerInteraction.Ignore))
    //    {
    //        transform.position = Vector3.MoveTowards(transform.position, hit.point, 1000 * Time.deltaTime);
    //        Health health = hit.collider.gameObject.GetComponent<Health>();
    //        health.modifyHealth(lungeDamage, CTRLID);
    //        if (health.health <= 0)
    //        {
    //            lungeCD = 0;
    //        }
    //    }
    //    else
    //    {
    //        //me.transform.position = Vector3.Lerp(me.transform.position, me.transform.position + (me.transform.forward * 10), 1);
    //        StartCoroutine(Dash(gameObject));

    //    }
    //    //me.transform.position = Vector3.MoveTowards(me.transform.position, me.transform.position + (me.transform.forward * 100), 1000 * Time.deltaTime);
    //    //cooldowns.triggerCooldown(8, lungeCD);

    //}

    //IEnumerator Dash(GameObject me)
    //{
    //    if (Physics.Raycast(me.transform.position, me.transform.forward, 1) == false)
    //    {
    //        me.transform.position = Vector3.Lerp(me.transform.position, me.transform.position + (me.transform.forward * 1), 1);
    //        yield return new WaitForSeconds(.01f);
    //    }
    //    else
    //    {
    //        yield break;
    //    }
    //    if (Physics.Raycast(me.transform.position, me.transform.forward, 2) == false)
    //    {
    //        me.transform.position = Vector3.Lerp(me.transform.position, me.transform.position + (me.transform.forward * 2), 1);
    //        yield return new WaitForSeconds(.01f);
    //    }
    //    else
    //    {
    //        yield break;
    //    }
    //    if (Physics.Raycast(me.transform.position, me.transform.forward, 4) == false)
    //    {
    //        me.transform.position = Vector3.Lerp(me.transform.position, me.transform.position + (me.transform.forward * 4), 1);
    //        yield return new WaitForSeconds(.01f);
    //    }
    //    else
    //    {
    //        yield break;
    //    }
    //    if (Physics.Raycast(me.transform.position, me.transform.forward, 6) == false)
    //    {
    //        me.transform.position = Vector3.Lerp(me.transform.position, me.transform.position + (me.transform.forward * 6), 1);
    //        yield return new WaitForSeconds(.01f);
    //    }
    //    else
    //    {
    //        yield break;
    //    }
    //    if (Physics.Raycast(me.transform.position, me.transform.forward, 6) == false)
    //    {
    //        me.transform.position = Vector3.Lerp(me.transform.position, me.transform.position + (me.transform.forward * 6), 1);
    //        yield return new WaitForSeconds(.01f);
    //    }
    //    else
    //    {
    //        yield break;
    //    }
    //    if (Physics.Raycast(me.transform.position, me.transform.forward, 6) == false)
    //    {
    //        me.transform.position = Vector3.Lerp(me.transform.position, me.transform.position + (me.transform.forward * 6), 1);
    //        yield return new WaitForSeconds(.01f);
    //    }
    //    else
    //    {
    //        yield break;
    //    }
    //    if (Physics.Raycast(me.transform.position, me.transform.forward, 4) == false)
    //    {
    //        me.transform.position = Vector3.Lerp(me.transform.position, me.transform.position + (me.transform.forward * 4), 1);
    //        yield return new WaitForSeconds(.01f);
    //    }
    //    else
    //    {
    //        yield break;
    //    }
    //    if (Physics.Raycast(me.transform.position, me.transform.forward, 2) == false)
    //    {
    //        me.transform.position = Vector3.Lerp(me.transform.position, me.transform.position + (me.transform.forward * 2), 1);
    //        yield return new WaitForSeconds(.01f);
    //    }
    //    else
    //    {
    //        yield break;
    //    }
    //    if (Physics.Raycast(me.transform.position, me.transform.forward, 1) == false)
    //    {
    //        me.transform.position = Vector3.Lerp(me.transform.position, me.transform.position + (me.transform.forward * 1), 1);
    //        yield return new WaitForSeconds(.01f);
    //    }
    //    else
    //    {
    //        yield break;
    //    }
    //}

    //void Smoke()
    //{
    //    Instantiate(Resources.Load("smoke"), transform.position, Quaternion.identity);
    //}
}
