using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThePackage : MonoBehaviour
{

    public float speed;
    Renderer rend;

    public float baseHealth;
    public GameObject player;

    //public float damage;

    EnemyFollow enemyScript;

    public Material beingDamagedMaterial;
    public Material deadMaterial;
    public Material originalMaterial;

    // Use this for initialization
    void Start()
    {

        rend = GetComponent<Renderer>();
        rend.material.shader = Shader.Find("Specular");

        player = this.gameObject;

        originalMaterial = rend.material;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward * speed * Time.deltaTime;

        if (baseHealth <= 0)
        {
            speed=0;
            rend.material = deadMaterial;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemyScript = other.GetComponent<EnemyFollow>();
            //rend.material.color = Color.red;
            rend.material = beingDamagedMaterial;
            modifyHealth();
        }
        else
        {

            rend.material = originalMaterial;
        }
    }

    //private void OnTriggerExit(Collider other)
    //{


    //    if (other.tag == "Enemy")
    //    {
    //        rend.material = originalMaterial;
    //    }
    //}

    public void modifyHealth()
    {
        if (baseHealth > 0)
        {
            baseHealth -= enemyScript.damage;
        }
    }
}
