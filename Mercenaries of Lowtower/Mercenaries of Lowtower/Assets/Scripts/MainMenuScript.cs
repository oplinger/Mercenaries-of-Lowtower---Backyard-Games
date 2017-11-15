using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour {
    public Button butts;
    public Camera mCam;
    public GameObject lookTar;
    float timer;
    bool timerGo;
    public float travelDuration;
    Quaternion look;
	// Use this for initialization
	void Start () {
        butts = GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update () {
        butts.onClick.AddListener(DoAThing);
        //look = Quaternion.LookRotation(lookTar.transform.position);
        if (timerGo)
        {
            timer += Time.deltaTime;
            // mCam.transform.position = Vector3.Lerp(mCam.transform.position, lookTar.transform.position - new Vector3(0, 0, 10), travelDuration);
            //mCam.transform.rotation = Quaternion.Lerp(mCam.transform.rotation, look, timer);
            mCam.transform.rotation = Quaternion.LookRotation(lookTar.transform.position);
           // mCam.transform.position = Vector3.MoveTowards(mCam.transform.position, lookTar.transform.position - new Vector3(0, -1, 10), travelDuration);


        }

	}

    void DoAThing()
    {
        timerGo = true;
    }
}
