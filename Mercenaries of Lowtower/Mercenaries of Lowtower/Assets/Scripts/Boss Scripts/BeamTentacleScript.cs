using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamTentacleScript : MonoBehaviour {

    // Original transform position
    Vector3 originPoint;
    //
    public Transform ascentEndPoint;
    // Transform for the waypoint of how far the beam will move
    public Transform beamEndPoint;
    // The speed at which the tentacle moves toward the waypoint
    public float beamSpeed;
    //
    public float beamAscentSpeed;
    //
    public float beamDescentSpeed;
    //
    public bool ascentPointReached;
    // bool to check if the endPoint has been reached
    public bool endPointReached;
    // Holds a reference to the BossManager game object
    public GameObject BossManager;
    //
    public bool beamAscending;
    //
    public bool beamDescending;
    //
    public bool beamAdvancing;
    //
    public bool beamReturning;
    //
    public int numDescents;
    //
    public int descentCap;

    // Use this for initialization
    void Start () {
        // Sets the origin point to the position the tentacles are in when the play button is pressed
        originPoint = gameObject.transform.position;
        beamSpeed = BossManager.GetComponent<BossControlScriptV2>().beamSpeed;
    }
	
	// Update is called once per frame
	void Update () {
        SpeedUp();
        if (beamAscending == true)
        {
            RaiseBeam();
        }

        if (beamAdvancing == true)
        {
            AdvanceBeam();
        }

        if (beamReturning == true)
        {
            ReturnBeam();
        }


        if (beamDescending == true)
        {
            LowerBeam();
        }

        if(endPointReached == true)
        {
            BossManager.GetComponent<BossControlScriptV2>().beamsDone++;
            print("BEAMS DONE!");
            print("BEAMS DONE!");
            print("BEAMS DONE!");
            print("BEAMS DONE!");
            print("BEAMS DONE!");
            print("BEAMS DONE!");
            numDescents = 0;
            endPointReached = false;
        }

        /*
        if (attackComplete == true)
        {
            BossManager.GetComponent<BossControlScriptV2>().CheckIfReady();
            attackComplete = false;
        }
        */
    }

    void RaiseBeam()
    {
        // Multiplies the elevation speed by time
        float upStep = beamAscentSpeed * Time.deltaTime;
        // Moves the arm up towards the endPoint at a set speed
        //transform.position = Vector3.MoveTowards(transform.position, endPoint, upStep);
        transform.position = Vector3.MoveTowards(transform.position, ascentEndPoint.transform.position, upStep);

        if (transform.position == ascentEndPoint.transform.position)
        {
            beamAdvancing = true;
            beamAscending = false;
        }
    }

    void AdvanceBeam()
    {
        // Multiplies the elevation speed by time
        float step = beamSpeed * Time.deltaTime;
        // Moves the arm up towards the endPoint at a set speed
        transform.position = Vector3.MoveTowards(transform.position, beamEndPoint.transform.position, step);

        if (transform.position == beamEndPoint.transform.position)
        {
            beamReturning = true;
            beamAdvancing = false;
        }
    }

    void ReturnBeam()
    {
        // Multiplies the elevation speed by time
        float step = beamSpeed * Time.deltaTime;
        // Moves the arm up towards the endPoint at a set speed
        transform.position = Vector3.MoveTowards(transform.position, ascentEndPoint.transform.position, step);

        if (transform.position == ascentEndPoint.transform.position)
        {
            beamDescending = true;
            beamReturning = false;
        }
    }

    void LowerBeam()
    {
        // Multiplies the elevation speed by time
        float downStep = beamDescentSpeed * Time.deltaTime;
        // Moves the arm up towards the endPoint at a set speed
        transform.position = Vector3.MoveTowards(transform.position, originPoint, downStep);

        if (transform.position == originPoint)
        {
            beamDescending = false;
            numDescents++;
            if (numDescents < descentCap)
            {
                beamAscending = true;
            }
            else
            {
                endPointReached = true;
                //attackComplete = true;
            }
        }
    }

    public void SpeedUp()
    {
        beamSpeed = BossManager.GetComponent<BossControlScriptV2>().beamSpeed;
    }
}
