using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TsunamiScript : MonoBehaviour {
    public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate((Vector3.forward * speed) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Health>().modifyHealth(20, 9);
    }
}
