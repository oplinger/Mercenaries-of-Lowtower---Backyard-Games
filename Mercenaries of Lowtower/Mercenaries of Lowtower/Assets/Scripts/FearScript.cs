using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FearScript : MonoBehaviour {
    public bool fear;
    Vector3 fearThis;
    float runSpeed;
    float fearTimer;
    float fearDuration;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (fear)
        {
            fearTimer += Time.deltaTime;
            transform.Translate(new Vector3(Random.Range(-4, 4) * Time.deltaTime, 0, Random.Range(-4, 4) * Time.deltaTime));
            transform.Translate((fearThis.normalized)*runSpeed);
            if (fearTimer >= fearDuration)
            {
                fear = false;
                fearTimer = 0;
            }
        }
	}
    public void Fear(GameObject me, float runspeed, float fearduration)
    {
        fear = true;
        fearThis = transform.position - me.transform.position;
        runSpeed = runspeed;
        fearDuration = fearduration;
    }
}
