using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbscript : MonoBehaviour {
    GameObject Origin;
    GameObject Target;
    float healAmount;
    float orbSpeed;
    int ID;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, orbSpeed*Time.deltaTime);
	}

    public void OrbBehavior(GameObject origin, GameObject target, float healamount, float orbspeed, int playerID)
    {
         Origin=origin;
         Target=target;
         healAmount=healamount;
         orbSpeed=orbspeed;
         playerID=ID;

        transform.position = Origin.transform.position;


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == Target.name)
        {
            other.GetComponent<Health>().modifyHealth(-healAmount, ID);
            print(Target.name + " healed for " + healAmount);
            Destroy(gameObject);
        }
    }
}
