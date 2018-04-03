using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltForward : MonoBehaviour {

    public float boltSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.name == "BluntArrow(Clone)")
        {
            transform.Translate(Vector3.forward * boltSpeed);
        }
        else
        {
            transform.Translate(Vector3.forward);
        }
        Destroy(gameObject, 3);
	}
}
