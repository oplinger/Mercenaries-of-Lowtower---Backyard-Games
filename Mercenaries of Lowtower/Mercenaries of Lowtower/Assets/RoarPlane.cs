using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoarPlane : MonoBehaviour {

    public AudioSource roarAudioSource;

    public AudioClip roar;

    public bool emerged;

	// Use this for initialization
	void Start () {

        emerged = false;

        roarAudioSource = GetComponent<AudioSource>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Tentacle" && emerged == false)
        {
            roarAudioSource.PlayOneShot(roar);
            emerged = true;
        }
    }
}
