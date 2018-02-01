using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour {
    public float lightningTime;
    public Light lightningLight;
	// Use this for initialization
	void Start () {
        lightningTime = Random.Range(2, 3);
	}
	
	// Update is called once per frame
	void Update () {
        lightningTime -= Time.deltaTime;

        if (lightningTime <= 0)
        {
            lightningTime = Random.Range(2, 3);
            StartCoroutine(lightning());
            Vector3 forks = new Vector3(transform.rotation.eulerAngles.x, Random.Range(-360, 360), transform.rotation.eulerAngles.z);
            transform.eulerAngles = forks;
        }
	}

    IEnumerator lightning()
    {


        lightningLight.GetComponent<Light>().enabled=true;
        lightningLight.GetComponent<Light>().intensity = Random.Range(1, 2);
        yield return new WaitForSeconds(Random.Range(.016f, .048f));
        lightningLight.GetComponent<Light>().intensity = Random.Range(1, 5);
        yield return new WaitForSeconds(Random.Range(.016f, .048f));
        lightningLight.GetComponent<Light>().intensity = Random.Range(1, 5);
        yield return new WaitForSeconds(Random.Range(.016f, .048f));
        lightningLight.GetComponent<Light>().intensity = Random.Range(1, 5);
        yield return new WaitForSeconds(Random.Range(.016f, .048f));
        lightningLight.GetComponent<Light>().intensity = Random.Range(1, 5);
        yield return new WaitForSeconds(Random.Range(.016f, .048f));
        lightningLight.GetComponent<Light>().intensity = Random.Range(1, 2);
        yield return new WaitForSeconds(Random.Range(.016f, .048f));
        lightningLight.GetComponent<Light>().enabled = false;


    }
}
