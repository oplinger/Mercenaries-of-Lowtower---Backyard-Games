﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyHitMarker : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Destroy(gameObject, 1);
		
	}
}
