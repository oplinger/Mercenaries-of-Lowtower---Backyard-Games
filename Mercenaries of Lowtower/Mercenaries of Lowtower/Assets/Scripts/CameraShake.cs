using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {
    public Vector3 defaultPos;
    public float intensity;
    float initialIntensity;
    public float duration;
    public float countdown;

    public bool shaking;
	// Use this for initialization
	void Start () {
        defaultPos = transform.position;
        countdown = duration;
        initialIntensity = intensity;
	}
	
	// Update is called once per frame
	void Update () {
        if (shaking)
        {
            if (countdown > 0)
            {
                //intensity *= countdown;
                countdown -= Time.deltaTime;
                transform.position = new Vector3(Random.Range(defaultPos.x - (1 * (intensity * countdown)), defaultPos.x + (1 * (intensity * countdown))), Random.Range(defaultPos.y - (1 * (intensity * countdown)), defaultPos.y + (1 * (intensity * countdown))), defaultPos.z/*Random.Range(defaultPos.z - (1*(intensity * countdown)), defaultPos.z + (1*(intensity * countdown)))*/);
            }
            else
            {
                transform.position = defaultPos;
                shaking = false;
                countdown = duration;
                intensity = initialIntensity;
            }
        }
	}

    public void StartShake()
    {
        shaking = true;
    }
}
