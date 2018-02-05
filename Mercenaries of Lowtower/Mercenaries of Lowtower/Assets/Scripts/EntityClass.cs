using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityClass : MonoBehaviour, IDamageable<float> {

    public float maxHealth;
    public float currentHealth;
    protected float lastFrameHealth;
    protected Vector3 movement;
    protected bool death;
    public bool shielded;


    // Use this for initialization
    void Start () {

        shielded = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Death()
    {

    }

    public void TakeDamage(float damageTaken)
    {
        if (!shielded)
        {
            currentHealth -= damageTaken;
        }
        else if (shielded)
        {
      
        }

       
    }

}
