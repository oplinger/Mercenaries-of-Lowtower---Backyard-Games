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
    public GameObject shootFromHere;
    public GameObject sparkParticles;
    public GameObject postSmokeParticles;
    public GameObject cannonFireParticles;

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
            //bossManager.GetComponent<BossControlScriptV2>().cannonFired = true;
            Destroy(other.gameObject);
           GetComponentInChildren<Light>().enabled = false;

            if (bossManager.GetComponent<BossControlScriptV2>().cannonballHits<2)
            {
                if (!GameObject.Find("cannonball(Clone)"))
                {
                    Instantiate(cannonball, cannonballSpawner.position, transform.rotation);
                }
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

        //turn on particle sparks
        sparkParticles.SetActive(true);

        //cannon flashing
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

        //shoot prop cannonball
        Instantiate(cannonballProp, new Vector3(shootFromHere.transform.position.x, shootFromHere.transform.position.y, shootFromHere.transform.position.z), shootFromHere.transform.rotation);

        //turn off particle sparks
        sparkParticles.SetActive(false);

        //turn on fire particles
        cannonFireParticles.SetActive(true);
        

        //cannon stretch
        timer = 0;
        while (timer < time)
        {
            timer += Time.deltaTime;
            cannonRenderer.material.SetColor("_EmissionColor", Color.Lerp(flashColour, flashColour2, Mathf.PingPong(Time.time * 9, 2)));
            cannonBarrel.transform.localScale += new Vector3(0, .5f, 0);
            yield return null;
        }


        //cannon return to size
        timer = 0;
        while (timer < time)
        {
            timer += Time.deltaTime;
            cannonRenderer.material.SetColor("_EmissionColor", Color.black);
            cannonBarrel.transform.localScale = Vector3.Lerp(cannonBarrel.transform.localScale, new Vector3(ogScale, ogScale, ogScale), time);
            yield return null;
        }

        ////turn on smoke particles
        //postSmokeParticles.SetActive(true);

        //turn off fire particles
        yield return new WaitForSeconds(10);
        cannonFireParticles.SetActive(false);

       // //turn off smoke particles
       // yield return new WaitForSeconds(3);
       //postSmokeParticles.SetActive(false);



    }
}
