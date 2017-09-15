using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBolt : MonoBehaviour {

    public Rigidbody bolt;
    public Rigidbody ropeBolt;
    public float timer=4;
    public float timer2 = 4;


    // Use this for initialization
    void Start () {
       

    }

    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
        if (timer >= 4)
        {
            if (Input.GetButton("Fire1"))
            {
                Rigidbody clone;
                clone = Instantiate(bolt, transform.position, Quaternion.identity) as Rigidbody;
                clone.velocity = transform.TransformDirection(Vector3.forward * 100);
                Destroy(clone.gameObject, 3);
                timer = 0;
            }
        }


    }

   
}
