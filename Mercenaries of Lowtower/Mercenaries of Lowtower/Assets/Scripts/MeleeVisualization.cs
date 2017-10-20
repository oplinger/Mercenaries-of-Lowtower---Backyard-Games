using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeVisualization : MonoBehaviour {

    GameObject Line;
    public bool on;
    public GameObject melee;
    // Use this for initialization
    void Start () {
        melee = GameObject.Find("Melee Character");
        DrawLine(melee);
        Destroy(Line.GetComponent<MeshCollider>());
        Line.transform.Rotate(90, 0, 0);
        Line.transform.localScale += new Vector3(1, 3, 0);
        Line.transform.position = melee.transform.position + new Vector3(0, 0, 1);
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
