using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundColoring : MonoBehaviour {
    Renderer groundRend;
    float timer;
	// Use this for initialization
	void Start () {
       groundRend= GetComponent<Renderer>();
        groundRend.material.color = Color.HSVToRGB(Random.Range(0f, 1f), Random.Range(0f, 1f), .5f);
        //print("GROUND COLORED");
            }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > .2f)
        {
            groundRend.material.color = Color.HSVToRGB(Random.Range(0f, 1f), Random.Range(0f, .8f),Random.Range(.5f,.5f));
            timer = 0;
        }
		
	}
}
