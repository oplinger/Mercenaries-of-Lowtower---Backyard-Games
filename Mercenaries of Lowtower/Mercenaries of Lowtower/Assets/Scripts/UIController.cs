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
    public Image[] images;
    public List<Image> healthBars;
    public List<Image> icons;
    public List<Image> portraits;


    Health[] playerHealth;
    Health bossHealth;
#endregion

    // Use this for initialization
    void Start()
    {
        controllerThing = GameObject.Find("Controller Thing");
        controller = controllerThing.GetComponent<ControllerThing>();
        players = new GameObject[4];
        playerHealth = new Health[4];
        texts = GetComponentsInChildren<Text>();
        images = GetComponentsInChildren<Image>();
        timer = 600;
        bossHealth = boss.GetComponent<Health>();
        playerCooldowns = controller.GetComponent<PlayerCDController>();

        // Assigns players to slots based on IDs, for use with UI placement.
        //IE: Tank is in the top left, always.
        //This might be changed to player positions. So P1 is in the top left, P2 top right, etc
        for (int i = 0; i < controller.IDs.Length; i++)
        {
            players[i] = controller.IDs[i].gameObject;
            playerHealth[i] = players[i].GetComponent<Health>();

        }

        foreach (Image element in images)
        {
            if (element.tag == "AbilityIcon")
            {
                icons.Add(element);
            }
            if (element.tag == "HealthBar")
            {
                healthBars.Add(element);
            }
            if (element.tag == "PlayerPortrait")
            {
                portraits.Add(element);
            }
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


        icons[0].material.SetFloat("_Tween", playerCooldowns.activeCooldowns[0] / playerCooldowns.abilityCooldowns[0]);
        icons[0].material.SetTexture ("_MainTex", Resources.Load("Textures/Magnet") as Texture);
        icons[0].material.SetTexture("_SecondTex", Resources.Load("Textures/MagnetBW") as Texture);

        icons[1].material.SetFloat("_Tween", playerCooldowns.activeCooldowns[1] / playerCooldowns.abilityCooldowns[1]);
        icons[1].material.SetTexture("_MainTex", Resources.Load("Textures/Shield") as Texture);
        icons[1].material.SetTexture("_SecondTex", Resources.Load("Textures/ShieldBW") as Texture);

        icons[2].material.SetFloat("_Tween", playerCooldowns.activeCooldowns[2] / playerCooldowns.abilityCooldowns[2]);

        icons[3].material.SetFloat("_Tween", playerCooldowns.activeCooldowns[3] / playerCooldowns.abilityCooldowns[3]);
        icons[4].material.SetFloat("_Tween", playerCooldowns.activeCooldowns[4] / playerCooldowns.abilityCooldowns[4]);
        icons[5].material.SetFloat("_Tween", playerCooldowns.activeCooldowns[5] / playerCooldowns.abilityCooldowns[5]);

        icons[6].material.SetFloat("_Tween", playerCooldowns.activeCooldowns[6] / playerCooldowns.abilityCooldowns[6]);
        icons[7].material.SetFloat("_Tween", playerCooldowns.activeCooldowns[7] / playerCooldowns.abilityCooldowns[7]);
        icons[8].material.SetFloat("_Tween", playerCooldowns.activeCooldowns[8] / playerCooldowns.abilityCooldowns[8]);

        icons[9].material.SetFloat("_Tween", playerCooldowns.activeCooldowns[9] / playerCooldowns.abilityCooldowns[9]);
        icons[10].material.SetFloat("_Tween", playerCooldowns.activeCooldowns[10] / playerCooldowns.abilityCooldowns[10]);
        icons[11].material.SetFloat("_Tween", playerCooldowns.activeCooldowns[11] / playerCooldowns.abilityCooldowns[11]);
#endregion

        #region Health Bars
        //Health bars. Also changes the size of the health bars based on current health vs max health.
        healthBars[0].rectTransform.sizeDelta = new Vector2(100 * (playerHealth[0].health / playerHealth[0].maxHealth), 20);
        healthBars[1].rectTransform.sizeDelta = new Vector2(100 * (playerHealth[1].health / playerHealth[1].maxHealth), 20);
        healthBars[2].rectTransform.sizeDelta = new Vector2(100 * (playerHealth[2].health / playerHealth[2].maxHealth), 20);
        healthBars[3].rectTransform.sizeDelta = new Vector2(100 * (playerHealth[3].health / playerHealth[3].maxHealth), 20);

        healthBars[4].rectTransform.sizeDelta = new Vector2(300 * (bossHealth.health / bossHealth.maxHealth), 25);

#endregion

        
    }
}
