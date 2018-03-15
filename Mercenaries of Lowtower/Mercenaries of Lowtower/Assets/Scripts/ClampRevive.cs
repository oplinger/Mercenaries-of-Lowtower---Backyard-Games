using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClampRevive : MonoBehaviour {

    public Image yToRevive;
    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 revivePosition = Camera.main.WorldToScreenPoint(this.transform.position);
        yToRevive.transform.position = revivePosition;
		
	}
}
