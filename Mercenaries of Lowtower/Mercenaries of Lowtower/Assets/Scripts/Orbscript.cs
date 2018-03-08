﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbscript : MonoBehaviour {
    GameObject Origin;
    GameObject Target;
    float healAmount;
    float orbSpeed;
    public float trackingDistance;
    int ID;
    Collider[] cols;
    public LayerMask PlayerMask;
    float closestDistance;    
    float[] distances;

	// Use this for initialization
	void Start () {
        //IDamageable damage = (IDamageable)GetComponent(typeof(IDamageable));

	}
	
	// Update is called once per frame
	void Update () {

        Physics.OverlapSphereNonAlloc(transform.position, trackingDistance, cols, PlayerMask, QueryTriggerInteraction.Ignore);
        if (cols != null)
        {
            for (int i = 0; i < cols.Length; i++)
            {
                closestDistance = 100f;
                distances[i] = (Vector3.Distance(transform.position, cols[i].transform.position));
                if (distances[i] < closestDistance)
                {
                    Target = cols[i].gameObject;
                }

            }
        }


        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, orbSpeed*Time.deltaTime);
	}

    public void OrbBehavior(GameObject origin, GameObject target, float healamount, float orbspeed, int playerID)
    {
         Origin=origin;
         //Target=target;
         healAmount=healamount;
         orbSpeed=orbspeed;
         playerID=ID;

        transform.position = Origin.transform.position;


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == Target.name)
        {
            //other.GetComponent<Health>().modifyHealth(-healAmount, ID);
            other.GetComponent<IDamageable<float>>().TakeDamage(-healAmount);
            print(Target.name + " healed for " + healAmount);
            Destroy(gameObject);
        }
    }
}
