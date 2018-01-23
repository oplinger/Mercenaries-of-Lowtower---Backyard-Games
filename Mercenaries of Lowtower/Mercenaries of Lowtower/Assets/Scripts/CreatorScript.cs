using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor;
[ExecuteInEditMode]
public class CreatorScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MakeCube(Vector3 pos, bool loop, int loopInterval, Vector3 loopOffset)
    {
        if (!loop)
        {
            GameObject thing = GameObject.CreatePrimitive(PrimitiveType.Cube);
            thing.transform.position = pos;
        } else if (loop)
        {
            for (int i = 1; i < loopInterval+1; i++)
            {
                GameObject thing = GameObject.CreatePrimitive(PrimitiveType.Cube);
                thing.transform.position = pos;
                thing.transform.position += loopOffset*i;
            }
        }
    }
    public void MakeQuad(Vector3 pos, bool loop, int loopInterval, Vector3 loopOffset)
    {
        if (!loop) { 
        GameObject thing = GameObject.CreatePrimitive(PrimitiveType.Quad);
        thing.transform.position = pos;
    } else if (loop)
        {
            for (int i = 1; i<loopInterval+1; i++)
            {
                GameObject thing = GameObject.CreatePrimitive(PrimitiveType.Quad);
                thing.transform.position = pos;
                thing.transform.position += loopOffset* i;
            }
        }
    }
    public void MakeCapsule(Vector3 pos, bool loop, int loopInterval, Vector3 loopOffset)
    {
        if (!loop)
        {
            GameObject thing = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            thing.transform.position = pos;
        }
        else if (loop)
        {
            for (int i = 1; i < loopInterval + 1; i++)
            {
                GameObject thing = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                thing.transform.position = pos;
                thing.transform.position += loopOffset * i;
            }
        }
    }
    public void MakeCylinder(Vector3 pos, bool loop, int loopInterval, Vector3 loopOffset)
    {
        if (!loop)
        {
            GameObject thing = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            thing.transform.position = pos;
        }
        else if (loop)
        {
            for (int i = 1; i < loopInterval + 1; i++)
            {
                GameObject thing = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                thing.transform.position = pos;
                thing.transform.position += loopOffset * i;
            }
        }
    }
    public void MakeSphere(Vector3 pos, bool loop, int loopInterval, Vector3 loopOffset)
    {
        if (!loop)
        {
            GameObject thing = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            thing.transform.position = pos;
        }
        else if (loop)
        {
            for (int i = 1; i < loopInterval + 1; i++)
            {
                GameObject thing = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                thing.transform.position = pos;
                thing.transform.position += loopOffset * i;
            }
        }
    }
    public void MakeEmpty(Vector3 pos, bool loop, int loopInterval, Vector3 loopOffset)
    {
        if (!loop)
        {
            GameObject thing = new GameObject("GameObject");
            thing.transform.position = pos;
        }
        else if (loop)
        {
            for (int i = 1; i < loopInterval + 1; i++)
            {
                GameObject thing = new GameObject("GameObject");
                thing.transform.position = pos;
                thing.transform.position += loopOffset * i;
            }
        }

    }
    public void DuplicateSpecial(GameObject dupeThis, Vector3 dupeOffset, Vector3 dupeRotation, int loopInterval)
    {

        for (int i = 1; i < loopInterval + 1; i++)
        {
            GameObject thing;
           thing = Instantiate(dupeThis, dupeThis.transform.position, Quaternion.identity);
            thing.transform.position = dupeThis.transform.position+(dupeOffset* i);
            thing.transform.rotation = dupeThis.transform.rotation*Quaternion.Euler(dupeRotation*i);

        }
    }
}
