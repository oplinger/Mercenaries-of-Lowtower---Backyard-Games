using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class MeleeClass : PlayerClass
{
    public PlayerAbilityController ability;
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
    private void Awake()
    {
        buttons = new Hashtable();
        buttonA = buttonAfunction;
        buttonB = buttonBfunction;
        buttonX = buttonXfunction;
        buttonY = buttonYfunction;

        buttons.Add("Abutton", 0);
    }

    void Start()
    {

        ability1 = MeleeLunge;
        ability1 += Smoke;
    }

    // Update is called once per frame
    void Update()
    {
        print("Melee:" + buttons["Abutton"]);
        //if (Input.GetKeyDown("joystick "+ CTRLID +" button "+ System.Array.IndexOf(buttons, 0)))
        //{
        //    buttonA();
        //}
        //if (Input.GetKeyDown("joystick " + CTRLID + " button "+ System.Array.IndexOf(buttons, 1)))
        //{
        //    buttonB();
        //}
        //if (Input.GetKeyDown("joystick " + CTRLID + " button "+ System.Array.IndexOf(buttons, 2)))
        //{
        //    buttonX();
        //}
        //if (Input.GetKeyDown("joystick " + CTRLID + " button " + System.Array.IndexOf(buttons, 3)))
        //{
        //    buttonY();
        //}


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
            print("Dashing!");
            //StartCoroutine(Dash(gameObject));

        }
        //me.transform.position = Vector3.MoveTowards(me.transform.position, me.transform.position + (me.transform.forward * 100), 1000 * Time.deltaTime);
        //cooldowns.triggerCooldown(8, lungeCD);

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
        Instantiate(Resources.Load("smoke"),transform.position,Quaternion.identity);
    }
}
