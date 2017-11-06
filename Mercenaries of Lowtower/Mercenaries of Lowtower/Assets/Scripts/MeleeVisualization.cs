using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeVisualization : MonoBehaviour
{
    GameObject Line;
    public bool on;
    public GameObject melee;
    // Use this for initialization
    void Start()
    {
        // Finds melee character, creates a quad, orients the quad, shapes the quad, parents it to the character.
        melee = GameObject.Find("Melee Character(Clone)");
        DrawLine(melee);
        Destroy(Line.GetComponent<MeshCollider>());
        Line.transform.Rotate(90, 0, 0);
        Line.transform.localScale += new Vector3(1, 4, 0);
        Line.transform.position = melee.transform.position + new Vector3(0, 0, 2);
        Line.transform.parent = melee.transform;

    }

    // Update is called once per frame
    void Update()
    {
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

    //Works with the above
    public void OnBool(bool thing)
    {
        if (thing)
        {
            on = true;
        }
        else
        {
            on = false;
        }
    }


}
