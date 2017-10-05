﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
    float timer;
    public int targetslot;
    //public GameObject target;
    public GameObject controller;
    public PlayerAbilityController abilities;
    public PlayerCDController cooldowns;
    public int layer;

     void Start()
    {
        abilities = controller.GetComponent<PlayerAbilityController>();
        cooldowns = controller.GetComponent<PlayerCDController>();

    }
    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
        if (Input.GetButtonDown("Attack"))
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, -Vector3.forward, out hit, 1<<9))
            {
                GameObject target = hit.collider.gameObject;
                //print(target);

                abilities.executeAttack(1, targetslot, target);
            }

        }

    }

    // This method controls the damage done, it chooses a target, finds their health script, and applies damage as well as sends their ID.
    //public void doAttack()
    //{
 

    //   abilities.executeAttack(0);

    //}

    public void triggerCooldown(int AttackID, float cooldown)
    {

    }

    // This just assigns the ID to the character. This is explained more in the BossTargetingAI script.
   public void assignSlot(int slotNum)
    {
        targetslot = slotNum;
    }
}
