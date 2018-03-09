using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLookAt : MonoBehaviour
{

    public List<Transform> PlayerList = new List<Transform>();
    public Transform target;
    public float speed;
    public int targetNum;
    public int lastTargetNum;
    public bool isCharging;
    public bool targetAcquired;
    public bool newNumGenerated;
    public GameObject targetIndicator;

    public BossControlScript bossManagerScript;


    // Use this for initialization
    void Start()
    {
        targetAcquired = true;
        isCharging = false;
        //target = PlayerList[Random.Range(0, 3)].GetComponent<Transform>();
    }

    private void Update()
    {
        if(targetAcquired == false)
        {
            TargetPlayer();
            targetAcquired = true;
        }

        if(newNumGenerated == false)
        {
            RandomTarget();
        }

        if (lastTargetNum != targetNum || targetNum != 0)
        {
            newNumGenerated = true;
        }
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
        //target = PlayerList[Random.Range(0, 3)].GetComponent<Transform>();
        if(lastTargetNum != targetNum || targetNum != 0)
        {
            target = PlayerList[targetNum].GetComponent<Transform>();
            Instantiate(targetIndicator, target);
            newNumGenerated = false;
        }
    }

    void RandomTarget()
    {
        targetNum = Random.Range(0, 3);
    }
}