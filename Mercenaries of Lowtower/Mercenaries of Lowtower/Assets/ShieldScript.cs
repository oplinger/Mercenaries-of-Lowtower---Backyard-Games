using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShieldScript : MonoBehaviour {

    public Collider[] playersInShield;
    TankClass baseClass;
    public float shieldTimer;

    // Use this for initialization
    void Start () {
        baseClass = GameObject.Find("Tank Character(Clone)").GetComponent<TankClass>();
        shieldTimer = baseClass.shieldDuration;
    }

    //// Update is called once per frame
    void Update () {
    playersInShield = Physics.OverlapSphere(transform.position, baseClass.shieldSize, baseClass.shieldMask, QueryTriggerInteraction.Ignore);
        if (shieldTimer > 0)
        {
            shieldTimer -= Time.deltaTime;
        }

        if (shieldTimer < 2)
        {
            StartCoroutine(shieldFlash());
        }


    //    //cols = Physics.OverlapSphere(transform.position, 10, 1<<8, QueryTriggerInteraction.Ignore);
    //    // for (int i = 0; i<cols.Length; i++)
    //    // {
    //    //     if(Vector3.Distance(cols[i].transform.position, transform.position) < 10){
    //    //         cols[i].GetComponent<Health>().shielded = true;

    //    //     } else
    //    //     {
    //    //         cols[i].GetComponent<Health>().shielded = false;

    //    //     }
    //    // }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            print("enemy inside shield");
            //other.GetComponent<Rigidbody>().AddForce(other.transform.forward * -10, ForceMode.Impulse);
            //Vector3 shieldPosition = new Vector3 (transform.position.x, transform.position.y-500, transform.position.z);
            Rigidbody oRigid = other.GetComponent<Rigidbody>();
            Vector3 reflectDirection = other.transform.position - transform.position;
            //other.GetComponent<NavMeshAgent>().isStopped = true;
            other.GetComponent<NavMeshAgent>().enabled = false;

            oRigid.AddForce(reflectDirection*3, ForceMode.Impulse);
            oRigid.AddForce(0, 5, 0, ForceMode.Impulse);
            
        }

    }

    private void OnTriggerEnter(Collider other)
    {


        if (other.name=="Tank Character(Clone)")
        {
            other.GetComponent<TankClass>().shielded = true;
        }

        if (other.name == "Healer Character(Clone)")
        {
            other.GetComponent<HealerClass>().shielded = true;
        }

        if (other.name == "Melee Character(Clone)")
        {
            other.GetComponent<MeleeClass>().shielded = true;
        }

        if (other.name == "Ranged Character(Clone)")
        {
            other.GetComponent<RangedClass>().shielded = true;
        }
        //if (other.tag == "Enemy")
        //{
        //    //DO A STUN THING OR OTHER EFFECT
        //    //Create a method on the enemy to call that will stop them for X seconds or whatever we need
        //    //IStunnable
        //    other.GetComponent<BossMovementAI>().stun = true;
        //}


    }

    //private void OnTriggerStay(Collider other)
    //{

    // IShieldable
    //    if (other.tag == "Player")
    //    {
    //        //other.GetComponent<Health>().shielded = true;
    //    }

    //    //if (other.tag == "Player" && Input.GetButton("DropShield"))
    //    //{
    //    //    transform.position += new Vector3(Input.GetAxis("TankHorizontal")*.15f, 0, Input.GetAxis("TankVertical")*.15f);
    //    //}
    //}

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Tank Character(Clone)")
        {
            other.GetComponent<TankClass>().shielded = false;
        }

        if (other.name == "Healer Character(Clone)")
        {
            other.GetComponent<HealerClass>().shielded = false;
        }

        if (other.name == "Melee Character(Clone)")
        {
            other.GetComponent<MeleeClass>().shielded = false;
        }

        if (other.name == "Ranged Character(Clone)")
        {
            other.GetComponent<RangedClass>().shielded = false;
        }
    }
    private void OnDestroy()
    {
        for (int i = 0; i < playersInShield.Length; i++)
        {
            if (playersInShield[i].name == "Tank Character(Clone)")
            {
                playersInShield[i].GetComponent<TankClass>().shielded = false;
            }
            if (playersInShield[i].name == "Melee Character(Clone)")
            {
                playersInShield[i].GetComponent<MeleeClass>().shielded = false;
            }
            if (playersInShield[i].name == "Healer Character(Clone)")
            {
                playersInShield[i].GetComponent<HealerClass>().shielded = false;
            }
            if (playersInShield[i].name == "Ranged Character(Clone)")
            {
                playersInShield[i].GetComponent<RangedClass>().shielded = false;
            }

        }
        //controllerThing.GetComponent<PlayerCDController>().triggerCooldown(1, controllerThing.GetComponent<PlayerCDController>().abilityCooldowns[1]);
    }

    IEnumerator shieldFlash()
    {
        Vector4 currentColor = GetComponent<Renderer>().material.color;
        Vector4 newColor = currentColor - new Vector4(0, 0, 0, .03f);
        GetComponent<Renderer>().material.color = newColor;
        yield return new WaitForSeconds(.25f);
        GetComponent<Renderer>().material.color = currentColor;
        yield return new WaitForSeconds(.25f);
        GetComponent<Renderer>().material.color = newColor;
        yield return new WaitForSeconds(.25f);
        GetComponent<Renderer>().material.color = currentColor;
        yield return new WaitForSeconds(.25f);
        GetComponent<Renderer>().material.color = newColor;
    }

}
