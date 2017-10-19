using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfFireVisual : MonoBehaviour {
    GameObject Line;
    public bool on;
    public GameObject ranged;

	// Use this for initialization
	void Start () {
        ranged = GameObject.Find("Ranged Character");
        Line.transform.localScale += new Vector3(-.9f, 29, 0);

    }

    // Update is called once per frame
    void Update () {

        LineOn();
	}
    public void DrawLine(GameObject origin)
    {
        Line = GameObject.CreatePrimitive(PrimitiveType.Quad);

    }
    public void LineOn()
    {
        if (on)
        {
            Line.SetActive(true);
            transform.position = ranged.transform.position;
            Line.transform.rotation = ranged.transform.rotation;

        }
        else
        {
            Line.SetActive(false);

        }
    }
    public void OnBool()
    {
        if (Input.GetKey("k"))
        {
            on = true;
        } else
        {
            on = false;
        }
    }
     
}
