﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    
    public float speed;
    public Transform target;
    public Transform player;
    public float teleportDistance;


    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        transform.LookAt(target);

        
            transform.position += transform.forward * speed * Time.deltaTime;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            teleportDistance = Random.Range(-25, 25);

            //transform.LookAt(player);
            // transform.position += transform.forward *-1 * 10 * Time.deltaTime;
            transform.position += new Vector3(teleportDistance, 0, teleportDistance);
        }
    }
}