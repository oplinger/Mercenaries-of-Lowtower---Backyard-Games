using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAdd : MonoBehaviour {

    public GameObject add;
    public int timer;
    public int addCounter;
    public int maxAdds;
    

   
	void Start () {

        addCounter = 0;
		
	}

    // Update is called once per frame
    void Update() {

        //if (!rockSpawned)
        //{
        timer += 1;

        if (timer >= 100&&addCounter<maxAdds)
        {

            Instantiate(add, transform.position, transform.rotation);
            timer = 0;
        }
        

    }


        }


        
	