using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityClass : MonoBehaviour, IDamageable<float> {

    protected float maxHealth;
    protected float currentHealth;
    protected float lastFrameHealth;
    protected Vector3 movement;
    protected bool death;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Death()
    {

    }

    public void TakeDamage(float damageTaken)
    {
        currentHealth -= damageTaken;
    }
}
