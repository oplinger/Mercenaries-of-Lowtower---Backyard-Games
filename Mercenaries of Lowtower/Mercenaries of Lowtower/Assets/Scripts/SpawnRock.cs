using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRock : MonoBehaviour {

    public GameObject rock;
    public bool rockSpawned;
    GameObject currentRock;
    public int timer;

	// Use this for initialization
	void Start () {
        
		
	}
	
	// Update is called once per frame
	void Update () {

        //if (!rockSpawned)
        //{
            timer += 1;

            if (timer>=900)
            {
                Instantiate(rock, transform.position, transform.rotation);
                //rockSpawned = true;
                //currentRock = rock;
                timer = 0;
            }
       // }


        
		
	}
}
