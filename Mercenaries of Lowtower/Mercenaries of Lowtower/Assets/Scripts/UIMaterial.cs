using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMaterial : MonoBehaviour {
    public Material mat;
    public Material mat2;

    public Renderer rend;
    public Image img;
	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        img = GetComponent<Image>();
        mat2 = Instantiate(mat) as Material;
        img.material = mat2;
       // rend.material= mat;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
