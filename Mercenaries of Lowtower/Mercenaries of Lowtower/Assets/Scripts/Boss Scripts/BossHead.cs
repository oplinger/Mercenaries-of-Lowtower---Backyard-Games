using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHead : BossClass {

    public GameObject boss;
    public GameObject bossManager;
    public int bossPhaseCounter;

    BossControlScriptV2 bossScript;
    
    public AudioSource bossHeadAudioSource;

    public AudioClip[] bossHit;

    public AudioClip cannonballThud;

    public AudioClip dying;

    int chosenOne;

	// Use this for initialization
	void Start () {

        bossScript = bossManager.GetComponent<BossControlScriptV2>();

        bossHeadAudioSource = GetComponent<AudioSource>();

        //bossHeadAudioSource.PlayDelayed(11.5f);
		
	}
	
	// Update is called once per frame
	void Update () {
        bossPhaseCounter = bossManager.GetComponent<BossControlScriptV2>().bossPhase;

	}

    public override void TakeDamage(float damageTaken)
    {
        if(bossPhaseCounter < 5)
        {
            boss.GetComponent<BossClass>().currentHealth -= damageTaken;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "cannonball_prop(Clone)")
            {

            if (bossScript.cannonballHits<2)
            {
                chosenOne = Random.Range(0, bossHit.Length);
                bossHeadAudioSource.PlayOneShot(bossHit[chosenOne]);
                bossHeadAudioSource.PlayOneShot(cannonballThud);

            }
            else if (bossScript.cannonballHits>=2)
            {
                bossHeadAudioSource.PlayOneShot(cannonballThud);
                bossHeadAudioSource.PlayOneShot(dying);

            }
        }
    }
}
