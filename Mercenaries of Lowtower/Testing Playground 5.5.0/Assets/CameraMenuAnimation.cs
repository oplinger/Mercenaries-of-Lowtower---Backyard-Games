using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMenuAnimation : MonoBehaviour {
    public float distance;
    public GameObject target;
    public GameObject lookTarget;
    Quaternion relativeRot;
    Vector3 relativePos;
    public float timer=0;
    public float timer2;
    bool canRotate = true;
    
    // Use this for initialization
    void Start () {
        relativeRot = transform.rotation;
        relativePos = transform.position;

    }
	
	// Update is called once per frame
	void Update () {
        timer +=Time.deltaTime;
        distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance > 2)
        {
            transform.position = Vector3.Lerp(relativePos, lookTarget.transform.position, timer/.75f);
            transform.rotation = Quaternion.Lerp(relativeRot, lookTarget.transform.rotation, timer / .75f);
        }

        if (distance < 2)
        {
            if (canRotate)
            {
                UpdateRotation();

            }
            timer2 += Time.deltaTime;
            //transform.LookAt(lookTarget.transform);
           // transform.rotation = Quaternion.Lerp(relativeRot, lookTarget.transform.rotation, timer2 / .1f);
             transform.RotateAround(target.transform.position, Vector3.up, (360 * Time.deltaTime / 600)*-1);
        }



    }
    void UpdateRotation()
    {
        relativeRot = transform.rotation;
        canRotate = false;
    }
}
