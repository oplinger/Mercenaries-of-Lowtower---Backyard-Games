using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltKnockback : MonoBehaviour {

    public AudioClip[] gust;
    int chosenOne;

    public AudioSource knockbackAudioSource;

    // Use this for initialization
    void Start () {

        knockbackAudioSource = GetComponent<AudioSource>();

        chosenOne = Random.Range(0, 2);
        
        knockbackAudioSource.pitch = Random.Range(1, 3);

        knockbackAudioSource.PlayOneShot(gust[chosenOne], .8f);
    }
	
	// Update is called once per frame
	void Update ()
    {


    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            other.GetComponent<Rigidbody>().AddForce((other.transform.position - gameObject.transform.position)*22, ForceMode.Impulse);
            Destroy(gameObject);
        }
    }
}
