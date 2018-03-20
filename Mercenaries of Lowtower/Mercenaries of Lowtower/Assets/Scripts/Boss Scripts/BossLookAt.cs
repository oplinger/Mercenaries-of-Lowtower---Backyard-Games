using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLookAt : MonoBehaviour
{

    public List<Transform> PlayerList = new List<Transform>();
    public Transform target;
    public Transform tempTarget;
    public float speed;
    public int targetNum;
    public int lastTargetNum;
    public bool isCharging;
    public bool targetAcquired;
    public bool newNumGenerated;
    public bool targetDead;
    public GameObject targetIndicator;

    public BossControlScript bossManagerScript;


    // Use this for initialization
    void Start()
    {
        targetNum = Random.Range(0, 3);
        lastTargetNum = targetNum;
        target = PlayerList[targetNum].GetComponent<Transform>();
        targetAcquired = true;
        isCharging = false;
        //target = PlayerList[Random.Range(0, 3)].GetComponent<Transform>();
    }

    private void Update()
    {
        if (target.GetComponent<TargetStats>().isDead)
        {
            
            RandomTarget();
        }
        TargetPlayer();
        if (targetAcquired == false)
        {
            TargetPlayer();
            targetAcquired = true;
        }



        //if(newNumGenerated == false)
        //{
        //    RandomTarget();
        //    tempTarget = PlayerList[targetNum].GetComponent<Transform>();
        //    targetDead = tempTarget.GetComponent<TargetStats>().isDead;
        //}


        //if (lastTargetNum != targetNum && targetDead != true)
        //{
        //    newNumGenerated = true;
        //}

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (isCharging == true)
        {
            Vector3 direction = target.position - transform.position;
            direction.y = 0;

            Quaternion toRotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, Time.deltaTime * speed);
            Debug.DrawLine(transform.position, target.position, Color.red);
        }
        else
        {

        }
    }

    public void TargetPlayer()
    {
        target = PlayerList[targetNum].GetComponent<Transform>();
        lastTargetNum = targetNum;

        /*
        target = PlayerList[targetNum].GetComponent<Transform>();
        Instantiate(targetIndicator, target);
        */

        //target = PlayerList[Random.Range(0, 3)].GetComponent<Transform>();

        //else
        //{
        //    target = PlayerList[targetNum].GetComponent<Transform>();
        //    Instantiate(targetIndicator, target);
        //    newNumGenerated = false;
        //}
    }

    void RandomTarget()
    {
        for (int i = 0; i <= 10; i++)
        {
            if (targetNum == lastTargetNum)
            {
                targetNum = Random.Range(0, 3);
                //lastTargetNum = targetNum;
            } else
            {
                break;
            }
        }
        /*
        targetNum = Random.Range(0, 3);
        targCheck = PlayerList[targetNum].GetComponent<GameObject>();

        if(targCheck.GetComponent<TargetStats>().isDead == false)
        {
            deathCheck = true;
        }
        */
    }
}