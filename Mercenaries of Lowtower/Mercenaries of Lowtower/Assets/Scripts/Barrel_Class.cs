using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel_Class : EnemyClass {


    public Material breakableMat;
    Renderer rend;
    public bool breakable;
    public bool rolling;
    //public Transform barrelEndPoint;
    public float barrelSpeed;
    public Transform[] barrelWaypoints;
    public bool endPointReached;
    public Transform target;


    // Use this for initialization
    void Start () {
        //barrelWaypoints = new Transform[2];
       
        currentHealth = maxHealth;
        rend = GetComponent<Renderer>();
        breakableMat = rend.material;
        lastFrameHealth = currentHealth;
        target = barrelWaypoints[0];

    }

    // Update is called once per frame
    void Update () {
        if (rolling)
        {
            MoveBarrel();
        }

        if (breakable)
        {
            if (currentHealth < lastFrameHealth)
            {
                if (currentHealth == 0)
                {
                    Destroy(gameObject);
                    return;
                }

                breakableMat.SetColor("_Color", Color.HSVToRGB(1f, 1, 1));

                lastFrameHealth = currentHealth;
                //print(h2);
            }
            else
            {
                breakableMat.SetColor("_Color", Color.HSVToRGB(1f, 0, .5f));

            }

        }
    }

    void MoveBarrel()
    {
        // Multiplies the elevation speed by time
        float step = barrelSpeed * Time.deltaTime;
        
        // Moves the arm up towards the endPoint at a set speed
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);

        if (transform.position == barrelWaypoints[1].transform.position)
        {
            target = barrelWaypoints[0];
        }

        if (transform.position == barrelWaypoints[0].transform.position)
        {
            target = barrelWaypoints[1];
        }
    }

    //void ReturnBarrel()
    //{
    //    // Multiplies the elevation speed by time
    //    float step = barrelSpeed * Time.deltaTime;
    //    // Moves the arm up towards the endPoint at a set speed
    //    transform.position = Vector3.MoveTowards(transform.position, barrelWaypoints[0].position, step);

    //    if (transform.position == barrelWaypoints[0].position)
    //    {
    //        endPointReached = false;
    //    }
    //}
}
