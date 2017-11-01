using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    GameObject[] objects;
    GameObject marker;
    float furthestTarget;
    float furthestTarget2;


    // Use this for initialization
    void Start () {
        objects = GameObject.FindGameObjectsWithTag("Player");
        marker = GameObject.CreatePrimitive(PrimitiveType.Cube);
        
	}
	
	// Update is called once per frame
	void Update () {
        FindPositions();
    }

    void FindPositions()
    {
        Vector3 averagePos = new Vector3();


        for (int i = 0; i < objects.Length; i++)
        {
            averagePos += objects[i].transform.position;

            if(furthestTarget< Vector3.Distance(marker.transform.position, objects[i].transform.position))
            {
                furthestTarget2 = Vector3.Distance(marker.transform.position, objects[i].transform.position);

            } else if (furthestTarget < Vector3.Distance(marker.transform.position, objects[i].transform.position))
            {
                furthestTarget2 = Vector3.Distance(marker.transform.position, objects[i].transform.position);
            }
        }
        //furthestTarget = Vector3.Distance(transform.position, objects[0].transform.position);
       // print(Vector3.Distance(transform.position, objects[0].transform.position));
        print(furthestTarget2);
        //print(furthestTarget2);

        averagePos /= objects.Length;
        //averagePos.y = transform.position.y;
        
        transform.position = averagePos;
        transform.position += new Vector3(0, Mathf.Clamp(furthestTarget2*3, 35,75), -15);
        //transform.position = new Vector3 (0, furthestTarget2, 0);
        marker.transform.position = averagePos;
        //transform.LookAt(averagePos);




        //float maxX = 0;
        //float maxY = 0;
        //float minX = 0;
        //float minY = 0;

        //    for (int i = 0; i < objects.Length; i++)
        //    {
        //        if (objects[i].transform.position.y > maxY)
        //        {
        //            maxY = objects[i].transform.position.y;
        //        }
        //        if (objects[i].transform.position.x > maxX)
        //        {
        //            maxX = objects[i].transform.position.x;
        //        }
        //        if (objects[i].transform.position.y < minY)
        //        {
        //            minY = objects[i].transform.position.y;
        //        }
        //        if (objects[i].transform.position.x < minX)
        //        {
        //            minX = objects[i].transform.position.x;
        //        }
        //    }
    }

}
