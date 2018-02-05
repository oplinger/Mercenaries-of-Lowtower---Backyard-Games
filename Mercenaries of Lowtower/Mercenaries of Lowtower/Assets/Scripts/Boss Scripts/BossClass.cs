using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossClass : EnemyClass {
    public float[] TentacleMaxHealth;
    public float[] TentacleCurrentHealth;
    public float tentacleHealthDelta;
    public GameObject[] tentacleArray;

	// Use this for initialization
	void Start () {
        //TentacleMaxHealth = new float[6];
        maxHealth = 200;
        currentHealth = maxHealth;

        //tentacleArray = GameObject.FindGameObjectsWithTag("Tentacle");
        //for (int i = 0; i < tentacleArray.Length; i++)
        //{
        //    TentacleMaxHealth[i] = tentacleArray[i].GetComponent<TentacleClass>().maxHealth;
        //    TentacleCurrentHealth[i] = tentacleArray[i].GetComponent<TentacleClass>().currentHealth;

            

        //}
    }
	
	// Update is called once per frame
	void Update () {

    }
}
