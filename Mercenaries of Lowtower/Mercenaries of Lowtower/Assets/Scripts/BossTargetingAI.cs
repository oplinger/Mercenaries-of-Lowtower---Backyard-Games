using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTargetingAI : MonoBehaviour {

    public ControllerThing controller;

    public float[] damageThreat;
    public float[] distanceThreat;
    public float[] combinedThreat;
    float distance;
    float threatVal;
    int myID;
    public GameObject currentTarget;
    

	// Use this for initialization
	void Start () {
            
        // At start the boss finds targets in the arena.
        // damageThreat is the threat from damage
        // distanceThreat is the threat from distance
        // combinedThreat is the combined output of the 2
        damageThreat = new float[controller.targets.Length];
        distanceThreat = new float[controller.targets.Length];
        combinedThreat = new float[controller.targets.Length];
    }
	
	// finds the distance threat, combines the threat values, and takes the highest threat value and makes that the bosses current target.
	void Update () {
        targetDistance();
        combineThreat();
        findCurrentTarget();
    }

    // Finds the distance to all found targets and adds the threat value from that distance to the distance threat array
    public void targetDistance()
    {
        for (int i = 0; i < controller.targets.Length; i++)
        {
           distance = 100 - Vector3.Distance(transform.position, controller.IDs[i].transform.position);
            distanceThreat[i] = distance;          
        }
    }

    // This method adds the damage threat to a target. It converts any negative values to positive values, so healing applies properly to the threat table.
    //Can be called outside of damage, so any abilities that do not do damage, can still create threat
    public void addThreat(float threat, int ID)
    {
        if (threat < 0)
        {
            threat *= -1;
        }
        damageThreat[ID] += threat;
        
       
    }

    // Combines the distance threat value and the damage threat values into a new array, maintaining ID integrity.
    public void combineThreat()
    {
        for (int i = 0; i < controller.targets.Length; i++)
        {
            combinedThreat[i] = damageThreat[i] + distanceThreat[i];
        }
    }

    // After Threat is found, it loops through targetThreat3 and finds the highest threat value, the character assigned that ID now becomes the bosses current target.
    void findCurrentTarget()
    {
        float highestThreat = 0;
        for (int i = 0; i < controller.targets.Length; i++)
        {
            if (combinedThreat[i] > highestThreat)
            {
                highestThreat = combinedThreat[i];
                currentTarget = controller.IDs[i].gameObject;
            }

        }
    }

}
