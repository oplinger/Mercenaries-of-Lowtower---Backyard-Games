using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfFireVisual : MonoBehaviour
{
    GameObject Line;
    public bool on;
    public GameObject ranged;

    // Use this for initialization
    void Start()
    {
        ranged = GameObject.Find("Bolt Spawn");
        DrawLine(ranged);
        Destroy(Line.GetComponent<MeshCollider>());
        Line.transform.Rotate(90, 0, 0);
        Line.transform.localScale += new Vector3(-.9f, 29, 0);
        Line.transform.position = ranged.transform.position + new Vector3(0, 0, 15);
        Line.transform.parent = ranged.transform;




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