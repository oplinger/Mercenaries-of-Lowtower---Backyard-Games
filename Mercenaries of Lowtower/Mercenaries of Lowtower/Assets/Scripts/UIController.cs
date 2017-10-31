using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    #region Variables
    public GameObject[] players;
    public GameObject boss;
    public GameObject controllerThing;
    ControllerThing controller;
    PlayerCDController playerCooldowns;
    public float timer = 600;
    public Text[] texts;
    public Image[] healthBars;
    Health[] playerHealth;
    Health bossHealth;
    float imagewidth;
#endregion

    // Use this for initialization
    void Start()
    {
        controller = controllerThing.GetComponent<ControllerThing>();
        players = new GameObject[4];
        playerHealth = new Health[4];
        texts = GetComponentsInChildren<Text>();
        healthBars = GetComponentsInChildren<Image>();
        timer = 600;
        bossHealth = boss.GetComponent<Health>();
        playerCooldowns = controller.GetComponent<PlayerCDController>();
        imagewidth = healthBars[9].rectTransform.rect.width;

        // Assigns players to slots based on IDs, for use with UI placement.
        //IE: Tank is in the top left, always.
        //This might be changed to player positions. So P1 is in the top left, P2 top right, etc
        for (int i = 0; i < controller.IDs.Length; i++)
        {
            players[i] = controller.IDs[i].gameObject;
            playerHealth[i] = players[i].GetComponent<Health>();

        }

    }

    // Update is called once per frame
    void Update()
    {
        #region Timers
        timer -= Time.deltaTime;
        texts[5].text = timer.ToString();
        texts[4].text = bossHealth.health.ToString();
#endregion

        #region Cooldown Icons

        //Fades from one textures into another. Visualization of the CD rather than a timer.

        //FIND WAY TO SEPARATE FROM HEALTH BAR ARRAY.

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
#endregion

        #region Health Bars
        //Health bars. Also changes the size of the health bars based on current health vs max health.
        healthBars[1].rectTransform.sizeDelta = new Vector2(100 * (playerHealth[0].health / 100), 20);
        healthBars[7].rectTransform.sizeDelta = new Vector2(100 * (playerHealth[1].health / 100), 20);
        healthBars[13].rectTransform.sizeDelta = new Vector2(100 * (playerHealth[2].health / 100), 20);
        healthBars[19].rectTransform.sizeDelta = new Vector2(100 * (playerHealth[3].health / 100), 20);

        healthBars[25].rectTransform.sizeDelta = new Vector2(300 * (bossHealth.health / 100), 25);

#endregion


    }
}
