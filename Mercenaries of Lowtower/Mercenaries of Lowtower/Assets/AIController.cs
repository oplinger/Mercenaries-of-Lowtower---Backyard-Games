using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AIController : MonoBehaviour
{

    public Transform Player;
    int MoveSpeed = 8; //Speed 4
    int MaxDist = 10;
    int MinDist = 4;


    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("PickUp").transform;
    }

    void Update()
    {
        print(Vector3.Distance(transform.position, Player.position));

        transform.LookAt(Player);

        if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        {

            transform.position += (transform.forward * MoveSpeed * Time.deltaTime)/2;


            if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
            {

            }

        }
    }
}