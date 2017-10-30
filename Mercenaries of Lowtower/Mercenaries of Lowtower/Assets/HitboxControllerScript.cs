using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxControllerScript : MonoBehaviour {


    public GameObject meleeHitbox;
    int timer;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (timer <=0)
        {

            meleeHitbox.SetActive(false);
        }

        if (Input.GetButtonDown("Attack"))
        {
            timer = 60;
            meleeHitbox.SetActive(true);
            timer--;
        }
        else
        {
        }
		
	}
}
