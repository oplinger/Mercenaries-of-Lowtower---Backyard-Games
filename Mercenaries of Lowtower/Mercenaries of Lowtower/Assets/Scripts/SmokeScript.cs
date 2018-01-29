using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeScript : MonoBehaviour {
    float scaleRate = 1;
    private float transTimer;
    public Material smokeMat;


    // Use this for initialization
    void Start () {
        transTimer = 1;

    }

    // Update is called once per frame
    void Update () {
        transform.localScale += new Vector3(scaleRate * Time.deltaTime, scaleRate * Time.deltaTime, scaleRate * Time.deltaTime);
        smokeMat.color = new Color(.5f, .5f, .5f, transTimer);
        transTimer = transTimer - Time.deltaTime/5;
        Destroy(gameObject, 5);
	}

    public void Dissipation(float rate)
    {
        scaleRate = rate;
    }
}
