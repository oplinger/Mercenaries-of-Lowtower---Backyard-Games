using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfFireVisual : MonoBehaviour {
    GameObject Line;
    public bool on;
    public GameObject ranged;

	// This creates a quad to visualize the direction of travel of the ranged projectiles.
	void Start () {

        // Finds the spawn game object for bolts, creates a quad, orients the quad, shapes the quad, parents it to the bolt spawn.
        ranged = GameObject.Find("Bolt Spawn");
        DrawLine(ranged);
        Destroy(Line.GetComponent<MeshCollider>());
        Line.transform.Rotate(90, 0, 0);
        Line.transform.localScale += new Vector3(-.9f, 29, 0);
        Line.transform.position = ranged.transform.position + new Vector3(0, 0, 15);
        Line.transform.parent = ranged.transform;


        

    }

    // Update is called once per frame
    void Update () {

        LineOn();
	}
    public void DrawLine(GameObject origin)
    {
        Line = GameObject.CreatePrimitive(PrimitiveType.Quad);

    }

    // bool for turning the visualization on or off.
    public void LineOn()
    {
        if (on)
        {
            Line.SetActive(true);

        }
        else
        {
            Line.SetActive(false);

        }
    }

    // Works with the above.
    public void OnBool(bool thing)
    {
        if (thing)
        {
            on = true;
        } else
        {
            on = false;
        }
    }
     
}
