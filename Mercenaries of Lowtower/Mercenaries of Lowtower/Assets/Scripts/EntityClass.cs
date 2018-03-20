using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class EntityClass : MonoBehaviour, IDamageable<float>, IStunnable<float> {

    public float maxHealth;
    public float currentHealth;
    protected float lastFrameHealth;
    protected Vector3 movement;
    protected bool death;
    public bool shielded;

    public bool isStunned;
    public float tempMoveSpeed;
    public int moveSpeed;



    // Use this for initialization
    void Start () {

        shielded = false;
		
	}
	
	// Update is called once per frame
	void Update () {



        //if (!isStunned)
        //{ }

    }

    public void Death()
    {
        Destroy(gameObject);
    }

    public virtual void TakeDamage(float damageTaken)
    {
        if (currentHealth > 0)
        {
            if (currentHealth < damageTaken)
            {
                damageTaken = currentHealth;

            }

            if (!shielded)
            {
                currentHealth -= damageTaken;
            }
            else if (shielded)
            {
                if (damageTaken < 0)
                {
                    currentHealth -= damageTaken;
                }
            }
        } else
        {

        }
       
    }

    public virtual void StunThis()
    {
        isStunned = true;
        

        //stops movement
        moveSpeed=0;
      

    }



}
