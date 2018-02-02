using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControlScript : MonoBehaviour {

    //Array holding all the bosses arms
    public List<GameObject> BossArmsList = new List<GameObject>();

    // Current phase of the boss fight
    public int bossPhase;
    public int bossSlamAttack;
    // How long before the boss starts attacking
    public float startTime;
    // Holds the wait time for coroutines
    private float waitTime;
    public float restTime;
    //
    public bool isWaiting;
    public int armsReady;
    public bool bossReady;

    public GameObject energySphere;
    public bool energySphereReady;

    // Use this for initialization
    void Start()
    {
        bossPhase = 0;
        waitTime = startTime;
        isWaiting = true;
        StartCoroutine("WaitTime");
        StartCoroutine("EnergySphereCD");
    }

    // Update is called once per frame
    void Update()
    {
        if (bossPhase == 1)
        {
            BossArmsList[0].GetComponent<BossArmScript>().armRaising = true;
            BossArmsList[2].GetComponent<BossArmScript>().armRaising = true;
            BossArmsList[3].GetComponent<BossArmScript>().armRaising = true;
            BossArmsList[5].GetComponent<BossArmScript>().armRaising = true;
            bossPhase++;
        }

        if (bossPhase == 3)
        {
            BossArmsList[1].GetComponent<BossArmScript>().armRaising = true;
            BossArmsList[4].GetComponent<BossArmScript>().armRaising = true;
            bossPhase++;
        }

        if (bossPhase == 5)
        {
            BossArmsList[0].GetComponent<BossArmScript>().armRaising = true;
            BossArmsList[1].GetComponent<BossArmScript>().armRaising = true;
            BossArmsList[2].GetComponent<BossArmScript>().armRaising = true;
            BossArmsList[3].GetComponent<BossArmScript>().armRaising = true;
            BossArmsList[4].GetComponent<BossArmScript>().armRaising = true;
            BossArmsList[5].GetComponent<BossArmScript>().armRaising = true;
            bossPhase++;
        }

        if(bossReady == true)
        {
            if (bossPhase == 2)
            {
                bossPhase = 3;
                bossReady = false;
            }

            if (bossPhase == 4)
            {
                bossPhase = 5;
                bossReady = false;
            }

            if (bossPhase == 6)
            {
                bossPhase = 1;
                bossReady = false;
            }
        }

        if(energySphereReady == true)
        {
            Instantiate(energySphere);
            StartCoroutine("EnergySphereCD");
            energySphereReady = false;
        }

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
            if (bossPhase == 1)
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
        bossPhase++;
        isWaiting = false;
    }

    IEnumerator EnergySphereCD()
    {
        yield return new WaitForSeconds(8);
        energySphereReady = true;
    }


    public void CheckIfReady()
    {
        if (bossPhase == 2)
        {
            armsReady++;
            if (armsReady == 4)
            {
                print("Ready!");
                bossReady = true;
                armsReady = 0;
            }
        } else if (bossPhase == 4)
        {
            armsReady++;
            if (armsReady == 2)
            {
                print("Ready!");
                bossReady = true;
                armsReady = 0;
            }
        } else  if(bossPhase == 6)
        {
            armsReady++;
            if (armsReady == 6)
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
