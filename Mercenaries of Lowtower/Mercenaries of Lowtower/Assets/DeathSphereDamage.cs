using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSphereDamage : MonoBehaviour {

    public float damage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Health playerHealthScript;
        GameObject player=other.gameObject;

        playerHealthScript = player.GetComponent<Health>();

        //can't use playerHealthScript.dam because it's private

        playerHealthScript.health += damage*-1;
    }
}
