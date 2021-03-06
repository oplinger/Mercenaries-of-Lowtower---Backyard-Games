﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TsunamiScript : MonoBehaviour {
    float speed;
    float duration;
    float timer;
    
    public float tsunamiDamage;

    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(this);

    }

    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;

        transform.Translate((Vector3.forward * speed) * Time.deltaTime);

        if (timer >= duration)
        {
            speed = 0;
            transform.position = new Vector3(0, -100, 0);
            timer = 0;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Health>().modifyHealth(20, 9);
    }

    public void SetTsunamiSpeed(float speed1)
    {
        speed = speed1;
    }
    public void SetTsunamiDuration(float tdur)
    {
        duration = tdur;
    }
}
