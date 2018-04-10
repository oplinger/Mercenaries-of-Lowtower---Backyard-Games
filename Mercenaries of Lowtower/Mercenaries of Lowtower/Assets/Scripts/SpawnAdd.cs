using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAdd : MonoBehaviour {

    public GameObject add;
    public int timer;
    public int addCounter;
    public int maxAdds;
    public GameObject[] addSpawnPoints;
    public bool round1;
    public bool round2;
    public bool round3;
    public BossControlScriptV2 bossScript;
    public GameObject bossManager;

   
	void Start () {

        addCounter = 0;
        round1 = true;
        round2 = false;
        round3 = false;

        bossScript = bossManager.GetComponent<BossControlScriptV2>();
		
	}

    // Update is called once per frame
    void Update() {

        //if (!rockSpawned)
        //{
        timer += 1;

        if (round1)
        {
            maxAdds = 10;

            if (timer >= 100 && addCounter < maxAdds)
            {
                int spawnPoint = Random.Range(0, 10);
                Instantiate(add, addSpawnPoints[spawnPoint].transform.position, addSpawnPoints[spawnPoint].transform.rotation);
                timer = 0;
            }
        }

        if (round2)
        {
            maxAdds = 15;

            if (timer>=70 && addCounter < maxAdds)
            {
                int spawnPoint = Random.Range(0, 10);
                Instantiate(add, addSpawnPoints[spawnPoint].transform.position, addSpawnPoints[spawnPoint].transform.rotation);
                timer = 0;
            }
        }

        if (round3)
        {
            maxAdds = 20;

            if (timer >= 50 && addCounter < maxAdds)
            {
                int spawnPoint = Random.Range(0, 10);
                Instantiate(add, addSpawnPoints[spawnPoint].transform.position, addSpawnPoints[spawnPoint].transform.rotation);
                timer = 0;
            }
        }


        if (bossScript.cannonballHits==1)
        {
            round1 = false;
            round2 = true;
            round3 = false;
        }

        if (bossScript.cannonballHits >= 2)
        {
            round1 = false;
            round2 = false;
            round3 = true;
        }


    }


        }


        
	