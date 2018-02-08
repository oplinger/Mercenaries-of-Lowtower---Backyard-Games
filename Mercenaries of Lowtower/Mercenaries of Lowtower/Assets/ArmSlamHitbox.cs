using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmSlamHitbox : MonoBehaviour 
{
    public float slamDamage;

    public float damageTimer;

    // Use this for initialization
    void Start () {
		
	}

    private void OnEnable()
    {

        //damageTimer = 30;
    }

    // Update is called once per frame
    void Update ()
    {

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag=="Player")
        {
            other.GetComponent<IDamageable<float>>().TakeDamage(slamDamage);
            
            
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
