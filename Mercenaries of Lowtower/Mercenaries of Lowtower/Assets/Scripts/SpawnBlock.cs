using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlock : MonoBehaviour {

    public GameObject blockBreakable;
    public GameObject blockMagnetic;
    //public bool rockSpawned;
    //GameObject currentRock;
    public int timer;

    //public int randomizeBlock;

    bool magnetic;
    public bool breakable;

	// Use this for initialization
	void Start () {

        //breakable = true;
        //magnetic = false;
		
	}

    // Update is called once per frame
    void Update() {

        //if (!rockSpawned)
        //{
        timer += 1;

        if (timer >= 300 && breakable)
        {

            Instantiate(blockBreakable, transform.position, transform.rotation);
            breakable = false;
            //magnetic = true;
            timer = 0;
        }

        if (timer >= 300 && !breakable)
        {
            Instantiate(blockMagnetic, transform.position, transform.rotation);
            breakable = true;
            //magnetic = false;
            timer = 0;
        }

    }


        }
       // }


        
	