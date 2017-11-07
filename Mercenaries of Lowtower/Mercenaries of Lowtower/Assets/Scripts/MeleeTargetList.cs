using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeTargetList : MonoBehaviour {
    public List<Collider> mTar;

    private Mesh m_mesh;

	// Use this for initialization
	void Start () {
        MeshFilter filter = GetComponentInChildren<MeshFilter>();
        if ( null != filter )
        {
            m_mesh = filter.mesh;
        }
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Matrix4x4 matrix = Gizmos.matrix;
        Gizmos.matrix = this.transform.localToWorldMatrix;
        Gizmos.DrawWireMesh(m_mesh);
        Gizmos.matrix = matrix;
    }
}
