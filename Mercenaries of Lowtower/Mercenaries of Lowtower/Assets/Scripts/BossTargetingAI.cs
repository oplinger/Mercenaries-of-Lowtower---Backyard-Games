using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTargetingAI : MonoBehaviour {

   public Collider[] targets;
    public float[] targetThreat;

	// Use this for initialization
	void Start () {
        FindTarget();
        targetThreat = new float[targets.Length];
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void FindTarget()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 100, 1 << 8);
        //print(LayerMask.NameToLayer("Players"));
        targets = hitColliders;
    }
    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 100);
    }
}
