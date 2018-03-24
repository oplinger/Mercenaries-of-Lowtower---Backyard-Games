using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackHitbox : MonoBehaviour {

    public MeleeClass baseClass;


    // Use this for initialization
    private void Awake()
    {

        //baseClass = GetComponent<MeleeClass>();
    }


	
	// Update is called once per frame
	void Update () {

		
	}

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Enemy" || other.tag=="Tentacle")
        {
            print(baseClass.meleeDamage);
            other.GetComponent<IDamageable<float>>().TakeDamage(baseClass.meleeDamage);


            //Health protagonistHealth = other.gameObject.GetComponent<Health>();

            //if (!protagonistHealth.shielded)
            //{
            //    protagonistHealth.health -= slamDamage;
            //}

            //if (other.gameObject.tag == "Player")
            //{
            //    Health playerHealth = other.gameObject.GetComponent<Health>();
            //    playerHealth.health -= slamDamage;
            //}
        }

    }
}
