using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChangeFeedback : MonoBehaviour {


    Renderer rend;

    public Material beingDamagedMaterial;
    public Material deadMaterial;
    public Material originalMaterial;


    EnemyFollow enemyScript;

    Health healthScript;

    // Use this for initialization
    void Start () {

        rend = GetComponent<Renderer>();
        rend.material.shader = Shader.Find("Specular");

        healthScript = GetComponent<Health>();

        originalMaterial = rend.material;

    }
	
	// Update is called once per frame
	void Update () {

        if (healthScript.health <=0)
        {
            rend.material = deadMaterial;
        }
		
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            //enemyScript = other.GetComponent<EnemyFollow>();
            //rend.material.color = Color.red;
            rend.material = beingDamagedMaterial;
        }
        else
        {

            rend.material = originalMaterial;
        }
    }
}
