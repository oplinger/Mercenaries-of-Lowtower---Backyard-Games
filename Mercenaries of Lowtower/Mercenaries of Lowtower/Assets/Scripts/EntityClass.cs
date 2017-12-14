using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityClass : MonoBehaviour {

    public float maxHealth;
    public float currentHealth;
    public float lastFrameHealth;
    public Vector3 movement;
    public bool death;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Death()
    {

    }

    public void DoDamage()
    {

    }
}
