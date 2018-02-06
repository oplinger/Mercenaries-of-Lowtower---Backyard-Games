using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CreatorScript))]
public class CreatorScriptEditor : Editor {

    public Vector3 creationPosition;
    public int loopInterval;
    public int copies;

    public bool loop;
    public Vector3 loopOffset;
    public Vector3 duplicateOffset;
    public Vector3 duplicateRotation;
    public bool local;
    public Object duplicateThis;


    private void OnEnable()
    {
        
    }


    public override void OnInspectorGUI()
    {
        //DrawDefaultInspector();
        

        CreatorScript myscript = (CreatorScript)target;
        SerializedObject serializedObject = new UnityEditor.SerializedObject(myscript);

        creationPosition = EditorGUILayout.Vector3Field("Creation Position", creationPosition);
        GUILayout.Space(10);
        loop = EditorGUILayout.Toggle("Loop", loop);
        loopInterval = EditorGUILayout.IntField("Loop Interval", loopInterval);
        loopOffset = EditorGUILayout.Vector3Field("Loop Offset", loopOffset);

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Cube", GUILayout.Width(Screen.width / 2.2f)))
        {
            myscript.MakeCube(creationPosition, loop, loopInterval, loopOffset);
        }

        if (GUILayout.Button("Quad", GUILayout.Width(Screen.width / 2.2f)))
        {
            myscript.MakeQuad(creationPosition, loop, loopInterval, loopOffset);
        }
             GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
        if (GUILayout.Button("Capsule", GUILayout.Width(Screen.width / 2.2f)))
        {
            myscript.MakeCapsule(creationPosition, loop, loopInterval, loopOffset);
        }

        if (GUILayout.Button("Cylinder", GUILayout.Width(Screen.width / 2.2f)))
        {
            myscript.MakeCylinder(creationPosition, loop, loopInterval, loopOffset);
        }

            GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Sphere", GUILayout.Width(Screen.width / 2.2f)))
        {
            myscript.MakeSphere(creationPosition, loop, loopInterval, loopOffset);
        }
        if (GUILayout.Button("Empty", GUILayout.Width(Screen.width / 2.2f)))
        {
            myscript.MakeEmpty(creationPosition, loop, loopInterval, loopOffset);
        }
        GUILayout.EndHorizontal();

        GUILayout.Space(10);

        duplicateThis = EditorGUILayout.ObjectField("Duplicate This", duplicateThis, typeof(GameObject), true);
        duplicateOffset = EditorGUILayout.Vector3Field("Duplicate Position Offset", duplicateOffset);
        duplicateRotation = EditorGUILayout.Vector3Field("Duplicate Rotation Offset", duplicateRotation);
        copies = EditorGUILayout.IntField("Copies", copies);

        if (GUILayout.Button("Duplicate Special")){
            myscript.DuplicateSpecial(duplicateThis as GameObject, duplicateOffset,duplicateRotation, copies);
        }



    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
