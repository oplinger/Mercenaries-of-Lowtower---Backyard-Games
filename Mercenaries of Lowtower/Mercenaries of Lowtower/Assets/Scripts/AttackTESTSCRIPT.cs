using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTESTSCRIPT : MonoBehaviour {
    float timer;
    public int targetslot;
    public GameObject boss;
    public float damage;
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        
        if (timer > 5)
        {
            dealDamage(boss);
            timer = 0;
        }
	}
    public void dealDamage(GameObject target)
    {
       Health health = target.GetComponent<Health>();
        health.modifyHealth(damage, targetslot);
        //print(gameObject.name + " dealing damage!");
    }
   public void assignSlot(int slotNum)
    {
        targetslot = slotNum;
    }
}
