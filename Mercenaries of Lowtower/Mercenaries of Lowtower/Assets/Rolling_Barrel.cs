using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rolling_Barrel : MonoBehaviour
{

    // Original transform position
    Vector3 originPoint;
    // Transform for the waypoint of how far the beam will move
    public Transform barrelEndPoint;
    // The speed at which the tentacle moves toward the waypoint
    public float barrelSpeed;
    // bool to check if the endPoint has been reached
    public bool endPointReached;

    // Holds a reference to the BossManager game object
    public GameObject BarrelManager;

    // Use this for initialization
    void Start()
    {
        // Sets the origin point to the position the tentacles are in when the play button is pressed
        originPoint = gameObject.transform.position;
      //  barrelSpeed = BarrelManager.GetComponent<Barrel_Manager>().barrelSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (endPointReached == false)
        {
            MoveBarrel();
        }
        if (endPointReached == true)
        {
            ReturnBarrel();
        }
    }

    void MoveBarrel()
    {
        // Multiplies the elevation speed by time
        float step = barrelSpeed * Time.deltaTime;
        // Moves the arm up towards the endPoint at a set speed
        transform.position = Vector3.MoveTowards(transform.position, barrelEndPoint.transform.position, step);

        if (transform.position == barrelEndPoint.transform.position)
        {
            endPointReached = true;
        }
    }

    void ReturnBarrel()
    {
        // Multiplies the elevation speed by time
        float step = barrelSpeed * Time.deltaTime;
        // Moves the arm up towards the endPoint at a set speed
        transform.position = Vector3.MoveTowards(transform.position, originPoint, step);

        if (transform.position == originPoint)
        {
            endPointReached = false;
        }
    }
}
