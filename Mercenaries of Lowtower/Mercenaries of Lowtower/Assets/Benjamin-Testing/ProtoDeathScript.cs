using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoDeathScript : MonoBehaviour {

    /// <summary>
    /// created because the original death script modifies the PlayerMovement script, which is no longer being used
    /// </summary>

    Health healthScript;
    

	// Use this for initialization
	void Start () {

        healthScript = GetComponent<Health>();
		
	}
	
	// Update is called once per frame
	void Update () {

        if (gameObject.name=="Melee Character" && healthScript.health <=0)
        {
            GetComponent<MeleeController>().walkspeed = 0;
        }
		
	}
}
