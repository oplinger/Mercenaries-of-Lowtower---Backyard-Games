using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossClass : EnemyClass {
    public float[] TentacleMaxHealth;
    public float[] TentacleCurrentHealth;
    public float tentacleHealthDelta;
    public GameObject[] tentacleArray;

    Renderer bossRenderer;
    protected Animator anim;


    public GameObject bossHead;
    public GameObject bossHeadModel;


    Color defaultColor;

    float h1;
    float h2;


    // Use this for initialization
    void Start () {
        //TentacleMaxHealth = new float[6];
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        bossRenderer = bossHeadModel.GetComponent<Renderer>();
        h2 = currentHealth;

        defaultColor = bossRenderer.material.color;

        //tentacleArray = GameObject.FindGameObjectsWithTag("Tentacle");
        //for (int i = 0; i < tentacleArray.Length; i++)
        //{
        //    TentacleMaxHealth[i] = tentacleArray[i].GetComponent<TentacleClass>().maxHealth;
        //    TentacleCurrentHealth[i] = tentacleArray[i].GetComponent<TentacleClass>().currentHealth;

            

        //}
    }
	
	// Update is called once per frame
	void Update () {

        //makes object flash red when it takes damage
        h1 = currentHealth;

        if (h1 < h2)
        {
            bossRenderer.material.SetColor("_EmissionColor", Color.red);
            anim.SetInteger("AnimState", 2);
            h2 = h1;
            //print("H2 = " + h2);
            
        }
        else
        {
            bossRenderer.material.SetColor("_EmissionColor", Color.black);
        }

    }

    public void AnimReset()
    {
        anim.SetInteger("AnimState", 0);
    }
}
