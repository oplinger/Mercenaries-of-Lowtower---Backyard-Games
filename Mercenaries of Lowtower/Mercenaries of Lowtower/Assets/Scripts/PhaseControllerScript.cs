using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseControllerScript : MonoBehaviour {

    public GameObject boss;
    public GameObject cannon;
    public GameObject cannonball;
    public GameObject addSpawner;
    public Transform retreatWaypoint;
    public Transform returnWaypoint;
    public Transform cannonWaypoint;
    public bool armIsDead;
    public bool cannonFired;
    public GameObject ballSpawner;

    public GameObject bossManager;

    Vector3 bossOriginalposition;

	// Use this for initialization
	void Start () {
        armIsDead = false;
        bossOriginalposition = boss.transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {

        if (armIsDead && cannon.transform.position!=cannonWaypoint.transform.position)
        {
            ActivatePhase2();
        }
        

        if (cannonFired)
        {
            armIsDead = false;
            ActivatePhase3();
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

    public void ActivatePhase3()
    {
        print("phase activated");
        //stop boss from attacking
        bossManager.SetActive(true);

        //boss retreating
        boss.transform.position = Vector3.MoveTowards(boss.transform.position, bossOriginalposition, .2f);
    }
}
