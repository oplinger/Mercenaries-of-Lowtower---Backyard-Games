using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel_Class : EnemyClass {


    public Material breakableMat;
    Renderer rend;
    public bool breakable;

    // Use this for initialization
    void Start () {
        currentHealth = maxHealth;
        rend = GetComponent<Renderer>();
        breakableMat = rend.material;
        lastFrameHealth = currentHealth;
    }
	
	// Update is called once per frame
	void Update () {
        if (breakable)
        {
            if (currentHealth < lastFrameHealth)
            {
                if (currentHealth == 0)
                {
                    Destroy(gameObject);
                    return;
                }

                breakableMat.SetColor("_Color", Color.HSVToRGB(1f, 1, 1));

                lastFrameHealth = currentHealth;
                //print(h2);
            }
            else
            {
                breakableMat.SetColor("_Color", Color.HSVToRGB(1f, 0, .5f));

            }

        }
    }
}
