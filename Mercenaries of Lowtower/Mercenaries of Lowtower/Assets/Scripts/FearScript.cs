using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FearScript : MonoBehaviour {
    public bool fear;
    Vector3 fearThis;
    float fearTimer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (fear)
        {
            fearTimer += Time.deltaTime;
            transform.Translate(new Vector3(Random.Range(-2, 2) * Time.deltaTime, 0, Random.Range(-2, 2) * Time.deltaTime));
            transform.Translate((fearThis.normalized)*.25f);
            if (fearTimer >= 3)
            {
                fear = false;
                fearTimer = 0;
            }
        }
	}
    public void Fear(GameObject me)
    {
        fear = true;
        fearThis = transform.position - me.transform.position;
    }
}
