using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySphereScript : MonoBehaviour {

    public float chargeTime;
    private Vector3 originScale;
    private Vector3 targetScale;
    Rigidbody objectRigidbody;

	// Use this for initialization
	void Start () {
        objectRigidbody = gameObject.GetComponent<Rigidbody>();
        StartCoroutine(ChargeUp(chargeTime));
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator ChargeUp(float chargeTime)
    {
        originScale = gameObject.transform.localScale;
        targetScale = new Vector3(20.0f, 20.0f, 20.0f);

        float currentTime = 0.0f;

        do
        {
            gameObject.transform.localScale = Vector3.Lerp(originScale, targetScale, currentTime / chargeTime);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= chargeTime);
        objectRigidbody.AddForce(transform.forward * 4000);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Destroy(gameObject);
        }

        if (other.tag == "Destroyer")
        {
            Destroy(gameObject);
        }
    }
}
