using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour {

    MovementRigidbody playerMoveScript;


    /*MERGE SCRIPT WITH CHARACTER CONTROLLERS*/
    
        
        // Use this for initialization
    void Start () {
        playerMoveScript = GetComponent<MovementRigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }

    public void PlayerDeath()
    {
        Debug.Log("Player is dead.");
        playerMoveScript.isDead = true;
    }

    public void EnemyDeath(GameObject target)
    {
        Debug.Log("Enemy is dead.");
        Destroy(target);
    }
}
