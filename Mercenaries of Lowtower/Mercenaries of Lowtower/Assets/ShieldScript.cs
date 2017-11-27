using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour {
    Collider[] cols;
    public Collider[] playersInShield;
    GameObject controllerThing;

    // Use this for initialization
    void Start () {
        controllerThing = GameObject.Find("Controller Thing");
    }

    // Update is called once per frame
    void Update () {
       //playersInShield = Physics.OverlapSphere(transform.position, 10, 1 << 8, QueryTriggerInteraction.Ignore);

        //cols = Physics.OverlapSphere(transform.position, 10, 1<<8, QueryTriggerInteraction.Ignore);
        // for (int i = 0; i<cols.Length; i++)
        // {
        //     if(Vector3.Distance(cols[i].transform.position, transform.position) < 10){
        //         cols[i].GetComponent<Health>().shielded = true;

        //     } else
        //     {
        //         cols[i].GetComponent<Health>().shielded = false;

        //     }
        // }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            //DO A STUN THING OR OTHER EFFECT
            //Create a method on the enemy to call that will stop them for X seconds or whatever we need
            other.GetComponent<BossMovementAI>().stun = true;
        }


    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Health>().shielded = true;
        }

        //if (other.tag == "Player" && Input.GetButton("DropShield"))
        //{
        //    transform.position += new Vector3(Input.GetAxis("TankHorizontal")*.15f, 0, Input.GetAxis("TankVertical")*.15f);
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Health>().shielded = false;
        }
    }
    private void OnDestroy()
    {
        Collider[] allcol = Physics.OverlapSphere(transform.position, 10, 1 << 8, QueryTriggerInteraction.Ignore);
        for(int i = 0; i < allcol.Length; i++)
        {
            allcol[i].GetComponent<Health>().shielded = false;

        }
        //controllerThing.GetComponent<PlayerCDController>().triggerCooldown(1, controllerThing.GetComponent<PlayerCDController>().abilityCooldowns[1]);
    }
}
