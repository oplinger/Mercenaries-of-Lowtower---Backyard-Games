using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHead : BossClass {

    public GameObject boss;
    public GameObject bossManager;
    public int bossPhaseCounter;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        bossPhaseCounter = bossManager.GetComponent<BossControlScriptV2>().bossPhase;
	}

    public override void TakeDamage(float damageTaken)
    {
        if(bossPhaseCounter < 5)
        {
            boss.GetComponent<BossClass>().currentHealth -= damageTaken;
        }
    }
}
