using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeSpawn : MonoBehaviour {
  static  public GameObject rope;
    public GameObject ropePrefab;
    public bool ropespawnbool=true;
    private void Start()
    {
        rope = ropePrefab;
    }

    public void SpawnRope(Vector3 pos, float pointless)
    {
        if (ropespawnbool)
        {
            Instantiate(rope, pos, Quaternion.identity);
            ropespawnbool = false;
        }
    }
}
