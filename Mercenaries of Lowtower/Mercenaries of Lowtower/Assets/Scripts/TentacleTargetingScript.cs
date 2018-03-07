using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleTargetingScript : MonoBehaviour
{

    public List<Transform> PlayerList = new List<Transform>();
    public Animator anim;
    public Transform target;
    public float speed;
    public bool isCharging;
    public float waitTime;
    float waitTimeDefault;


    public BossControlScript bossManagerScript;


    // Use this for initialization
    void Start()
    {
        isCharging = true;
        target = PlayerList[Random.Range(0, 3)].GetComponent<Transform>();
        waitTimeDefault = waitTime;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isCharging == true)
        {
            //Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, target.position.z);
            //transform.LookAt(targetPosition);
            if(anim.GetBool("AttackDone")==true)
            {
                waitTime -= Time.deltaTime;

            }
            if (waitTime <=0)
            {
                anim.SetBool("AttackDone", false);
                TargetPlayer();
                waitTime = waitTimeDefault;
                anim.SetBool("AttackDone", true);
            }
            Vector3 direction = target.position - transform.position;
            direction.y = 0;

            //Quaternion toRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.LookRotation(direction, transform.up);

            //transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, Time.deltaTime * speed);
            Debug.DrawLine(transform.position, target.position, Color.red);
        }
        else
        {

        }
    }

    public void TargetPlayer()
    {

        target = PlayerList[Random.Range(0, 3)].GetComponent<Transform>();
    }

    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.name=="cannonball_prop(Clone)")
        {
            bossManagerScript.cannonFired=true;
        }
    }
    */
}
