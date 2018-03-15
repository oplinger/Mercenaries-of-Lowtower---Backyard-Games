using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingRoom_Target : MonoBehaviour {

    Renderer targetRenderer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Bolt")
        {
            targetRenderer.material.SetColor("_EmissionColor", Color.red);
        }
        else
        {
            targetRenderer.material.SetColor("_EmissionColor", Color.black);
        }
         
        }
        
    }

