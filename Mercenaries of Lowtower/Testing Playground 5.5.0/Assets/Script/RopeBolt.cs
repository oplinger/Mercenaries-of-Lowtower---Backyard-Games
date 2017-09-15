using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeBolt : MonoBehaviour {
    public Rigidbody ropeBolt;
    static public Rigidbody ropeboltStatic;
    public GameObject boltSpawn;
    public float timer = 4;
    ControllerThing controller;
    // Use this for initialization
    void Start () {
        ropeboltStatic = ropeBolt;
        controller = GameObject.FindGameObjectWithTag("Controller").GetComponent<ControllerThing>();
    }

    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
        
        if (timer >= 4)
        {
            if (Input.GetButton("Fire2"))
            {
                //Rigidbody clone;
                //clone = Instantiate(ropeBolt, boltSpawn.transform.position, Quaternion.identity) as Rigidbody;
                //clone.velocity = transform.TransformDirection(Vector3.forward * 100);
                controller.CastRay(gameObject, transform.forward, 0, 50000, "Rope");

                timer = 0;
            }
        }
    }
   static public void FreezePosition()
    {
        ropeboltStatic.constraints = RigidbodyConstraints.FreezePosition;
        
    }
}
