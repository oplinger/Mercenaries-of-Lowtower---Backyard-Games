using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeBoltAttach : MonoBehaviour {
    RopeSpawn ropespawn;
    public bool ropespawnbool=true;
    public GameObject rope;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //print(ropespawnbool);
	}


    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        Vector3 pos = contact.point;
        //transform.position = pos;
        //thisobject.velocity = new Vector3(0, 0, 0);
        Destroy(this.gameObject);


        if (ropespawnbool)
        {
            Instantiate(rope, pos-new Vector3(0,3,0), Quaternion.identity);
            ropespawnbool = false;
        }
    


    //ropespawn.SpawnRope(transform.position, 5);
}
}
