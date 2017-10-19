using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
    float timer;
    public int targetslot;
    //public GameObject target;
    public GameObject controller;
    public PlayerAbilityController abilities;
    public PlayerCDController cooldowns;
    public PlayerID ID;
    public int layer;


     void Start()
    {
        abilities = controller.GetComponent<PlayerAbilityController>();
        cooldowns = controller.GetComponent<PlayerCDController>();
        ID = GetComponent<PlayerID>();

    }
    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
        targetslot = ID.playerID;

        if (Input.GetButtonDown("Attack"))
        {
                //RaycastHit hit;


                //if (Physics.Raycast(transform.position, -Vector3.forward, out hit, 1<<9))
                // {
                //  GameObject target = hit.collider.gameObject;

                //abilities.MeleeStrike(targetslot);
                // }

            }
        if (ID.playerID == 3 && Input.GetAxis("RangedAttack") == 1)
        {
           // abilities.RangedBolt(targetslot, gameObject);
        }
        //Utility move
        if (ID.playerID == 3 && Input.GetButtonDown("P2Attack1"))
        {
           // abilities.RangedRopeBolt(targetslot, gameObject);
            print(targetslot);
        }
    }
}
