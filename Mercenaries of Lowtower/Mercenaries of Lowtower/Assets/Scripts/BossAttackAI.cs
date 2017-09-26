using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackAI : MonoBehaviour {
    public float[] attackCDs;
    BossTargetingAI targeting;
   public float currentGCD;
    float maxGCD;
	// Use this for initialization
	void Start () {
        attackCDs = new float[4];
        targeting = GetComponent<BossTargetingAI>();

        attackCDs[0] = 10;
        attackCDs[1] = 8;
        attackCDs[2] = 5;
        attackCDs[3] = 2;
    }
	
	// Update is called once per frame
	void Update () {
        currentGCD += Time.deltaTime;
        attackCDs[0] -= Time.deltaTime;
        attackCDs[1] -= Time.deltaTime;
        attackCDs[2] -= Time.deltaTime;
        attackCDs[3] -= Time.deltaTime;

        if (currentGCD >= maxGCD)
        {
            checkAttacks();
            
        }
        


    }

    void Attack1(GameObject target)
    {
        Health health = target.GetComponent<Health>();
        health.modifyHealth(20, 9);
        attackCDs[0] = 10;
        triggerGCD(2);
        print("ATTACK1 USED");
    }

    void Attack2(GameObject target)
    {
        Health health = target.GetComponent<Health>();
        health.modifyHealth(10, 9);
        attackCDs[1] = 8;
        triggerGCD(2);
        print("ATTACK2 USED");
    }

    void Attack3(GameObject target)
    {
        Health health = target.GetComponent<Health>();
        health.modifyHealth(5, 9);
        attackCDs[2] = 5;
        triggerGCD(2);
        print("ATTACK3 USED");
    }
    
    void Attack4(GameObject target)
    {
        Health health = target.GetComponent<Health>();
        health.modifyHealth(1, 9);
        attackCDs[3] = 2;
        triggerGCD(2);
        print("ATTACK4 USED");
    }

    void checkAttacks()
    {
        if (attackCDs[0] <= 0)
        {
            Attack1(targeting.currentTarget);
            
        } else if (attackCDs[1] <= 0)
        {
            Attack2(targeting.currentTarget);
        }
         else if (attackCDs[2] <= 0)
        {
            Attack3(targeting.currentTarget);
        }
         else if (attackCDs[3] <= 0)
        {
            Attack4(targeting.currentTarget);
        }
    }

    void triggerGCD(float cooldownTime)
    {
        currentGCD = 0;
        maxGCD = cooldownTime;
    }
}

