using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossOtherController : MonoBehaviour {
    public GameObject fountain;
	// Use this for initialization
	void Start () {
        fountain = Resources.Load("LootFountain") as GameObject;

    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnDestroy()
    {
       Instantiate(fountain, new Vector3(transform.position.x, 0 , transform.position.z), Quaternion.identity);
    }
}
