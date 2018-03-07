using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleAnimationEvents : MonoBehaviour {

    public GameObject Tentacle;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Retreat()
    {
        Tentacle.GetComponent<BossTentacleScript>().RetreatTentacle();
    }

    void Lower()
    {
        Tentacle.GetComponent<BossTentacleScript>().CompleteRetreat();
    }
}
