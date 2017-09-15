using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemRangedAttack : MonoBehaviour {
    public Rigidbody bolt;
    Quaternion rotation;
    public GameObject boltspawn;
    bool go;
    float timer;
    float timer2;
	// Use this for initialization
	void Start () {
        transform.rotation = rotation;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("g"))
        {
            go = !go;          
        }
        if (go)
        {
            
            timer += Time.deltaTime;
            print(timer);
            if (timer < 10)
            {
                AttackPatternOmega();
            }
        }
    }
    IEnumerator Attack1()
    {
        yield return new WaitForSeconds(2);
        for (int i2 = 0; i2 < 60; i2++)
        {
            Rigidbody clone;
            clone = Instantiate(bolt, boltspawn.transform.position, Quaternion.identity) as Rigidbody;
            clone.velocity = transform.TransformDirection(Vector3.forward * 10);
            Destroy(clone.gameObject, 1);
            rotation.eulerAngles += new Vector3(0, 6, 0);
            transform.rotation = rotation;
        }
        rotation.eulerAngles += new Vector3(0, 3, 0);
    }
    void AttackPatternOmega()
    {
        timer2 += Time.deltaTime;
        if (timer2 > .25)
        {
            StartCoroutine("Attack1");
            timer2 = 0;
        }
    }

}
