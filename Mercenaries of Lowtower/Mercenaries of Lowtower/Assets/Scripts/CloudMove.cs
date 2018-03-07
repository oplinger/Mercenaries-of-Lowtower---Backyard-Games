using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove : MonoBehaviour {
    Renderer rend;
    public float Xmove;
    public float Ymove;
	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        rend.material.mainTextureOffset += new Vector2(Xmove, Ymove);
	}
}
