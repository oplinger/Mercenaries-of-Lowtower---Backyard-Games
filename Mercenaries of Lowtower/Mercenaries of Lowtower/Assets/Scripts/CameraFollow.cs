using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    GameObject[] objects;
    GameObject marker;
    float furthestTarget;
    float furthestTarget2;
    float maxX = -100;
    float maxY = -100;
    float minX = 100;
    float minY = 100;
    float maxZ = -100;
    float minZ = 100;


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
        //Vector3 averagePos = new Vector3();
        furthestTarget2 = Vector3.Distance(marker.transform.position, objects[2].transform.position);

        for (int i = 0; i < objects.Length; i++)
        {
            //averagePos += objects[i].transform.position;
            furthestTarget = Vector3.Distance(marker.transform.position, objects[i].transform.position);
            if (furthestTarget < Vector3.Distance(marker.transform.position, objects[i].transform.position))
            {
                furthestTarget = Vector3.Distance(marker.transform.position, objects[i].transform.position);

            }
            else if (furthestTarget < Vector3.Distance(marker.transform.position, objects[i].transform.position))
            {
                furthestTarget = Vector3.Distance(marker.transform.position, objects[i].transform.position);
            }
        }
            //averagePos /= objects.Length;       
            //transform.position = averagePos;
            //transform.position += new Vector3(0, Mathf.Clamp(furthestTarget2*3, 35,75), -15);
            


            float currminX = 0;
        float currminY = 0;
        float currminZ = 0;
        float currmaxX = 0;
        float currmaxY = 0;
        float currmaxZ = 0;

        for (int i = 0; i < objects.Length; i++)
        {
            //float currminX = 0;
            //float currminY = 0;
            //float currminZ = 0;
            //float currmaxX = 0;
            //float currmaxY = 0;
            //float currmaxZ = 0;



            if (objects[i].transform.position.y > maxY)
            {
                maxY = objects[i].transform.position.y;
            }
            if (objects[i].transform.position.x > maxX)
            {
                maxX = objects[i].transform.position.x;
            }
            if (objects[i].transform.position.y < minY)
            {
                minY = objects[i].transform.position.y;
            }
            if (objects[i].transform.position.x < minX)
            {
                minX = objects[i].transform.position.x;
            }
            if (objects[i].transform.position.z > maxZ)
            {
                maxZ = objects[i].transform.position.z;
            }
            if (objects[i].transform.position.z < minZ)
            {
                minZ = objects[i].transform.position.z;
            }
             currminX = minX;
             currminY = minY;
             currminZ = minZ;
             currmaxX = maxX;
             currmaxY = maxY;
             currmaxZ = maxZ;
        }
        minX = 100;
        minY = 100;
        minZ = 100;
        maxX = -100;
        maxY = -100;
        maxZ = -100;
        Vector3 centerpos = new Vector3((currminX + currmaxX) / 2, (currminY + currmaxY) / 2, (currminZ + currmaxZ) / 2);
        transform.position = centerpos;
        transform.position += new Vector3(0, Mathf.Clamp(furthestTarget2 * 1.5f, 25, 500), -15);
        transform.LookAt(marker.transform.position);
        Vector3 angles = new Vector3(Mathf.Clamp(transform.eulerAngles.x, 60, 90), Mathf.Clamp(transform.eulerAngles.x, 0, 0), transform.eulerAngles.z);
        transform.eulerAngles = angles;
        marker.transform.position = centerpos;
    }

}
