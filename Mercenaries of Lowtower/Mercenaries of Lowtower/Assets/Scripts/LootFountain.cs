using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootFountain : MonoBehaviour {
    public GameObject[] Loot;
    //public List<GameObject> Lootfountain;
     float timer;
     float timer1;
     int lootCount;
    public float fountainTime;
    public float spawnTime;
    public float spawnConeDiameter;
    public float minUpForce;
    public float maxUpForce;
    public float intervalTime;


    // Use this for initialization
    void Start () {
        Loot = new GameObject[4];
        Loot[0] = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        Loot[0].AddComponent<Rigidbody>();
        Loot[1] = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Loot[1].AddComponent<Rigidbody>();

        Loot[2] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        Loot[2].AddComponent<Rigidbody>();

        Loot[3] = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        Loot[3].AddComponent<Rigidbody>();


    }

    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
        timer1 += Time.deltaTime;
        if (timer1 < fountainTime)
        {
            if (timer > spawnTime)
            {
                StartCoroutine(_LootFountain());
                timer = 0;
                print(lootCount);
            }
        }
    }
    IEnumerator _LootFountain()
    {
        GameObject clone;
        clone = Instantiate(Loot[Random.Range(0, 4)], transform.position, Quaternion.identity);
        clone.GetComponent<Rigidbody>().AddForce(Random.Range(-spawnConeDiameter, spawnConeDiameter), Random.Range(minUpForce, maxUpForce), Random.Range(-spawnConeDiameter, spawnConeDiameter), ForceMode.Impulse);
        clone.GetComponent<Renderer>().material.color = new Color(Random.Range(1, 1), Random.Range(0, 0), Random.Range(0, 0));
        lootCount++;
        yield return new WaitForSeconds(intervalTime);

        GameObject clone2;
        clone2 = Instantiate(Loot[Random.Range(0, 4)], transform.position, Quaternion.identity);
        clone2.GetComponent<Rigidbody>().AddForce(Random.Range(-spawnConeDiameter, spawnConeDiameter), Random.Range(minUpForce, maxUpForce), Random.Range(-spawnConeDiameter, spawnConeDiameter), ForceMode.Impulse);
        clone2.GetComponent<Renderer>().material.color = new Color(Random.Range(0, 0), Random.Range(1, 1), Random.Range(0, 0));

        lootCount++;
        yield return new WaitForSeconds(intervalTime);

        GameObject clone3;
        clone3 = Instantiate(Loot[Random.Range(0, 4)], transform.position, Quaternion.identity);
        clone3.GetComponent<Rigidbody>().AddForce(Random.Range(-spawnConeDiameter, spawnConeDiameter), Random.Range(minUpForce, maxUpForce), Random.Range(-spawnConeDiameter, spawnConeDiameter), ForceMode.Impulse);
        clone3.GetComponent<Renderer>().material.color = new Color(Random.Range(0, 0), Random.Range(0f, 0), Random.Range(1, 1));

        lootCount++;
        yield return new WaitForSeconds(intervalTime);

        GameObject clone4;
        clone4 = Instantiate(Loot[Random.Range(0, 4)], transform.position, Quaternion.identity);
        clone4.GetComponent<Rigidbody>().AddForce(Random.Range(-spawnConeDiameter, spawnConeDiameter), Random.Range(minUpForce, maxUpForce), Random.Range(-spawnConeDiameter, spawnConeDiameter), ForceMode.Impulse);
        clone4.GetComponent<Renderer>().material.color = new Color(Random.Range(1, 1), Random.Range(1, 1), Random.Range(0, 0));

        lootCount++;

        yield return new WaitForSeconds(intervalTime);

    }
}
