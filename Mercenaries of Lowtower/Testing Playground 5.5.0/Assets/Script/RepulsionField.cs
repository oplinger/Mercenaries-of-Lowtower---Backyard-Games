using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepulsionField : MonoBehaviour {
    public Collider[] hitColliders;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("i"))
        {
            hitColliders = Physics.OverlapSphere(transform.position, 10, 2, QueryTriggerInteraction.Ignore);

            if (hitColliders.Length == 0)
            {
            }
            for (int i = 0; i < hitColliders.Length; i++)
            {
                hitColliders[i].gameObject.transform.position = Vector3.MoveTowards(hitColliders[i].gameObject.transform.position, transform.position, -5 * Time.deltaTime);
            }
            //if (hitColliders.Length > 0)
            //{
            //    for (int i = 0; i < hitColliders.Length; i++)
            //    {
            //        hitColliders[i].gameObject.transform.position = Vector3.MoveTowards(hitColliders[i].gameObject.transform.position, transform.position, -5 * Time.deltaTime);
            //    }
            //}
        }
    }
}
