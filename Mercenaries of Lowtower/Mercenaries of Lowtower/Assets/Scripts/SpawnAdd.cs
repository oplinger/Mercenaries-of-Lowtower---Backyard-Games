using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAdd : MonoBehaviour {

    public GameObject add;
    public int timer;
    public int addCounter;
    public int maxAdds;
    public GameObject[] addSpawnPoints;
    

   
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
            int spawnPoint = Random.Range(0,10);
            Instantiate(add, addSpawnPoints[spawnPoint].transform.position, addSpawnPoints[spawnPoint].transform.rotation);
            timer = 0;
        }
        

    }


        }


        
	