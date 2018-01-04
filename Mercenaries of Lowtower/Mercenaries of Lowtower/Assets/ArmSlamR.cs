using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ArmSlamR : MonoBehaviour {


    public float timeUntilSlam;
    public Transform waypointTop;
    public Transform waypointBottom;

    public float groundedTime;

    public bool attacking;

    public float tempTimeUntilSlam;
    public float tempGroundedTime;

    Renderer armRenderer;

    float damageTimer;
    public float tempDamageTimer;

    public GameObject hitbox;

    public bool damageOn;

    Health healthScript;

    float h1;
    float h2;

    // Use this for initialization
    void Start () {

        tempTimeUntilSlam = timeUntilSlam;

        tempGroundedTime = groundedTime;

        armRenderer = GetComponent<Renderer>();

        damageTimer = 30;
        tempDamageTimer = damageTimer;

        //RE flashing red when damaged
        healthScript = GetComponent<Health>();
        h2 = healthScript.health;


    }

    // Update is called once per frame
    void Update() {

        tempTimeUntilSlam -= 1;
        float t = 0.2f;

        //can't activate / deactivate bools within a key imput read???
        if (Input.GetKeyDown(KeyCode.U))
        {
            transform.position = new Vector3(transform.position.x, waypointBottom.position.y, transform.position.z);

        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            transform.position = new Vector3(transform.position.x, waypointTop.position.y, transform.position.z);
        }


        if (Input.GetKey(KeyCode.K))
        {
            transform.Translate(Vector3.forward * -0.2f, Space.World);
        }

        if (Input.GetKey(KeyCode.I))
        {
            transform.Translate(Vector3.forward * 0.2f, Space.World);
        }
        if (Input.GetKey(KeyCode.J))
        {
            transform.Translate(Vector3.left * 0.2f, Space.World);
        }

        if (Input.GetKey(KeyCode.L))
        {
            transform.Translate(Vector3.left * -0.2f, Space.World);
        }


        if (damageOn)
        {
            hitbox.SetActive(true);

            //tempDamageTimer = damageTimer;

            tempDamageTimer -= 1;
            
        }

        if (tempDamageTimer <= 0)
        {
            hitbox.SetActive(false);
            damageOn = false;
            tempDamageTimer = 30;
        }

        //makes object flash red when it takes damage
        h1 = healthScript.health;

        if (h1 < h2)
        {
            //armRenderer.material.SetColor("_EmissionColor", Color.red);
            armRenderer.material.color = Color.red;

            h2 = h1;
            //print("H2 = " + h2);
        }


    }
    

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Ground")
        {
            
            
            //makes the arm flash blue
            armRenderer.material.color = Color.Lerp(Color.white, Color.blue, Mathf.PingPong(Time.time * .5f, .5f));

        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Ground")
        {

            damageOn = true;

        }
    }



}
