using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {
    public Vector3 defaultPos;
    public float intensity;
    public float duration;
    public float countdown;

    public bool shaking;
	// Use this for initialization
	void Start () {
        defaultPos = transform.position;
        countdown = duration;
	}
	
	// Update is called once per frame
	void Update () {
        if (shaking)
        {
            if (countdown > 0)
            {
                countdown -= Time.deltaTime;
                transform.position = new Vector3(Random.Range(defaultPos.x - (1 * intensity), defaultPos.x + (1 * intensity)), Random.Range(defaultPos.y - (1 * intensity), defaultPos.y + (1 * intensity)), defaultPos.z/*Random.Range(defaultPos.z - (1*intensity), defaultPos.z + (1*intensity))*/);
            }
            else
            {
                transform.position = defaultPos;
                shaking = false;
                countdown = duration;
            }
        }
	}
}
