using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySphereScript : MonoBehaviour {

    public float chargeTime;
    private Vector3 originScale;
    private Vector3 targetScale;
    Rigidbody objectRigidbody;
    public bool isCharging;
    public Transform energySphereSpawn;
    public GameObject bossHead;

    // Use this for initialization
    void Start () {
        objectRigidbody = gameObject.GetComponent<Rigidbody>();
        StartCoroutine(ChargeUp(chargeTime));
        isCharging = true;
        energySphereSpawn = GameObject.Find("EnergySphere Spawn").transform;
        bossHead = GameObject.Find("Boss Head");
    }
	
	// Update is called once per frame
	void Update () {
        /*
        if(isCharging == true)
        {
            bossHead.GetComponent<BossLookAt>().isCharging = true;
            //transform.position = energySphereSpawn.position;
            //transform.rotation = energySphereSpawn.rotation;
        }
        if (isCharging == false)
        {
            bossHead.GetComponent<BossLookAt>().isCharging = false;
            //transform.position = energySphereSpawn.position;
            //transform.rotation = energySphereSpawn.rotation;
        }
        */
    }

    IEnumerator ChargeUp(float chargeTime)
    {
        originScale = gameObject.transform.localScale;
        targetScale = new Vector3(14.0f, 14.0f, 14.0f);

        float currentTime = 0.0f;
        do
        {
            gameObject.transform.localScale = Vector3.Lerp(originScale, targetScale, currentTime / chargeTime);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= chargeTime);
        objectRigidbody.AddForce(transform.forward * 5000);
        bossHead.GetComponent<BossLookAt>().TargetPlayer();
        bossHead.GetComponent<BossLookAt>().isCharging = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Destroy(gameObject);
            other.GetComponent<IDamageable<float>>().TakeDamage(80);
        }

        if (other.tag == "Destroyer")
        {
            Destroy(gameObject);
        }
    }
}
