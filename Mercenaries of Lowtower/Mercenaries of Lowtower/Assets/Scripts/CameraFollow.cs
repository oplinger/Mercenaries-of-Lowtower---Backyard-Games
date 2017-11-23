using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    GameObject[] objects;
    public GameObject[] labels;
    public Health[] playerhealths;
    float[] healths1;
    float[] healths2;
    GameObject marker;
    float furthestTarget;
    float furthestTarget2;
    float maxX;
    float maxY;
    float minX;
    float minY;
    float maxZ;
    float minZ;
    public GameObject camTarget;


    // Use this for initialization
    void Start () {
        //objects = GameObject.FindGameObjectsWithTag("Player");
        objects = new GameObject[4];
        objects[0] = GameObject.Find("Tank Character(Clone)");
        objects[1] = GameObject.Find("Healer Character(Clone)");
        objects[2] = GameObject.Find("Melee Character(Clone)");
        objects[3] = GameObject.Find("Ranged Character(Clone)");

        playerhealths = new Health[4];
        healths1 = new float[4];

        healths2 = new float[4];


        for (int i = 0; i < objects.Length; i++)
        {
            playerhealths[i] = objects[i].GetComponent<Health>();
        }

        for (int i = 0; i < playerhealths.Length; i++)
        {
            healths2[i] = playerhealths[i].health;
        }

            marker = GameObject.CreatePrimitive(PrimitiveType.Cube);
        marker.transform.position = new Vector3(0, 2, -150);

         //maxX = -1000;
         //maxY = -1000;
         //minX = 1000;
         //minY = 1000;
         //maxZ = -1000;
         //minZ = 1000;

        transform.position = new Vector3(0, 17, -150);
        
	}
	
	// Update is called once per frame
	void Update () {
        FindPositions();
        GetHealths();
        FlashOnDamage();
            for (int i = 0; i<labels.Length; i++)
            {
            labels[i].transform.position = Vector3.Lerp(transform.position, objects[i].transform.position, .5f);
            }
        
    }

    void FindPositions()
    {
        //Vector3 averagePos = new Vector3();
        //furthestTarget2 = Vector3.Distance(marker.transform.position, objects[2].transform.position);

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
        minX = 1000;
        minY = 1000;
        minZ = 1000;
        maxX = -1000;
        maxY = -1000;
        maxZ = -1000;
        Vector3 centerpos = new Vector3((currminX + currmaxX) / 2, (currminY + currmaxY) / 2, (currminZ + currmaxZ) / 2);
        transform.position = centerpos;
        transform.position += new Vector3(0, Mathf.Clamp(furthestTarget * 2f, 25, 500), -15);
        Vector3 angles = new Vector3(Mathf.Clamp(transform.eulerAngles.x, 60, 90), Mathf.Clamp(transform.eulerAngles.x, 0, 0), transform.eulerAngles.z);
        transform.eulerAngles = angles;
        marker.transform.position = centerpos;
        camTarget = marker;
        transform.LookAt(camTarget.transform);

    }
    void GetHealths()
    {
        for (int i = 0; i < healths2.Length; i++)
        {
            healths1[i] = playerhealths[i].health;
        }
    }

    void FlashOnDamage()
    {
        for (int i = 0; i < healths2.Length; i++)
        {
            if (healths2[i] > healths1[i])
            {
                labels[i].GetComponent<TextMesh>().color = Color.red;
                healths2[i] = healths1[i];
            } else
            {
                labels[i].GetComponent<TextMesh>().color = Color.white;
            }
        }

    }
}
