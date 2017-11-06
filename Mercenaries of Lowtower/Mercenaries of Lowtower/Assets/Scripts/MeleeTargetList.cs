using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeTargetList : MonoBehaviour {
    public List<Collider> mTar;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i<mTar.Count; i++)
        {
            if (mTar[i] == null)
            {
                mTar.Remove(mTar[i]);
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        mTar.Add(other);
    }
    private void OnTriggerExit(Collider other)
    {
        mTar.Remove(other);
    }
}
