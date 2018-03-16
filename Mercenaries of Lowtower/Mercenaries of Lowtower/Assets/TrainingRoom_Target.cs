using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingRoom_Target : EnemyClass {

    Renderer targetRenderer;

    Color defaultColor;
    public GameObject TRTarget;

    float h1;
    float h2;


    // Use this for initialization
    void Start()
    {
        
        currentHealth = maxHealth;

        targetRenderer = TRTarget.GetComponent<Renderer>();
        h2 = currentHealth;

        defaultColor = targetRenderer.material.color;

        //}
    }

    // Update is called once per frame
    void Update()
    {

        //makes object flash red when it takes damage
        h1 = currentHealth;

        if (h1 < h2)
        {
            targetRenderer.material.SetColor("_EmissionColor", Color.red);
           // WaitForSeconds(5);
            h2 = h1;
            //print("H2 = " + h2);

        }
        else
        {
            targetRenderer.material.SetColor("_EmissionColor", Color.black);
        }
        print("LIT!!");
    }
}
