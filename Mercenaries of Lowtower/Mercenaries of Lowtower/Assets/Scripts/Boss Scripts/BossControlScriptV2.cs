using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControlScriptV2 : MonoBehaviour {

    //
    public int bossPhase;
    // Current phase of the boss fight
    public int bossAttack;
    public int beamsDone;
    public int tentaclesReady;
    // The speed at which the tentacle elevates towards the endPoint
    public float elevationSpeed;
    // The speed at which the tentacle descends after slamming
    public float descendingSpeed;
    // The speed at which the tentacle moves toward the waypoint
    public float beamSpeed;
    // How long before the boss starts attacking
    public float startTime;
    // Holds the wait time for coroutines
    private float waitTime;
    public bool isWaiting;
    public bool bossReady;
    public bool energySphereReady;
    public bool beamActivated;
    public bool beamAttackComplete;
    public bool energySphereFired;
    public bool bossDamaged;
    //Array holding all the bosses tentacles
    public List<GameObject> BossTentaclesList = new List<GameObject>();
    public List<GameObject> BossBeamList = new List<GameObject>();
    public GameObject Boss;
    public GameObject BossHead;
    public GameObject energySphere;
    public Transform energySphereSpawn;

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
    void Start () {
        bossAttack = 0;
        waitTime = startTime;
        isWaiting = true;
        StartCoroutine("WaitTime");
    }
	
	// Update is called once per frame
	void Update () {
        if (bossPhase == 1)
        {
            
            if (Boss.GetComponent<BossClass>().currentHealth <= 100 && bossDamaged == false)
            {
                bossPhase = 5;
                bossDamaged = true;
            }
            
            if (bossAttack == 1)
            {
                BossTentaclesList[0].GetComponent<BossTentacleScript>().tentacleRaising = true;
                BossTentaclesList[3].GetComponent<BossTentacleScript>().tentacleRaising = true;
                BossTentaclesList[6].GetComponent<BossTentacleScript>().tentacleRaising = true;
                BossTentaclesList[9].GetComponent<BossTentacleScript>().tentacleRaising = true;
                BossTentaclesList[12].GetComponent<BossTentacleScript>().tentacleRaising = true;
                bossAttack++;
            }

            if (bossAttack == 3)
            {
                BossTentaclesList[1].GetComponent<BossTentacleScript>().tentacleRaising = true;
                BossTentaclesList[2].GetComponent<BossTentacleScript>().tentacleRaising = true;
                BossTentaclesList[5].GetComponent<BossTentacleScript>().tentacleRaising = true;
                BossTentaclesList[7].GetComponent<BossTentacleScript>().tentacleRaising = true;
                BossTentaclesList[10].GetComponent<BossTentacleScript>().tentacleRaising = true;
                BossTentaclesList[11].GetComponent<BossTentacleScript>().tentacleRaising = true;
                bossAttack++;
            }

            if (bossAttack == 5)
            {
                BossTentaclesList[0].GetComponent<BossTentacleScript>().tentacleRaising = true;
                BossTentaclesList[4].GetComponent<BossTentacleScript>().tentacleRaising = true;
                BossTentaclesList[6].GetComponent<BossTentacleScript>().tentacleRaising = true;
                BossTentaclesList[8].GetComponent<BossTentacleScript>().tentacleRaising = true;
                BossTentaclesList[12].GetComponent<BossTentacleScript>().tentacleRaising = true;
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
                    bossPhase = 2;
                    bossReady = false;
                }
            }
        }

        if (bossPhase == 2)
        {
            bossAttack = 0;
            BossHead.GetComponent<BossLookAt>().targetAcquired = false;
            BossHead.GetComponent<BossLookAt>().isCharging = true;
            StartCoroutine("EnergySphereCD");
            bossPhase = 3;
        }

        if (bossPhase == 3)
        {
            if (energySphereReady == true)
            {
                BossHead.GetComponent<BossLookAt>().isCharging = false;
                BossHead.GetComponent<BossLookAt>().targetAcquired = false;
                Instantiate(energySphere, energySphereSpawn.position, energySphereSpawn.rotation);
                energySphereFired = true;
                energySphereReady = false;
            }

            if(energySphereFired == true)
            {
                StartCoroutine("EnergySphereCD");
                energySphereFired = false;
            }

            if (beamActivated == false)
            {
                BossBeamList[0].GetComponent<BeamTentacleScript>().beamAscending = true;
                BossBeamList[1].GetComponent<BeamTentacleScript>().beamAscending = true;
                beamActivated = true;
            }

            CheckBeams();

            if (beamAttackComplete == true)
            {
                bossPhase = 4;
                beamAttackComplete = false;
            }
        }

        if (bossPhase == 4)
        {
            BossHead.GetComponent<BossLookAt>().target = null;
            beamActivated = false;
            beamsDone = 0;
            bossAttack = 1;
            BoostSpeed();
            bossPhase = 1;
        }

        if(bossPhase == 5)
        {
            BeginCannonPhase();
        }

        if (bossPhase == 6)
        {
            if (cannonFired == true)
            {
                cannonballHits++;
                cannonFired = false;
                Boss.GetComponent<BossClass>().currentHealth -= 33;
                
            }
            if (cannonballHits >= 3)
            {
                bossPhase = 7;
            }
        }

        if (bossPhase == 7)
        {
            BossHead.transform.position += (Vector3.down * Time.deltaTime) * 3;
            ballSpawner.SetActive(false);
            addSpawner.SetActive(false);
            cannonball.SetActive(false);
        }
    }

    public void BoostSpeed()
    {
        if(elevationSpeed <= 140f)
        {
            elevationSpeed = elevationSpeed + 20f;
        }
        if (descendingSpeed <= 140f)
        {
            descendingSpeed = descendingSpeed + 70f;
        }
        if(beamSpeed <= 2.5f)
        {
            beamSpeed = beamSpeed + 2.5f;
        }
    }
    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(waitTime);
        //print("Waiting");
        bossAttack++;
        isWaiting = false;
    }

    IEnumerator EnergySphereCD()
    {
        yield return new WaitForSeconds(4);
        //BossHead.GetComponent<BossLookAt>().TargetPlayer();
        energySphereReady = true;
    }

    public void CheckIfReady()
    {
        if (bossAttack == 2)
        {
            tentaclesReady++;
            if (tentaclesReady == 5)
            {
                bossReady = true;
                tentaclesReady = 0;
            }
        }
        if (bossAttack == 4)
        {
            tentaclesReady++;
            if (tentaclesReady == 6)
            {
                //print("Ready!");
                bossReady = true;
                tentaclesReady = 0;
            }
        }
        if (bossAttack == 6)
        {
            tentaclesReady++;
            if (tentaclesReady == 5)
            {
                //print("Ready!");
                bossReady = true;
                tentaclesReady = 0;
            }
        }
        else
        {

        }
    }

    public void CheckBeams()
    {
        if (beamsDone == 2)
        {
            beamAttackComplete = true;
        }
    }

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

        if (BossHead.transform.position == retreatWaypoint.position && Camera.main.transform.position == cameraPosition2.position)
        {
            bossPhase = 6;
        }
    }
}
