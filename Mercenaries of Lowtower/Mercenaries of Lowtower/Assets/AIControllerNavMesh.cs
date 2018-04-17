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
    protected Rigidbody rb;
    public SpawnAdd addSpawnerScript;
    public GameObject addSpawner;
    public LayerMask PlayerMask;
    protected Collider[] cols;
    protected float currenthealth2;

    public bool cannonballIsHeld;


    //public float stunDuration;

    protected Renderer[] enemyRenderer;
    public Material defaultEnemyMaterial;
    public Material stunnedMaterial;

    public Texture stunnedTex;
    public Texture defaultTex;
    public Texture damagedTex;
    public Texture damagedTex2;

    //NavMesh Things
    NavMeshAgent navMeshAgent;


    private void Awake()
    {
        Player = null;
    }

    void Start()
    {
        //Player = GameObject.FindGameObjectWithTag("PickUp");

        currenthealth2 = currentHealth;
        enemyRenderer = GetComponentsInChildren<Renderer>();

        // defaultEnemyMaterial = enemyRenderer.material;

        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody>();
        stunTimer = 0;

        addSpawner = GameObject.Find("add-pocalypse");
        addSpawnerScript = addSpawner.GetComponent<SpawnAdd>();
        addSpawnerScript.addCounter += 1;

        navMeshAgent = GetComponent<NavMeshAgent>();

        defaultSpeed = navMeshAgent.speed;

        LookForCannonball();


    }

    void Update()
    {
        //print(Vector3.Distance(transform.position, Player.position));
        if (!cannonballIsHeld)
        {

            CannonballDropped();

            cols = Physics.OverlapSphere(transform.position, 1000, PlayerMask, QueryTriggerInteraction.Ignore);

            for (int i = 0; i < cols.Length; i++)
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
        else
        {
            SetDestination();
        }

        if (rb.velocity.magnitude < .05)
        {
            rb.velocity = Vector3.zero;
            //other.GetComponent<NavMeshAgent>().isStopped = false;
            navMeshAgent.enabled = true;

        }

        if (rb.velocity.magnitude > 0)
        {
            GetComponent<Animator>().SetInteger("AnimState", 1);
        }
        if (currentHealth < currenthealth2)
        {
            GetComponent<Animator>().SetInteger("AnimState", 2);

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
            foreach (Renderer item in enemyRenderer)
            {
                item.material.SetTexture("_MainTex", stunnedTex);
                item.material.SetTexture("_EmissionMap", stunnedTex);

            }
            GetComponent<ArmSlamHitbox>().slamDamage = 0;
            GetComponent<Animator>().enabled = false;
            // enemyRenderer.material.SetTexture("_MainTex", stunnedTex);

            if (stunTimer / 60 >= 5)
            {
                isStunned = false;
                //moveSpeed = 8;
                stunTimer = 0;
                //enemyRenderer.material = defaultEnemyMaterial;
                // enemyRenderer.material.SetTexture("_MainTex", defaultTex);
                foreach (Renderer item in enemyRenderer)
                {
                    item.material.SetTexture("_MainTex", defaultTex);
                    item.material.SetTexture("_EmissionMap", defaultTex);
                }
                navMeshAgent.speed = defaultSpeed;
                GetComponent<ArmSlamHitbox>().slamDamage = 3;

                GetComponent<Animator>().enabled = true;

            }

        }






        if (currentHealth <= 0)
        {
            addSpawnerScript.addCounter -= 1;
            GetComponent<Animator>().SetInteger("AnimState", 3);
            Destroy(this.gameObject);

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
        navMeshAgent.speed = 0;
        isStunned = true;
    }

    public void LookForCannonball()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].GetComponentInChildren<PickUpBox>().holdingObject)
            {
                Player = players[i];
                cannonballIsHeld = true;
                print("found cannonball on spawn");
            }
            else
            {

            }
        }


    }

    public void PlayerColorFlash()
    {
        StartCoroutine("IPlayerColorFlash");

    }

    IEnumerator IPlayerColorFlash()
    {
        foreach (Renderer item in enemyRenderer)
        {
            item.material.SetTexture("_MainTex", damagedTex);

            yield return new WaitForSeconds(.08f);
            item.material.SetTexture("_MainTex", defaultTex);
        }
    }

    public void PlayerColorFlash2()
    {
        StartCoroutine("IPlayerColorFlash2");

    }

    IEnumerator IPlayerColorFlash2()
    {
        foreach (Renderer item in enemyRenderer)
        {
            item.material.SetTexture("_MainTex", damagedTex2);

            yield return new WaitForSeconds(0.15f);
            item.material.SetTexture("_MainTex", defaultTex);
        }
    }


}