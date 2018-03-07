using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControlScriptV2 : MonoBehaviour {

    //
    public int bossPhase;
    // Current phase of the boss fight
    public int bossAttack;
    public int tentaclesReady;
    // The speed at which the tentacle elevates towards the endPoint
    public float elevationSpeed;
    // The speed at which the tentacle descends after slamming
    public float descendingSpeed;
    // How long before the boss starts attacking
    public float startTime;
    // Holds the wait time for coroutines
    private float waitTime;
    public bool isWaiting;
    public bool bossReady;
    //Array holding all the bosses tentacles
    public List<GameObject> BossTentaclesList = new List<GameObject>();
    public GameObject Boss;

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
            //beamActivated = false;
            /*
            if (Boss.GetComponent<BossClass>().currentHealth <= 195 && bossDamaged == false)
            {
                bossPhase = 5;
                bossDamaged = true;
            }
            */
            if (bossAttack == 1)
            {
                BossTentaclesList[0].GetComponent<BossTentacleScript>().tentacleRaising = true;
                BossTentaclesList[3].GetComponent<BossTentacleScript>().tentacleRaising = true;
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
                BossTentaclesList[4].GetComponent<BossTentacleScript>().tentacleRaising = true;
                BossTentaclesList[6].GetComponent<BossTentacleScript>().tentacleRaising = true;
                BossTentaclesList[8].GetComponent<BossTentacleScript>().tentacleRaising = true;
                bossAttack++;
            }

            if (bossAttack == 7)
            {
                BossTentaclesList[0].GetComponent<BossTentacleScript>().tentacleRaising = true;
                BossTentaclesList[3].GetComponent<BossTentacleScript>().tentacleRaising = true;
                BossTentaclesList[9].GetComponent<BossTentacleScript>().tentacleRaising = true;
                BossTentaclesList[12].GetComponent<BossTentacleScript>().tentacleRaising = true;
                bossAttack++;
            }

            if (bossAttack == 9)
            {
                BossTentaclesList[1].GetComponent<BossTentacleScript>().tentacleRaising = true;
                BossTentaclesList[2].GetComponent<BossTentacleScript>().tentacleRaising = true;
                BossTentaclesList[5].GetComponent<BossTentacleScript>().tentacleRaising = true;
                BossTentaclesList[7].GetComponent<BossTentacleScript>().tentacleRaising = true;
                BossTentaclesList[10].GetComponent<BossTentacleScript>().tentacleRaising = true;
                BossTentaclesList[11].GetComponent<BossTentacleScript>().tentacleRaising = true;
                bossAttack++;
            }

            if (bossAttack == 11)
            {
                BossTentaclesList[4].GetComponent<BossTentacleScript>().tentacleRaising = true;
                BossTentaclesList[6].GetComponent<BossTentacleScript>().tentacleRaising = true;
                BossTentaclesList[8].GetComponent<BossTentacleScript>().tentacleRaising = true;
                bossAttack++;
            }

            //
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
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(waitTime);
        //print("Waiting");
        bossAttack++;
        isWaiting = false;
    }

    public void CheckIfReady()
    {
        if (bossAttack == 2)
        {
            tentaclesReady++;
            if (tentaclesReady == 4)
            {
                print("Ready!");
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
            if (tentaclesReady == 3)
            {
                //print("Ready!");
                bossReady = true;
                tentaclesReady = 0;
            }
        }

        if (bossAttack == 8)
        {
            tentaclesReady++;
            if (tentaclesReady == 4)
            {
                //print("Ready!");
                bossReady = true;
                tentaclesReady = 0;
            }
        }

        if (bossAttack == 10)
        {
            tentaclesReady++;
            if (tentaclesReady == 6)
            {
                //print("Ready!");
                bossReady = true;
                tentaclesReady = 0;
            }
        }

        if (bossAttack == 12)
        {
            tentaclesReady++;
            if (tentaclesReady == 3)
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
}
