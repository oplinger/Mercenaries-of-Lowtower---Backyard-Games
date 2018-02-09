using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControlScript : MonoBehaviour {

    //Array holding all the bosses arms
    public List<GameObject> BossArmsList = new List<GameObject>();

    // Current phase of the boss fight
    public int bossAttack;
    public int bossSlamAttack;
    public int bossPhase;
    // How long before the boss starts attacking
    public float startTime;
    // Holds the wait time for coroutines
    private float waitTime;
    public float restTime;
    //
    public bool isWaiting;
    public int armsReady;
    public bool bossReady;

    // The speed at which the tentacle moves toward the waypoint
    public float beamSpeed;
    // Float to control how long the arm is down
    public float downTime;
    // The speed at which the tentacle elevates towards the endPoint
    public float elevationSpeed;
    // The speed at which the tentacle descends after slamming
    public float descendingSpeed;
    // The amount the tentacle rotates per frame while slamming
    public float rotationSpeed;

    public GameObject energySphere;
    public bool energySphereReady;

    public GameObject Boss;

    // Use this for initialization
    void Start()
    {
        bossAttack = 0;
        waitTime = startTime;
        isWaiting = true;
        StartCoroutine("WaitTime");
        StartCoroutine("EnergySphereCD");
    }

    // Update is called once per frame
    void Update()
    {

        if(bossPhase == 1)
        {
            if (Boss.GetComponent<BossClass>().currentHealth <= 190)
            {
                bossPhase = 2;
            }
            if (bossAttack == 1)
            {
                BossArmsList[0].GetComponent<BossArmScript>().armRaising = true;
                BossArmsList[1].GetComponent<BossArmScript>().armRaising = true;
                BossArmsList[2].GetComponent<BossArmScript>().armRaising = true;
                BossArmsList[3].GetComponent<BossArmScript>().armRaising = true;
                BossArmsList[7].GetComponent<BossArmScript>().armRaising = true;
                BossArmsList[8].GetComponent<BossArmScript>().armRaising = true;
                BossArmsList[9].GetComponent<BossArmScript>().armRaising = true;
                BossArmsList[10].GetComponent<BossArmScript>().armRaising = true;
                bossAttack++;
            }

            if (bossAttack == 3)
            {
                BossArmsList[3].GetComponent<BossArmScript>().armRaising = true;
                BossArmsList[4].GetComponent<BossArmScript>().armRaising = true;
                BossArmsList[5].GetComponent<BossArmScript>().armRaising = true;
                BossArmsList[6].GetComponent<BossArmScript>().armRaising = true;
                BossArmsList[7].GetComponent<BossArmScript>().armRaising = true;
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

                if (bossAttack == 5)
                {
                    bossAttack = 1;
                    bossReady = false;
                }
            }
        }

        if (bossPhase == 2)
        {
            if (bossAttack == 1)
            {
                BossArmsList[0].GetComponent<BossArmScript>().armRetreating = true;
                BossArmsList[1].GetComponent<BossArmScript>().armRetreating = true;
                BossArmsList[2].GetComponent<BossArmScript>().armRetreating = true;
                BossArmsList[3].GetComponent<BossArmScript>().armRetreating = true;
                BossArmsList[7].GetComponent<BossArmScript>().armRetreating = true;
                BossArmsList[8].GetComponent<BossArmScript>().armRetreating = true;
                BossArmsList[9].GetComponent<BossArmScript>().armRetreating = true;
                BossArmsList[10].GetComponent<BossArmScript>().armRetreating = true;
                bossAttack = 0;
            }

            if (bossAttack == 3)
            {
                BossArmsList[3].GetComponent<BossArmScript>().armRetreating = true;
                BossArmsList[4].GetComponent<BossArmScript>().armRetreating = true;
                BossArmsList[5].GetComponent<BossArmScript>().armRetreating = true;
                BossArmsList[6].GetComponent<BossArmScript>().armRetreating = true;
                BossArmsList[7].GetComponent<BossArmScript>().armRetreating = true;
                bossAttack = 0;
            }
            StartCoroutine("PausePhase");
        }

        if (bossPhase == 3)
        {
            if (energySphereReady == true)
            {
                Instantiate(energySphere);
                StartCoroutine("EnergySphereCD");
                energySphereReady = false;
            }
        }
        /*
        if (bossAttack == 5)
        {
            BossArmsList[0].GetComponent<BossArmScript>().armRaising = true;
            BossArmsList[1].GetComponent<BossArmScript>().armRaising = true;
            BossArmsList[2].GetComponent<BossArmScript>().armRaising = true;
            BossArmsList[3].GetComponent<BossArmScript>().armRaising = true;
            BossArmsList[4].GetComponent<BossArmScript>().armRaising = true;
            BossArmsList[5].GetComponent<BossArmScript>().armRaising = true;
            BossArmsList[6].GetComponent<BossArmScript>().armRaising = true;
            BossArmsList[7].GetComponent<BossArmScript>().armRaising = true;
            BossArmsList[8].GetComponent<BossArmScript>().armRaising = true;
            BossArmsList[9].GetComponent<BossArmScript>().armRaising = true;
            bossAttack++;
        }
        */

        /*
        if (Input.GetKeyDown(KeyCode.R))
        {
            BossArmsList[0].GetComponent<BossArmScript>().armRaising = true;
            BossArmsList[2].GetComponent<BossArmScript>().armRaising = true;
            BossArmsList[3].GetComponent<BossArmScript>().armRaising = true;
            BossArmsList[5].GetComponent<BossArmScript>().armRaising = true;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            BossArmsList[1].GetComponent<BossArmScript>().armRaising = true;
            BossArmsList[4].GetComponent<BossArmScript>().armRaising = true;
        }*/

        /*if (isWaiting == false)
        {
            if (bossAttack == 1)
            {
                foreach (GameObject objects in BossArmsList)
                {
                    print("Arms up!");
                    objects.GetComponent<BossArmScript>().armRaising = true;
                }
                isWaiting = true;
            }
        }*/
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(waitTime);
        print("Waiting");
        bossAttack++;
        isWaiting = false;
    }

    IEnumerator PausePhase()
    {
        yield return new WaitForSeconds(4);
        bossPhase++;
        StopCoroutine("PausePhase");
    }

    IEnumerator EnergySphereCD()
    {
        yield return new WaitForSeconds(8);
        energySphereReady = true;
    }


    public void CheckIfReady()
    {
        if (bossAttack == 2)
        {
            armsReady++;
            if (armsReady == 6)
            {
                print("Ready!");
                bossReady = true;
                armsReady = 0;
            }
        } else if (bossAttack == 4)
        {
            armsReady++;
            if (armsReady == 5)
            {
                print("Ready!");
                bossReady = true;
                armsReady = 0;
            }
        } else  if(bossAttack == 6)
        {
            armsReady++;
            if (armsReady == 10)
            {
                print("Ready!");
                bossReady = true;
                armsReady = 0;
            }
        }
        else
        {

        }
    }
}
