using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamTentacleScript : MonoBehaviour {

    // Original transform position
    Vector3 originPoint;
    // Transform for the waypoint of how far the beam will move
    public Transform beamEndPoint;
    // The speed at which the tentacle moves toward the waypoint
    public float beamSpeed;

    public bool endPointReached;

    // Use this for initialization
    void Start () {
        // Sets the origin point to the position the tentacles are in when the play button is pressed
        originPoint = gameObject.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if(endPointReached == false)
        {
            MoveBeam();
        }
        if(endPointReached == true)
        {
            ReturnBeam();
        }
    }

    void MoveBeam()
    {
        // Multiplies the elevation speed by time
        float step = beamSpeed * Time.deltaTime;
        // Moves the arm up towards the endPoint at a set speed
        transform.position = Vector3.MoveTowards(transform.position, beamEndPoint.transform.position, step);

        if (transform.position == beamEndPoint.transform.position)
        {
            endPointReached = true;
        }
    }

    void ReturnBeam()
    {
        // Multiplies the elevation speed by time
        float step = beamSpeed * Time.deltaTime;
        // Moves the arm up towards the endPoint at a set speed
        transform.position = Vector3.MoveTowards(transform.position, originPoint, step);

        if (transform.position == originPoint)
        {
            endPointReached = false;
        }
    }
}
