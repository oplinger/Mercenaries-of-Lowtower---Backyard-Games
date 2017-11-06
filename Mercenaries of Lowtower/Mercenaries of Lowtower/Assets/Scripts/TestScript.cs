using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestScript : MonoBehaviour {
    LayerMask layer;

	// Use this for initialization
	void Start () {
        layer = (1 << 3) | (1 << 0);

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("n"))
        {
            SceneManager.LoadScene("Prototype Level");
        }
    }
}
