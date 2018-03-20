﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class AIControllerNavMesh : EntityClass
{

    public GameObject Player;
    int MaxDist = 5;
    int MinDist = 2;

    public float defaultSpeed;
    public float stunTimer;
    Rigidbody rb;
    public SpawnAdd addSpawnerScript;
    public GameObject addSpawner;
    public LayerMask PlayerMask;
    Collider[] cols;

    public bool cannonballIsHeld;


    //public float stunDuration;

    Renderer enemyRenderer;
    public Material defaultEnemyMaterial;
    public Material stunnedMaterial;

    //NavMesh Things
    public NavMeshAgent navMeshAgent;


    private void Awake()
    {
        Player = null;
    }

    void Start()
    {
        //Player = GameObject.FindGameObjectWithTag("PickUp");


        enemyRenderer = GetComponent<Renderer>();

       // defaultEnemyMaterial = enemyRenderer.material;

        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody>();
        stunTimer = 0;

        addSpawner = GameObject.Find("add-pocalypse");
        addSpawnerScript = addSpawner.GetComponent<SpawnAdd>();
        addSpawnerScript.addCounter += 1;

        navMeshAgent = GetComponent<NavMeshAgent>();

        defaultSpeed = navMeshAgent.speed;


    }

    void Update()
    {
        //print(Vector3.Distance(transform.position, Player.position));
        if (!cannonballIsHeld) { 
       cols= Physics.OverlapSphere(transform.position, 1000, PlayerMask, QueryTriggerInteraction.Ignore);
        for(int i  = 0; i<cols.Length; i++)
        {
            float closestDistance = 100f;
                if (Vector3.Distance(transform.position, cols[i].transform.position) < closestDistance)
                {
                    Vector3.Distance(transform.position, cols[i].transform.position);
                    Player = cols[i].gameObject;
                    SetDestination();
                }
            }
        }

        if (rb.velocity.magnitude < .05)
        {
            rb.velocity = Vector3.zero;
            //other.GetComponent<NavMeshAgent>().isStopped = false;
           // navMeshAgent.enabled = true;

        }


        //transform.LookAt(Player.transform.position);

        //if (Vector3.Distance(transform.position, Player.transform.position) >= MinDist && !isStunned)
        if (!isStunned)
        {

            
            //enemyRenderer.material = defaultEnemyMaterial;


            //if (Vector3.Distance(transform.position, Player.transform.position) <= MaxDist)
            //{

            //}

        }

        if (isStunned)
        {
            stunTimer++;
            enemyRenderer.material = stunnedMaterial;

            if (stunTimer / 60 >= 5)
            {
                isStunned = false;
                //moveSpeed = 8;
                stunTimer = 0;
                enemyRenderer.material = defaultEnemyMaterial;
                navMeshAgent.speed = defaultSpeed;
            }

        }






        if (currentHealth <= 0)
        {
            addSpawnerScript.addCounter -= 1;
            Destroy(gameObject);
        }

    }

    //public void Stun(float controllerStunDuration)
    //{
    //    isStunned = true;
    //    print("stunned");
    //    stunDuration = controllerStunDuration;
    //}

    public void SetDestination()
    {
        navMeshAgent.SetDestination(Player.transform.position);
    }

    public void CannonballHeld()
    {
        cannonballIsHeld = true;
    }
    public void CannonballDropped()
    {
        cannonballIsHeld = false;
    }

    public override void StunThis()
    {
        print("speed should be zero");
        navMeshAgent.speed = 0;
        isStunned = true;
    }


}