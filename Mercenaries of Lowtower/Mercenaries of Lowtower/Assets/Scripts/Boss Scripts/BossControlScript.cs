using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControlScript : MonoBehaviour {

    //Array holding all the bosses arms
    public List<GameObject> BossArmsList = new List<GameObject>();
    public List<GameObject> BossBeamList = new List<GameObject>();
    public GameObject Boss;
    public GameObject BossHead;
    public GameObject energySphere;
    public Transform energySphereSpawn;

    // The speed at which the tentacle moves toward the waypoint
    public float beamSpeed;
    // The speed at which the tentacle elevates towards the endPoint
    public float elevationSpeed;
    // The speed at which the tentacle descends after slamming
    public float descendingSpeed;
    // The amount the tentacle rotates per frame while slamming
    public float rotationSpeed;

    // How long before the boss starts attacking
    public float startTime;
    // Holds the wait time for coroutines
    private float waitTime;
    // Float to control how long the arm is down
    public float downTime;

    //
    public int bossPhase;
    // Current phase of the boss fight
    public int bossAttack;
    public int armsReady;
    public int beamsDone;


    public bool isWaiting;
    public bool bossReady;
    public bool energySphereReady;
    public bool beamActivated;
    public bool beamAttackComplete;

    public bool bossDamaged;

    //PhaseControllerScript variables
    public GameObject cannon;
    public GameObject cannonball;
    public GameObject addSpawner;
    public Transform retreatWaypoint;
    public Transform returnWaypoint;
    public Transform cannonWaypoint;
    public bool cannonFired;
    public GameObject ballSpawner;
    public Vector3 bossOriginalPosition;
    public Transform cameraPosition2;
    public List<GameObject> DoorList = new List<GameObject>();
    public float cannonballHits;
    //

    // Use this for initialization
    void Start()
    {
        bossAttack = 0;
        bossOriginalPosition = BossHead.transform.position;
        cannonballHits = 0;
        waitTime = startTime;
        isWaiting = true;
        StartCoroutine("WaitTime");
        //StartCoroutine("EnergySphereCD");
    }

    // Update is called once per frame
    void Update()
    {

        if(bossPhase == 1)
        {
            beamActivated = false;
            if (Boss.GetComponent<BossClass>().currentHealth <= 197 && bossDamaged == false)
            {
                bossPhase = 5;
                bossDamaged = true;
            }
            if (bossAttack == 1)
            {
                BossArmsList[0].GetComponent<BossArmScript>().armRaising = true;
                BossArmsList[1].GetComponent<BossArmScript>().armRaising = true;
                BossArmsList[2].GetComponent<BossArmScript>().armRaising = true;
                BossArmsList[8].GetComponent<BossArmScript>().armRaising = true;
                BossArmsList[9].GetComponent<BossArmScript>().armRaising = true;
                BossArmsList[10].GetComponent<BossArmScript>().armRaising = true;
                bossAttack++;
            }

            if (bossAttack == 3)
            {
                BossArmsList[4].GetComponent<BossArmScript>().armRaising = true;
                BossArmsList[5].GetComponent<BossArmScript>().armRaising = true;
                BossArmsList[6].GetComponent<BossArmScript>().armRaising = true;
                bossAttack++;
            }

            if (bossAttack == 5)
            {
                BossArmsList[0].GetComponent<BossArmScript>().armRaising = true;
                BossArmsList[2].GetComponent<BossArmScript>().armRaising = true;
                BossArmsList[3].GetComponent<BossArmScript>().armRaising = true;
                BossArmsList[7].GetComponent<BossArmScript>().armRaising = true;
                BossArmsList[8].GetComponent<BossArmScript>().armRaising = true;
                BossArmsList[10].GetComponent<BossArmScript>().armRaising = true;
                bossAttack++;
            }

            if (bossAttack == 7)
            {
                BossArmsList[1].GetComponent<BossArmScript>().armRaising = true;
                BossArmsList[2].GetComponent<BossArmScript>().armRaising = true;
                BossArmsList[4].GetComponent<BossArmScript>().armRaising = true;
                BossArmsList[5].GetComponent<BossArmScript>().armRaising = true;
                BossArmsList[6].GetComponent<BossArmScript>().armRaising = true;
                BossArmsList[8].GetComponent<BossArmScript>().armRaising = true;
                BossArmsList[9].GetComponent<BossArmScript>().armRaising = true;
                bossAttack++;
            }

            if (bossAttack == 9)
            {
                BossArmsList[0].GetComponent<BossArmScript>().armRaising = true;
                BossArmsList[1].GetComponent<BossArmScript>().armRaising = true;
                BossArmsList[3].GetComponent<BossArmScript>().armRaising = true;
                BossArmsList[4].GetComponent<BossArmScript>().armRaising = true;
                BossArmsList[6].GetComponent<BossArmScript>().armRaising = true;
                BossArmsList[7].GetComponent<BossArmScript>().armRaising = true;
                BossArmsList[9].GetComponent<BossArmScript>().armRaising = true;
                BossArmsList[10].GetComponent<BossArmScript>().armRaising = true;
                bossAttack++;
            }

            if (bossAttack == 11)
            {
                BossArmsList[0].GetComponent<BossArmScript>().armRaising = true;
                BossArmsList[1].GetComponent<BossArmScript>().armRaising = true;
                BossArmsList[2].GetComponent<BossArmScript>().armRaising = true;
                BossArmsList[4].GetComponent<BossArmScript>().armRaising = true;
                BossArmsList[5].GetComponent<BossArmScript>().armRaising = true;
                BossArmsList[6].GetComponent<BossArmScript>().armRaising = true;
                BossArmsList[8].GetComponent<BossArmScript>().armRaising = true;
                BossArmsList[9].GetComponent<BossArmScript>().armRaising = true;
                BossArmsList[10].GetComponent<BossArmScript>().armRaising = true;
                bossAttack++;
            }

            if (bossReady == true)
            {
                if (bossAttack == 2)
                {
                    bossAttack = 3;
                    bossReady = false;
                }

                if (bossAttack == 4)
                {
                    bossAttack = 5;
                    bossReady = false;
                }

                if (bossAttack == 6)
                {
                    bossAttack = 7;
                    bossReady = false;
                }

                if (bossAttack == 8)
                {
                    bossAttack = 9;
                    bossReady = false;
                }

                if (bossAttack == 10)
                {
                    bossAttack = 11;
                    bossReady = false;
                }

                if (bossAttack == 12)
                {
                    bossPhase = 2;
                    bossReady = false;
                }
            }
        }

        
        if (bossPhase == 2)
        {
            bossAttack = 0;
            StartCoroutine("EnergySphereCD");
            bossPhase = 3;
        }

        if (bossPhase == 3)
        {
            if (energySphereReady == true)
            {
                BossHead.GetComponent<BossLookAt>().isCharging = false;
                Instantiate(energySphere, energySphereSpawn.position, energySphereSpawn.rotation);
                StartCoroutine("EnergySphereCD");
                energySphereReady = false;
            }

            if (beamActivated == false)
            {
                BossBeamList[0].GetComponent<BeamTentacleScript>().beamAscending = true;
                BossBeamList[1].GetComponent<BeamTentacleScript>().beamAscending = true;
                BossBeamList[2].GetComponent<BeamTentacleScript>().beamAscending = true;
                BossBeamList[3].GetComponent<BeamTentacleScript>().beamAscending = true;
                beamActivated = true;
            }

            CheckBeams();

            if (beamAttackComplete == true)
            {
                bossPhase = 4;
                beamAttackComplete = false;
            }
        }

        if(bossPhase == 4)
        {
            beamsDone = 0;
            bossAttack = 5;
            bossPhase = 1;
        }

        
        if (bossPhase == 5)
        {
            if (bossAttack == 2)
            {
                bossAttack = 0;
                bossPhase = 6;
            }

            if (bossAttack == 4)
            {
                bossAttack = 0;
                bossPhase = 6;
            }

            if (bossAttack == 6)
            {
                bossAttack = 0;
                bossPhase = 6;
            }

            if (bossAttack == 8)
            {
                bossAttack = 0;
                bossPhase = 6;
            }

            if (bossAttack == 10)
            {
                bossAttack = 0;
                bossPhase = 6;
            }

            if (bossAttack == 12)
            {
                bossAttack = 0;
                bossPhase = 6;
            }
        }
        
        if(bossPhase == 6)
        {
            BeginCannonPhase();
        }

        if(bossPhase == 7)
        {
            if (cannonFired == true)
            {
                cannonballHits++;
                cannonFired = false;
            }
            if (cannonballHits >= 3)
            {
                bossPhase = 8;
            }
        }

        if(bossPhase == 8)
        {
            BossHead.transform.position += (Vector3.down * Time.deltaTime) * 3;
            ballSpawner.SetActive(false);
            addSpawner.SetActive(false);
            cannonball.SetActive(false);
        }
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(waitTime);
        //print("Waiting");
        bossAttack++;
        isWaiting = false;
    }

    /*
    IEnumerator PausePhase()
    {
        bossAttack = 0;
        yield return new WaitForSeconds(2);
        bossPhase = 3;
        //StopCoroutine("PausePhase");
    }
    */

    IEnumerator EnergySphereCD()
    {
        //BossHead.GetComponent<BossLookAt>().TargetPlayer();
        yield return new WaitForSeconds(6);
        energySphereReady = true;
    }

    public void CheckBeams()
    {
        if(beamsDone == 2)
        {
            beamAttackComplete = true;
        }
    }

    public void CheckIfReady()
    {
        if (bossAttack == 2)
        {
            armsReady++;
            if (armsReady == 6)
            {
                //print("Ready!");
                bossReady = true;
                armsReady = 0;
            }
        }
        if (bossAttack == 4)
        {
            armsReady++;
            if (armsReady == 3)
            {
                //print("Ready!");
                bossReady = true;
                armsReady = 0;
            }
        }
        if (bossAttack == 6)
        {
            armsReady++;
            if (armsReady == 6)
            {
                //print("Ready!");
                bossReady = true;
                armsReady = 0;
            }
        }

        if (bossAttack == 8)
        {
            armsReady++;
            if (armsReady == 7)
            {
                //print("Ready!");
                bossReady = true;
                armsReady = 0;
            }
        }

        if (bossAttack == 10)
        {
            armsReady++;
            if (armsReady == 8)
            {
                //print("Ready!");
                bossReady = true;
                armsReady = 0;
            }
        }

        if (bossAttack == 12)
        {
            armsReady++;
            if (armsReady == 9)
            {
                //print("Ready!");
                bossReady = true;
                armsReady = 0;
            }
        }
        else
        {

        }
    }

    //

    public void BeginCannonPhase()
    {
        //Moves the bosses head to the retreat waypoint position
        BossHead.transform.position = Vector3.MoveTowards(BossHead.transform.position, retreatWaypoint.position, .2f);
        //Activates the cannonball
        cannonball.SetActive(true);
        //Moves  the camera to the pulled back position
        Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, cameraPosition2.position, .05f);
        //Activates the cannonball spawner
        ballSpawner.SetActive(true);
        //Activates the enemy spawner
        addSpawner.SetActive(true);

        for (int i = 0; i < DoorList.Count; i++)
        {
            DoorList[i].transform.position -= new Vector3(0, 10, 0);
        }

        if(BossHead.transform.position == retreatWaypoint.position && Camera.main.transform.position == cameraPosition2.position)
        {
            bossPhase = 7;
        }
    }
}
