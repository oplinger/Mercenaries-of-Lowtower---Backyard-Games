using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMaterial : MonoBehaviour {
    public Material mat;
    public Material mat2;

    public Renderer rend;
    public Image img;

    //Pulls components in, and creates instances of materials for the shader to draw from
        void Start () {
        rend = GetComponent<Renderer>();
        img = GetComponent<Image>();
        mat2 = Instantiate(mat) as Material;
        img.material = mat2;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
