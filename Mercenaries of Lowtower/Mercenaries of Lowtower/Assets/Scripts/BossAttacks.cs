using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttacks : MonoBehaviour {

    public Transform bossTorso;

    //Variable to hold the Transform of the currently targeted player
    public Transform targetedPlayer;

    //Variable to keep track of what phase the boss is currently in
    public int bossPhase;
    // bossPhase = 0 is the default phase
    // bossPhase = 1 is the PrepPunch phase
    // bossPhase = 2 is the ReleasePunch phase
    // bossPhase = 3 is the PrepSpin phase
    // bossPhase = 4 is the ReleaseSpin phase
    
    //Variable to hold the current speed of the boss
    public float speed;

    //Variable to hold the speed at which the boss rotates to orient itself toward the player
    public float rotateSpeed = 4f;

    Animator anim;

    // Use this for initialization
    void Start()
    {
        bossPhase = 0;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetInteger("bossPhase", bossPhase);

        if(bossPhase == 1)
        {
            PrepPunch();
        }
        if (bossPhase == 2)
        {
            ReleasePunch();
        }
        if (bossPhase == 3)
        {
            PrepSpin();
        }
        if (bossPhase == 4)
        {
            ReleaseSpin();
        }
        if (bossPhase == 5)
        {
            PrepSlam();
        }
        if (bossPhase == 6)
        {
            ReleaseSlam();
        }
    }

    void PrepPunch()
    {
        Debug.Log("Prepare punch!");
        //Gets the direction of the player from the boss/add as well as the correct rotation to look at the player
        Vector3 dir = targetedPlayer.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotateSpeed * Time.deltaTime);

        float dist = Vector3.Distance(targetedPlayer.position, transform.position);
        print("Distance to other: " + dist);

        if (dist >= 8)
        {
            //Moves the boss toward the targeted player
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetedPlayer.position, step);
        }

        if(dist <= 8)
        {
            bossPhase = 2;
        }
    }

    void ReleasePunch()
    {
        Debug.Log("Punch!");
    }

    void PrepSpin()
    {
        Debug.Log("Prepare spin!");

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(0,0,0), step);

        if(transform.position == new Vector3(0, 0, 0))
        {
            bossPhase = 4;
        }
    }

    void ReleaseSpin()
    {
        Debug.Log("Spin!");
        bossTorso.Rotate(new Vector3(0, Time.deltaTime * 100, 0));
    }

    void PrepSlam()
    {
        Debug.Log("Prepare Slam!");

        float dist = Vector3.Distance(targetedPlayer.position, transform.position);
        //print("Distance to other: " + dist);

        if (dist >= 8)
        {
            //Moves the boss toward the targeted player
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetedPlayer.position, step);
        }

        //Gets the direction of the player from the boss/add as well as the correct rotation to look at the player
        Vector3 dir = targetedPlayer.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotateSpeed * Time.deltaTime);

        if (dist <= 8)
        {
            bossPhase = 6;
        }
    }

    void ReleaseSlam()
    {
        Debug.Log("Release Slam!");

        float dist = Vector3.Distance(targetedPlayer.position, transform.position);
        print("Distance to other: " + dist);

        if (dist >= 8)
        {
            //Moves the boss toward the targeted player
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetedPlayer.position, step);
        }
    }
}
