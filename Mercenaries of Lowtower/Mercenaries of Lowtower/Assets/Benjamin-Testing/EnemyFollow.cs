using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{

    public float speed;
    public Transform target;
    public Transform player;
    public float teleportDistancex;
    public float teleportDistancez;


    public float smolDamage;
    public float bigDamage;
    public float damage;

    Health healthScript;

    float baseHealth;

    // Use this for initialization
    void Start()
    {

        if (gameObject.name == "big boi")
        {
            damage = bigDamage;
            //Debug.Log("" + damage);
        }
        if (gameObject.name == "smol boi")
        {
            damage = smolDamage;
           // Debug.Log("" + damage);
        }

        healthScript = GetComponent<Health>();

        baseHealth = healthScript.health;

    }

    // Update is called once per frame
    void Update()
    {

        transform.LookAt(target);


        transform.position += transform.forward * speed * Time.deltaTime;

        if (healthScript.health <= 0)
        {
            teleportDistancex = Random.Range(-40, 40);

            teleportDistancez = Random.Range(-40, 40);
            //transform.position = new Vector3(GameObject.Find("Payload").transform.position.x + teleportDistancex, 0, teleportDistancez);
            //healthScript.health = baseHealth;

            for (int i = 0; i < 50; i++)
            {
                if ((target.position.x + teleportDistancex) >= (target.position.x - 20) && (target.position.x + teleportDistancex) <= (target.position.x + 20))
                {
                    teleportDistancex = Random.Range(-40, 40);
                }
                else
                {
                    break;
                }
            }
            
            for (int i = 0; i < 50; i++)
            {
                if ((target.position.z + teleportDistancez) >= (target.position.z -20) && (target.position.z + teleportDistancez) <= (target.position.z +20))
                {
                    teleportDistancez = Random.Range(-40, 40);
                }
                else
                {
                    break;
                }
            }
            //print(teleportDistancex + " , " + teleportDistancez);
            transform.position = new Vector3(target.position.x + teleportDistancex, 1, target.position.z + teleportDistancez);

            healthScript.health = baseHealth;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        //if (gameObject.name == "big boi" && other.tag == "Bolt")
        //{
        //    teleportDistancex = Random.Range(-25, 25);
        //    teleportDistancez = Random.Range(-25, 25);

        //    //transform.LookAt(player);
        //    // transform.position += transform.forward *-1 * 10 * Time.deltaTime;
        //    transform.position += new Vector3(teleportDistancex, 0, teleportDistancez);
        //}
        //if (gameObject.name == "smol boi")
        //{
        //    if (other.tag == "Player" || other.tag == "Bolt")
        //    {
        //        teleportDistance = Random.Range(-25, 25);

        //        //transform.LookAt(player);
        //        // transform.position += transform.forward *-1 * 10 * Time.deltaTime;
        //        transform.position += new Vector3(teleportDistance, 0, teleportDistance);
        //    }
        //}

        //if (other.tag == "Player")
        //{
        //    speed = 0;
        //}

    }

    private void OnTriggerStay(Collider other)
    {

        if (gameObject.name == "big boi" && other.tag == "Player")
        {
            other.GetComponent<Health>().health -= bigDamage;
        }
        if (gameObject.name == "smol boi" && other.tag == "Player")
        {
            other.GetComponent<Health>().health -= smolDamage;
        }
    }

}
