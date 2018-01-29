using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
   public float health;
    public float maxHealth;
    public GameObject player;
    public bool shielded;
    public GameObject foundShield;
    //public MovementRigidbody playerMoveScript;

    //public float dam;

    public bool isDead;

	// Initializes the gameObject with 100 health. Can be tweaked with If statements or a health Method.
	void Start () {

        //if (gameObject.tag == "Player")
        //{
        //    health = 100;
        //}

        if (gameObject.tag == "Shield")
        {
            float shieldhealth = GameObject.Find("Tank Character(Clone)").GetComponent<TankController>().shieldHealth;
            health = shieldhealth;
        }
        player = this.gameObject;
        //playerMoveScript = GetComponent<MovementRigidbody>();

        isDead = false;

        maxHealth = health;
	}
    private void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        if (health<=0)
        {
            isDead = true;
        }
        if(isDead && (gameObject.tag == "Enemy"))
        {
            Destroy(gameObject);
        }
        if (isDead && gameObject.tag == "Shield")
        {
            Destroy(gameObject.transform.parent.gameObject);

            Destroy(gameObject);
        }
        
    }
    // This method takes passed in data and manipulates the health value. Damage is the amount of health lost or gained (negative values are healing) 
    //and the ID is the character ID that is doing the damage. These are assigned to players by the boss on start.
    public void modifyHealth( float dam, int ID)
    {
        if(health > 0 && shielded)
        {
            if (gameObject.tag == "Player")
            {
                //dam *= 0;
                foundShield = GameObject.FindGameObjectWithTag("Shield");
                if (null != foundShield)
                {
                    foundShield.GetComponent<Health>().health -= dam;
                }
            } 
            //if (gameObject.tag == "Shield")
            //{
            //    health -=dam*GetComponent<ShieldScript>().playersInShield.Length;
            //}
        }
        else
        {
            health -= dam;
        }



        // If the target is an enemy, it will convert any damage done to it to threat, for targeting purposes.
        if (gameObject.tag == "Enemy")
        {
            BossTargetingAI threat = GetComponent<BossTargetingAI>();
            threat.addThreat(dam, ID, false);
        }
    }
}

