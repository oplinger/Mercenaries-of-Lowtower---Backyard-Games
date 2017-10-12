using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
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
        Destroy(gameObject);
    }
}
