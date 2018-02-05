using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour {

    public Collider[] playersInShield;
    TankClass baseClass;

    // Use this for initialization
    void Start () {
        baseClass = GameObject.Find("Tank Character(Clone)").GetComponent<TankClass>();

    }

    //// Update is called once per frame
    void Update () {
    playersInShield = Physics.OverlapSphere(transform.position, baseClass.shieldSize, baseClass.shieldMask, QueryTriggerInteraction.Ignore);


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
}
