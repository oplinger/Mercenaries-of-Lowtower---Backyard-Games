using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackAI : MonoBehaviour {
    public float[] attackCDs;
    BossTargetingAI targeting;
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

        attackCDs[0] -= Time.deltaTime;
        attackCDs[1] -= Time.deltaTime;
        attackCDs[2] -= Time.deltaTime;
        attackCDs[3] -= Time.deltaTime;


        for (int i = 0; i < 4;)
        {
            if (attackCDs[0] <= 0)
            {
                Attack1(targeting.currentTarget);
            }
            if (attackCDs[1] <= 0)
            {
                Attack1(targeting.currentTarget);
            }
            if (attackCDs[2] <= 0)
            {
                Attack1(targeting.currentTarget);
            }
            if (attackCDs[3] <= 0)
            {
                Attack1(targeting.currentTarget);
            }
        }

    }

    void Attack1(GameObject target)
    {
        Health health = target.GetComponent<Health>();
        health.modifyHealth(20, 9);
        attackCDs[0] = 10;
        print("ATTACK1 USED");
    }

    void Attack2(GameObject target)
    {
        Health health = target.GetComponent<Health>();
        health.modifyHealth(10, 9);
        attackCDs[1] = 8;
        print("ATTACK2 USED");
    }

    void Attack3(GameObject target)
    {
        Health health = target.GetComponent<Health>();
        health.modifyHealth(5, 9);
        attackCDs[2] = 5;
        print("ATTACK3 USED");
    }
    
    void Attack4(GameObject target)
    {
        Health health = target.GetComponent<Health>();
        health.modifyHealth(1, 9);
        attackCDs[3] = 2;
        print("ATTACK4 USED");
    }
}

