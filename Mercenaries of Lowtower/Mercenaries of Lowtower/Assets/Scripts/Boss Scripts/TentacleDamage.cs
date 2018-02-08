using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleDamage : MonoBehaviour {

    public bool armDownCheck;
    public GameObject hitbox;
    public float damageTimer;

    //prevents damage from activating more than once while the arm is already grounded
    public bool damageDealt;
	// Use this for initialization
	void Start () {
		
	}


    // Update is called once per frame
    void Update () {
        //armDownCheck = GetComponentInParent<BossArmScript>().armDown;

        armDownCheck = GetComponentInParent<BossArmScript>().armDown;

        if (armDownCheck && !damageDealt)
        {
            hitbox.SetActive(true);
            damageTimer--;
        }

        if (damageTimer<=0)
        {
            hitbox.SetActive(false);
            damageDealt = true;
        }


        if (!armDownCheck)
        {
            damageDealt = false;
            damageTimer = 30;
        }

    }

    //public void OnTriggerEnter(Collider other)
    //{
        

    //    if (other.tag == "Player" && armDownCheck)
    //    {
    //        print("Boom");
    //        //other.GetComponent<IDamageable<float>>().TakeDamage(60);
    //    }
    //}
}
