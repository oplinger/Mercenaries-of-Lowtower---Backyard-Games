using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    
    public float speed;
    public Transform target;
    public Transform player;
    public float teleportDistance;

    public float smolDamage;
    public float bigDamage;
    public float damage;


    // Use this for initialization
    void Start()
    {

        if (gameObject.name == "big boi")
        {
            damage = bigDamage;
            Debug.Log("" + damage);
        }
        if (gameObject.name == "smol boi")
        {
            damage = smolDamage;
            Debug.Log("" + damage);
        }

    }

    // Update is called once per frame
    void Update()
    {

        transform.LookAt(target);

        
            transform.position += transform.forward * speed * Time.deltaTime;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.name == "big boi" && other.tag == "Bolt")
        {
            teleportDistance = Random.Range(-25, 25);

            //transform.LookAt(player);
            // transform.position += transform.forward *-1 * 10 * Time.deltaTime;
            transform.position += new Vector3(teleportDistance, 0, teleportDistance);
        }
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
            other.GetComponent<Health>().health-=bigDamage;
        }
        if (gameObject.name == "smol boi" && other.tag == "Player")
        {
            other.GetComponent<Health>().health -= smolDamage;
        }
    }

}
