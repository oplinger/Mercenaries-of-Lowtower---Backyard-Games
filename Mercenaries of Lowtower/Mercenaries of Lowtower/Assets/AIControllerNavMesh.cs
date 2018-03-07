using System.Collections;
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

    public SpawnAdd addSpawnerScript;
    public GameObject addSpawner;

    public bool cannonballIsTarget;


    //public float stunDuration;

    Renderer enemyRenderer;
    public Material defaultEnemyMaterial;
    public Material stunnedMaterial;

    //NavMesh Things
    public NavMeshAgent navMeshAgent;


    private void Awake()
    {
        cannonballIsTarget = true;
        Player = null;
    }

    void Start()
    {
        //Player = GameObject.FindGameObjectWithTag("PickUp");


        enemyRenderer = GetComponent<Renderer>();

        defaultEnemyMaterial = enemyRenderer.material;

        currentHealth = maxHealth;

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


        if (Player == null && cannonballIsTarget)
        {
            Player = GameObject.FindGameObjectWithTag("PickUp");
        }

        if (!cannonballIsTarget)

        {

        }


        //transform.LookAt(Player.transform.position);

        //if (Vector3.Distance(transform.position, Player.transform.position) >= MinDist && !isStunned)
        if (!isStunned)
        {

            navMeshAgent.SetDestination(Player.transform.position);
            enemyRenderer.material = defaultEnemyMaterial;


            if (Vector3.Distance(transform.position, Player.transform.position) <= MaxDist)
            {

            }

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

    public void TakeDamage(float damageTaken)
    {

    }

    public override void StunThis()
    {
        print("speed should be zero");
        navMeshAgent.speed = 0;
        isStunned = true;
    }


}