using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThePackage : MonoBehaviour {

    public float speed;
    Renderer rend;

    // Use this for initialization
    void Start () {

        rend = GetComponent<Renderer>();
        rend.material.shader = Shader.Find("Specular");

    }
	
	// Update is called once per frame
	void Update () {
        transform.position += Vector3.forward*speed*Time.deltaTime;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Enemy")
        {
            rend.material.color = Color.red;
        }
    }

    private void OnTriggerExit(Collider other)
    {


        if (other.tag == "Enemy")
        {
            rend.material.color = Color.white;
        }
    }
}
