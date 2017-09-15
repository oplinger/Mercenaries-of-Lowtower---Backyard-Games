using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HSVBonanza : MonoBehaviour {
    public GameObject hsvSphere;
    public Renderer hsvMat;
    float H, S, V;
	// Use this for initialization
	void Start () {
        hsvMat = hsvSphere.GetComponent<Renderer>();
        for (int i = 0; i < 50; i++)
        {
            //print(Color.HSVToRGB(.001f, Random.Range(0f, 1f), Random.Range(0f, f1)));
            GameObject clone;
            Renderer cloneMat;
            clone = Instantiate(hsvSphere, transform.position, Quaternion.identity);
            //clone.AddComponent<Material>();
            cloneMat=clone.GetComponent<Renderer>();
            //cloneMat.material.color =  Color.HSVToRGB(Random.Range(0f,1f),Random.Range(.1f,.5f),Random.Range(.8f,1f));
            cloneMat.material.color = Color.HSVToRGB(Random.Range(0f, 1f), Random.Range(.1f, 1f), Random.Range(.2f, .4f));
            transform.position += new Vector3(1, 0, 0);
            
        }
        transform.position += new Vector3(0, 0, 2);
        for (int i = 0; i < 50; i++)
        {
            
            //print(Color.HSVToRGB(.001f, Random.Range(0f, 1f), Random.Range(0f, f1)));
            GameObject clone;
            Renderer cloneMat;
            clone = Instantiate(hsvSphere, transform.position, Quaternion.identity);
            //clone.AddComponent<Material>();
            cloneMat = clone.GetComponent<Renderer>();
            cloneMat.material.color = Color.HSVToRGB(Random.Range(0f, 1f), Random.Range(.1f, .5f), Random.Range(.6f, 1f));
            //cloneMat.material.color = Color.HSVToRGB(Random.Range(0f, 1f), Random.Range(.1f, 1f), Random.Range(.4f, .7f));
            transform.position += new Vector3(-1, 0, 0);

        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
