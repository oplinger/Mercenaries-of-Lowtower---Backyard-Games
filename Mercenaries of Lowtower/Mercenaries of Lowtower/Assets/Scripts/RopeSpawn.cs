using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeSpawn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.forward);
        if (Physics.Raycast(ray, out hit, 2))
        {
            GameObject clone;
            clone = Instantiate(Resources.Load("Rope", typeof(GameObject)), hit.point, Quaternion.identity) as GameObject;
            Destroy(gameObject);
        }
    }
}
