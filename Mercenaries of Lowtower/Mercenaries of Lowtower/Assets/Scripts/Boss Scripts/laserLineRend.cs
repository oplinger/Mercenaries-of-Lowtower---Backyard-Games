using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserLineRend : MonoBehaviour {

    public Transform laserStart;
    public Transform laserEnd;
    LineRenderer laserLine;

	// Use this for initialization
	void Start () {
        laserLine = GetComponent<LineRenderer>();
        laserLine.startWidth = 2f;
        laserLine.endWidth = 2f;
	}
	
	// Update is called once per frame
	void Update () {
        laserLine.SetPosition(0, laserStart.position);
        laserLine.SetPosition(1, laserEnd.position);
    }
}
