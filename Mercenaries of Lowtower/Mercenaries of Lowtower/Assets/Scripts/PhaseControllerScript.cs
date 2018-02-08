using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseControllerScript : MonoBehaviour {

    public GameObject boss;
    public GameObject cannon;
    public GameObject cannonball;
    public GameObject addSpawner;
    public Transform retreatWaypoint;
    public Transform cannonWaypoint;
    public bool armIsDead;
    public GameObject ballSpawner;

    public GameObject bossManager;

	// Use this for initialization
	void Start () {
        armIsDead = false;
		
	}
	
	// Update is called once per frame
	void Update () {
        if (armIsDead)
        {
            ActivatePhase2();
        }
		
	}

    public void ActivatePhase2()
    {
        //stop boss from attacking
        bossManager.SetActive(false);

        //boss retreating
        boss.transform.position = Vector3.MoveTowards(boss.transform.position, retreatWaypoint.position, .2f);

        //cannonball "spawning"
        cannonball.SetActive(true);

        //cannon rising from below the deck
        cannon.transform.position = Vector3.MoveTowards(cannon.transform.position, cannonWaypoint.position, .05f);

        //activates cannonball spawner
        ballSpawner.SetActive(true);

        //activates add spawner
        addSpawner.SetActive(true);
    }
}
