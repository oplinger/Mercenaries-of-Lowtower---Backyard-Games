using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlane : MonoBehaviour {
    public GameObject addspawn;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            addspawn.GetComponent<SpawnAdd>().addCounter--;

        } else
        {
            collision.gameObject.transform.position = new Vector3(0, 1.7f, -10.9f);

        }
    }
}

