using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTESTSCRIPT : MonoBehaviour {
    public GameObject target;
    float timer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position, target.transform.position, (timer += Time.deltaTime*2));
    }
}
