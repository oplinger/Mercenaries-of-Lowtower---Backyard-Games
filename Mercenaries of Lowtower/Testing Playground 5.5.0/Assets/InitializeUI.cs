using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InitializeUI : MonoBehaviour {
    float timer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > .75f)
        {
           //gameObject.AddComponent<CanvasRenderer>();
           //gameObject.AddComponent<Text>();

            Text text = GetComponent<Text>();
            //text.font = new Font("Arial");
            text.text = "MERCENARIES OF LOWTOWER\n\nContinue\nNew Game\nLoad Game\nSettings\nQuit";
            text.color = new Color(.8f, .8f, 1f, (timer - 1)/2);
            
        }
        }
}
