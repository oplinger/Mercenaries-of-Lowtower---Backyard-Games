using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AIController : MonoBehaviour, IDamageable<float>
{

    public Transform Player;
    public int MoveSpeed = 8; //Speed 4
    int tempMoveSpeed = 0;
    int MaxDist = 10;
    int MinDist = 4;


    public bool isStunned;
    float stunTimer;
    float stunDuration;

    Renderer enemyRenderer;
   public  Material defaultEnemyMaterial;


    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("PickUp").transform;

        enemyRenderer = GetComponent<Renderer>();

        defaultEnemyMaterial = enemyRenderer.material;
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

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
            enemyRenderer.material = defaultEnemyMaterial;


            if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
            {

            }

        }


        if (isStunned)
        {
            stunTimer += Time.deltaTime;

            ////material colour won't change back
            //enemyRenderer.material.color = Color.magenta;

            //stops movement
            transform.position += transform.forward * tempMoveSpeed * Time.deltaTime;

            if (stunTimer >= stunDuration)
            {
                isStunned = false;
                stunTimer = 0;
            }
        }

    }

    public void Stun(float controllerStunDuration)
    {
        isStunned = true;
        print("stunned");
        stunDuration = controllerStunDuration;
    }

    public void TakeDamage(float damageTaken)
    {
        
    }
}