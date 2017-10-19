using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIProto : MonoBehaviour {

    public Image payloadHealthBar;
    public GameObject payload;

    ThePackage payloadScript;

	// Use this for initialization
	void Start () {
        payloadScript = payload.GetComponent<ThePackage>();
	}
	
	// Update is called once per frame
	void Update () {

        payloadHealthBar.rectTransform.sizeDelta = new Vector2(100 * (payloadScript.baseHealth / 100), 20);

    }
}
