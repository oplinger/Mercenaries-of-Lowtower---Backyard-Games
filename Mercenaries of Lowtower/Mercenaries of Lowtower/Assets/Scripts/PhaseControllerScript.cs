using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseControllerScript : MonoBehaviour {

    public GameObject bossHead;
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
    public Transform cameraPosition2;
    BossControlScript bossScript;
    public GameObject[] doors;

    //public Camera camera;

	// Use this for initialization
	void Start () {
        armIsDead = false;
        bossOriginalposition = bossHead.transform.position;

        bossScript = bossManager.GetComponent<BossControlScript>();
	}
	
	// Update is called once per frame
	void Update () {

        if (bossScript.bossPhase==6)
        {
            print("phase 2 on phase manager active");
            ActivatePhase2();
            
            for(int i=0; i<doors.Length; i++)
            {
                doors[i].transform.position -= new Vector3(0, 10, 0);
            }

        }

        //if (armIsDead && cannon.transform.position!=cannonWaypoint.transform.position)
        //{
        //    ActivatePhase2();
        //}
        

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

        //boss stops tracking player movement
        bossHead.GetComponent<BossLookAt>().enabled = false;

        //boss retreating
        bossHead.transform.position = Vector3.MoveTowards(bossHead.transform.position, retreatWaypoint.position, .2f);

        //cannonball "spawning"
        cannonball.SetActive(true);

        ////cannon rising from below the deck
        //cannon.transform.position = Vector3.MoveTowards(cannon.transform.position, cannonWaypoint.position, .05f);

        //camera pulling back
        Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, cameraPosition2.position, .05f);

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
        bossHead.transform.position = Vector3.MoveTowards(bossHead.transform.position, bossOriginalposition, .2f);
    }
}
