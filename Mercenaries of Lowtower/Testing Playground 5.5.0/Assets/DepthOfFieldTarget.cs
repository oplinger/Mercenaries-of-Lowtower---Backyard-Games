using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class DepthOfFieldTarget : MonoBehaviour {
    public GameObject target;
    DepthOfField dof;
    
	// Use this for initialization
	void Start () {
        dof = GetComponent<DepthOfField>();
        }
    
	
	// Update is called once per frame
	void Update () {
        dof.focalLength = Vector3.Distance(transform.position, target.transform.position);
	}
}
