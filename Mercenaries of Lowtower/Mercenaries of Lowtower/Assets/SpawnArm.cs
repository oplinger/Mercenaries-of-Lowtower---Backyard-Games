using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArm : MonoBehaviour {

    public GameObject armPrefab;
    float spawnTimer;
    public float tempSpawnTimer;

	// Use this for initialization
	void Start () {

        spawnTimer = 30;
        tempSpawnTimer = spawnTimer;

    }
	
	// Update is called once per frame
	void Update () {

        tempSpawnTimer -= 1;

        if (Input.GetKeyDown("space"))
        {
            Instantiate(armPrefab, transform.position, Quaternion.identity);
            tempSpawnTimer = 300;
        }
		
	}
}
