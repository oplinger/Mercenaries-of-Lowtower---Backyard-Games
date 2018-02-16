using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateRollingBarrels : MonoBehaviour {

    public GameObject [] rollingBarrels;

    public PhaseControllerScript phaseScript;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if  (phaseScript.bossHead.transform.position == phaseScript.bossOriginalposition)
        {
            for (int i = 0; i < rollingBarrels.Length; i++)
            {
                rollingBarrels[i].SetActive(false);
            }
        }

        if (phaseScript.bossHead.transform.position == phaseScript.retreatWaypoint.position)
        {
            for (int i=0; i<rollingBarrels.Length; i++)
            {
                rollingBarrels[i].SetActive(true);
            }
        }

	}
}
