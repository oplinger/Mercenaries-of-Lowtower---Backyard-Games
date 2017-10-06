using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : MonoBehaviour {

    public GameObject boss;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if(boss.GetComponent<BossAttacks>().bossPhase == 2)
            {
                Debug.Log("Hit Player with Punch.");
            }
            if (boss.GetComponent<BossAttacks>().bossPhase == 4)
            {
                Debug.Log("Hit Player with Spin.");
            }
            if (boss.GetComponent<BossAttacks>().bossPhase == 6)
            {
                Debug.Log("Hit Player with Slam.");
            }
        }
    }
}
