using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    public GameObject boss;

    public Text[] texts;
    public Image[] healthBars;

    Health player1Health;
    Health player2Health;
    Health player3Health;
    Health player4Health;
    Health bossHealth;

    float imagewidth;
    // Use this for initialization
    void Awake () {
        texts = GetComponentsInChildren<Text>();
        healthBars = GetComponentsInChildren<Image>();

        player1Health = player1.GetComponent<Health>();
        player2Health = player2.GetComponent<Health>();
        player3Health = player3.GetComponent<Health>();
        player4Health = player4.GetComponent<Health>();
        bossHealth = boss.GetComponent<Health>();

        //Image bossHealthBar = healthBars[9];

        imagewidth = healthBars[9].rectTransform.rect.width;
    }
	
	// Update is called once per frame
	void Update () {
        //Health bossHealth = boss.GetComponent<Health>();
        print(healthBars[9].rectTransform.rect.width);

        texts[4].text = bossHealth.health.ToString();
        healthBars[9].rectTransform.sizeDelta = new Vector2 (300 * (bossHealth.health / 100), 25);
       



    }
}
