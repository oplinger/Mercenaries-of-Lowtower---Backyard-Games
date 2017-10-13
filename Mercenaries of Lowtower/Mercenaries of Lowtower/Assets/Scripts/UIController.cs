using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject[] players;
    public GameObject boss;
    public GameObject controllerThing;
    ControllerThing controller;
    PlayerCDController playerCooldowns;

    public float timer = 600;

    public Text[] texts;
    public Image[] healthBars;


    Health[] playerHealth;
    //Health player1Health;
    //Health player2Health;
    //Health player3Health;
    //Health player4Health;
    Health bossHealth;

    float imagewidth;
    // Use this for initialization
    void Start()
    {
        controller = controllerThing.GetComponent<ControllerThing>();
        players = new GameObject[4];
        playerHealth = new Health[4];

        for (int i = 0; i < controller.IDs.Length; i++)
        {
            players[i] = controller.IDs[i].gameObject;
            playerHealth[i] = players[i].GetComponent<Health>();

        }


        texts = GetComponentsInChildren<Text>();
        healthBars = GetComponentsInChildren<Image>();
        timer = 600;
        //player1Health = player1.GetComponent<Health>();
        //player2Health = player2.GetComponent<Health>();
        //player3Health = player3.GetComponent<Health>();
        //player4Health = player4.GetComponent<Health>();
        bossHealth = boss.GetComponent<Health>();

        playerCooldowns = controller.GetComponent<PlayerCDController>();

        //Image bossHealthBar = healthBars[9];

        imagewidth = healthBars[9].rectTransform.rect.width;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        texts[5].text = timer.ToString();
        texts[4].text = bossHealth.health.ToString();

        healthBars[3].material.SetFloat("_Tween", playerCooldowns.activeCooldowns[0] / playerCooldowns.abilityCooldowns[0]);
        healthBars[4].material.SetFloat("_Tween", playerCooldowns.activeCooldowns[1] / playerCooldowns.abilityCooldowns[1]);
        healthBars[5].material.SetFloat("_Tween", playerCooldowns.activeCooldowns[2] / playerCooldowns.abilityCooldowns[2]);

        healthBars[9].material.SetFloat("_Tween", playerCooldowns.activeCooldowns[3] / playerCooldowns.abilityCooldowns[3]);
        healthBars[10].material.SetFloat("_Tween", playerCooldowns.activeCooldowns[4] / playerCooldowns.abilityCooldowns[4]);
        healthBars[11].material.SetFloat("_Tween", playerCooldowns.activeCooldowns[5] / playerCooldowns.abilityCooldowns[5]);

        healthBars[15].material.SetFloat("_Tween", playerCooldowns.activeCooldowns[6] / playerCooldowns.abilityCooldowns[6]);
        healthBars[16].material.SetFloat("_Tween", playerCooldowns.activeCooldowns[7] / playerCooldowns.abilityCooldowns[7]);
        healthBars[17].material.SetFloat("_Tween", playerCooldowns.activeCooldowns[8] / playerCooldowns.abilityCooldowns[8]);

        healthBars[21].material.SetFloat("_Tween", playerCooldowns.activeCooldowns[9] / playerCooldowns.abilityCooldowns[9]);
        healthBars[22].material.SetFloat("_Tween", playerCooldowns.activeCooldowns[10] / playerCooldowns.abilityCooldowns[10]);
        healthBars[23].material.SetFloat("_Tween", playerCooldowns.activeCooldowns[11] / playerCooldowns.abilityCooldowns[11]);



        healthBars[1].rectTransform.sizeDelta = new Vector2(100 * (playerHealth[0].health / 100), 20);
        healthBars[7].rectTransform.sizeDelta = new Vector2(100 * (playerHealth[1].health / 100), 20);
        healthBars[13].rectTransform.sizeDelta = new Vector2(100 * (playerHealth[2].health / 100), 20);
        healthBars[19].rectTransform.sizeDelta = new Vector2(100 * (playerHealth[3].health / 100), 20);

        healthBars[25].rectTransform.sizeDelta = new Vector2(300 * (bossHealth.health / 100), 25);




    }
}
