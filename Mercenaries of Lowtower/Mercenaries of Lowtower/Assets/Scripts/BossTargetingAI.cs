using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTargetingAI : MonoBehaviour {

   public Collider[] targets;
    public float[] targetThreat;
    public float[] targetThreat2;
    public float[] targetThreat3;
    AttackTESTSCRIPT ID;
    float distance;
    float threatVal;
    int myID;
    

	// Use this for initialization
	void Start () {
        FindTarget();
        targetThreat = new float[targets.Length];
        targetThreat2 = new float[targets.Length];
        targetThreat3 = new float[targets.Length];
        sendIDs();
    }
	
	// Update is called once per frame
	void Update () {
        targetDistance();
        combineThreat();
    }

    void FindTarget()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 100, 1 << 8);
        //print(LayerMask.NameToLayer("Players"));
        targets = hitColliders;
    }
    public void sendIDs()
    {
        for(int i = 0; i < targets.Length; i++)
        {
            GameObject currentTar = targets[i].gameObject;
             ID = currentTar.GetComponent<AttackTESTSCRIPT>();
            ID.assignSlot(i);
            //print(i);
        }
    }
    public void targetDistance()
    {
        for (int i = 0; i < targets.Length; i++)
        {
           distance = 100 - Vector3.Distance(transform.position, targets[i].transform.position);
            targetThreat2[i] = distance;          
        }
    }
    public void addThreat(float threat, int ID)
    {
        if (threat < 0)
        {
            threat *= -1;
        }
        targetThreat[ID] += threat;
        
       
    }
    public void combineThreat()
    {
        for (int i = 0; i < targets.Length; i++)
        {
            targetThreat3[i] = targetThreat[i] + targetThreat2[i];
        }
    }


}
