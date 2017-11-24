using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour {

    Health healthScript;
    
    float h1;
    float h2;

    public Material breakableMat;

    // Use this for initialization
    void Start () {

        healthScript = GetComponent<Health>();
        h2 = healthScript.health;
		
	}
	
	// Update is called once per frame
	void Update () {


        h1 = healthScript.health;

        if (h1 < h2)
            {
                breakableMat.SetColor("_EmissionColor", Color.HSVToRGB(1f, 1, 1));
                
                h2 = h1;
            }
            else
            {
                breakableMat.SetColor("_EmissionColor", Color.HSVToRGB(1f, 1, 0));

            }
    }

}
