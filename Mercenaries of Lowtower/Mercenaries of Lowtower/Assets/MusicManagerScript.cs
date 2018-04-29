using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManagerScript : MonoBehaviour {

    public GameObject bossManager;
    public BossControlScriptV2 bossScript;

    public GameObject introMusic;
    public GameObject mainMusic;
    public GameObject finaleMusic;

	// Use this for initialization
	void Start () {

        bossScript = bossManager.GetComponent<BossControlScriptV2>();

        mainMusic.SetActive(false);
        finaleMusic.SetActive(false);
		
	}
	
	// Update is called once per frame
	void Update () {

        if (bossScript.bossPhase>=1)
        {
            introMusic.SetActive(false);
            mainMusic.SetActive(true);
        }

        if (bossScript.bossPhase>=7)
        {
            mainMusic.SetActive(false);
            finaleMusic.SetActive(true);
        }

		
	}
}
