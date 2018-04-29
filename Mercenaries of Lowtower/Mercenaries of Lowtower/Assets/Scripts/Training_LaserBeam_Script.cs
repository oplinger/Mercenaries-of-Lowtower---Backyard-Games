using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Training_LaserBeam_Script : MonoBehaviour {

    AudioSource laserAudioSource;

    void Start()
    {
        laserAudioSource = GetComponent<AudioSource>();
        laserAudioSource.Play();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            other.GetComponent<IDamageable<float>>().TakeDamage(40);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
