using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FireCannon : MonoBehaviour {

    public GameObject cannonball;
    public GameObject cannonballProp;
    public GameObject bossManager;
    public Transform cannonballSpawner;

    public Renderer cannonRenderer;
    public Color flashColour;
    public Color flashColour2;
    public int flashTime;

    public GameObject cannonBarrel;

    public float ogScale;
    //Reference to the phase-changing script
    //public PhaseControllerScript phaseScript;

    // Use this for initialization
    void Start () {

        cannonRenderer = cannonBarrel.GetComponent<Renderer>();

        ogScale = cannonBarrel.transform.localScale.y;
        
		
	}
	
	// Update is called once per frame
	void Update () {




    }

    private void OnTriggerEnter(Collider other)

    {

        if (other.tag == "PickUp")
        {

            //phaseScript.cannonFired = true;
                StartCoroutine(PumpColour(flashColour, flashTime));
            bossManager.GetComponent<BossControlScriptV2>().cannonFired = true;
            Destroy(other.gameObject);
            Instantiate(cannonballProp, new Vector3(transform.position.x, transform.position.y+3, transform.position.z), transform.rotation);
           GetComponentInChildren<Light>().enabled = false;

            if (bossManager.GetComponent<BossControlScriptV2>().cannonballHits<2)
            {
                Instantiate(cannonball, cannonballSpawner.position, transform.rotation);
            }



            //GameObject firedBall = Instantiate(cannonball, transform.position, transform.rotation);
            //Rigidbody rb = firedBall.GetComponent<Rigidbody>();
            //rb.AddForce(transform.forward * 2);

            //other.transform.position = this.gameObject.transform.position;
            //Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            //rb.AddForce(transform.forward * 2);
        }
    }


    private IEnumerator PumpColour(Color target, float time)
    {

        //float timer = 0;
        //while (timer < time)
        //{
        //    timer += Time.deltaTime;
        //    cannonRenderer.material.SetColor("_EmissionColor", Color.Lerp(flashColour, flashColour2, Mathf.PingPong(Time.time * 3, 1)));
        //    yield return null;
        //}

       float timer = 0;
        while (timer < time)
        {
            timer += Time.deltaTime;
            cannonRenderer.material.SetColor("_EmissionColor", Color.Lerp(flashColour, flashColour2, Mathf.PingPong(Time.time * 9, 1)));
            yield return null;
        }

        //cannon squash
         timer = 0;
        time = .3f;
        while (timer < time)
        {
            timer += Time.deltaTime;
            cannonRenderer.material.SetColor("_EmissionColor", Color.black);
            cannonBarrel.transform.localScale -= new Vector3(0, .05f, 0);
            yield return null;
        }

        //cannon stretch
         timer = 0;
        while (timer < time)
        {
            timer += Time.deltaTime;
            cannonRenderer.material.SetColor("_EmissionColor", Color.Lerp(flashColour, flashColour2, Mathf.PingPong(Time.time * 9, 2)));
            cannonBarrel.transform.localScale += new Vector3(0, .5f, 0);
            yield return null;
        }

        //cannon return
        timer = 0;
        while (timer < time)
        {
            timer += Time.deltaTime;
            cannonRenderer.material.SetColor("_EmissionColor", Color.black);
            cannonBarrel.transform.localScale = Vector3.Lerp(cannonBarrel.transform.localScale, new Vector3(ogScale, ogScale, ogScale), time);
            yield return null;
        }

    }
}
