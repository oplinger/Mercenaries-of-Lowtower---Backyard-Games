using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AIController : EntityClass
{

    public Transform Player;
    //public int MoveSpeed = 8; //Speed 4
    int MaxDist = 5;
    int MinDist = 2;


    public float stunTimer;
    



    //public float stunDuration;

    Renderer enemyRenderer;
   public  Material defaultEnemyMaterial;
    public Material stunnedMaterial;


    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("PickUp").transform;

        enemyRenderer = GetComponent<Renderer>();

        defaultEnemyMaterial = enemyRenderer.material;

        currentHealth = maxHealth;

        moveSpeed = 8;

        stunTimer = 0;


    }

    void Update()
    {
        //print(Vector3.Distance(transform.position, Player.position));
        

        if (Player == null)
        {
            Player = GameObject.FindGameObjectWithTag("PickUp").transform;
        }


        transform.LookAt(Player);

        if (Vector3.Distance(transform.position, Player.position) >= MinDist && !isStunned)
        {

            transform.position += transform.forward * moveSpeed * Time.deltaTime;
            enemyRenderer.material = defaultEnemyMaterial;


            if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
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
                moveSpeed = 8;
                stunTimer = 0;
                enemyRenderer.material = defaultEnemyMaterial;
            }

        }

        




        if (currentHealth<=0)
        {
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

    public void StunThis()
    {

    }

   
}