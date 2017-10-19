using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeHitbox : MonoBehaviour {

    public GameObject player;
    public Attack attackScript;

    public PlayerID ID;

    MeshRenderer hitboxRenderer;

    public MeleeHitbox hitbox;

	// Use this for initialization
	void Start () {

        //attackScript = player.GetComponent<Attack>();
        //hitbox = this.gameObject.GetComponent<MeleeHitbox>();
        ////hitboxRenderer = GetComponent<MeshRenderer>();
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Attack"))
        {
            gameObject.SetActive(true);
            //hitboxRenderer.enabled = true;
        }
		
	}

}
