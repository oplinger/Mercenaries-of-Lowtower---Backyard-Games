using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControllerPreloaded : MonoBehaviour
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

    float[] healths1;
    float[] healths2;

    public GameObject tank;
    public GameObject healer;
    public GameObject melee;
    public GameObject ranged;


    public Health[] playerHealth;
    Health bossHealth;



#endregion

    // Use this for initialization
    void Start()
    {
        controllerThing = GameObject.Find("Controller Thing");
        controller = controllerThing.GetComponent<ControllerThing>();
        //players = new GameObject[4];
        //playerHealth = new Health[4];
        texts = GetComponentsInChildren<Text>();
        images = GetComponentsInChildren<Image>();
        timer = 600;
        bossHealth = boss.GetComponent<Health>();
        playerCooldowns = controller.GetComponent<PlayerCDController>();
        healths1 = new float[4];

        healths2 = new float[4];
        
        // Assigns players to slots based on IDs, for use with UI placement.
        //IE: Tank is in the top left, always.
        //This might be changed to player positions. So P1 is in the top left, P2 top right, etc
        for (int i = 0; i < 3; i++)
        {

            print("ugandan knuckles");
            //players[i] = controller.IDs[i].gameObject;
            //playerHealth[i] = players[i].GetComponent<Health>();
            healths2[i] = playerHealth[i].health;

        }

        //foreach (Image element in images)
        //{
        //    if (element.tag == "AbilityIcon")
        //    {
        //        icons.Add(element);
        //    }
        //    if (element.tag == "HealthBar")
        //    {
        //        healthBars.Add(element);
        //    }
        //    if (element.tag == "PlayerPortrait")
        //    {
        //        portraits.Add(element);
        //    }
        //}

    }

    // Update is called once per frame
    void Update()
    {

        //print(playerHealth[0].health);
        //print(healthBars[0].rectTransform.sizeDelta);
        



            #region Timers
            timer -= Time.deltaTime;
        texts[5].text = timer.ToString();
        texts[4].text = bossHealth.health.ToString();
        #endregion

        #region Cooldown Icons

        //Fades from one textures into another. Visualization of the CD rather than a timer.


        icons[0].material.SetFloat("_Tween", playerCooldowns.activeCooldowns[0] / playerCooldowns.abilityCooldowns[0]);
        icons[0].material.SetTexture ("_MainTex", Resources.Load("Textures/MagnetPull") as Texture);
        icons[0].material.SetTexture("_SecondTex", Resources.Load("Textures/MagnetPullBlack") as Texture);
        if (icons[0].material.GetFloat("_Tween") <= 0)
        {
            icons[0].rectTransform.localScale = new Vector3(2, 2, 2);
        }
        else
        {
            icons[0].rectTransform.localScale = new Vector3(1, 1, 1);

        }

        icons[1].material.SetFloat("_Tween", playerCooldowns.activeCooldowns[1] / playerCooldowns.abilityCooldowns[1]);
        icons[1].material.SetTexture("_MainTex", Resources.Load("Textures/BubbleShield") as Texture);
        icons[1].material.SetTexture("_SecondTex", Resources.Load("Textures/BubbleShieldBlack") as Texture);
        if (icons[1].material.GetFloat("_Tween") <= 0)
        {
            icons[1].rectTransform.localScale = new Vector3(2, 2, 2);
        }
        else
        {
            icons[1].rectTransform.localScale = new Vector3(1, 1, 1);

        }

        icons[2].material.SetFloat("_Tween", playerCooldowns.activeCooldowns[2] / playerCooldowns.abilityCooldowns[2]);
        icons[2].material.SetTexture("_MainTex", Resources.Load("Textures/ReflectionAttackww") as Texture);
        icons[2].material.SetTexture("_SecondTex", Resources.Load("Textures/ReflectionAttackBlack") as Texture);
        if (icons[2].material.GetFloat("_Tween") <= 0)
        {
            icons[2].rectTransform.localScale = new Vector3(2, 2, 2);
        }
        else
        {
            icons[2].rectTransform.localScale = new Vector3(1, 1, 1);

        }

        if (players[0].GetComponent<TankController>().altBuild)
        {
            icons[2].enabled = true;
            icons[0].enabled = false;
            if(healths2[0]==healths1[0])
            portraits[0].GetComponent<Image>().color = Color.HSVToRGB(.613f, .537f, .4f);

        }
        else
        {
            icons[0].enabled = true;
            icons[2].enabled = false;
            if (healths2[0] == healths1[0])
                portraits[0].GetComponent<Image>().color = Color.HSVToRGB(.613f, .537f, .82f);


        }

        icons[3].material.SetFloat("_Tween", playerCooldowns.activeCooldowns[3] / playerCooldowns.abilityCooldowns[3]);
        icons[3].material.SetTexture("_MainTex", Resources.Load("Textures/HealEffect") as Texture);
        icons[3].material.SetTexture("_SecondTex", Resources.Load("Textures/HealEffectBlack") as Texture);
        if (icons[3].material.GetFloat("_Tween") <= 0)
        {
            icons[3].rectTransform.localScale = new Vector3(2, 2, 2);
        }
        else
        {
            icons[3].rectTransform.localScale = new Vector3(1, 1, 1);

        }

        icons[4].material.SetFloat("_Tween", playerCooldowns.activeCooldowns[4] / playerCooldowns.abilityCooldowns[4]);
        icons[4].material.SetTexture("_MainTex", Resources.Load("Textures/Teleport") as Texture);
        icons[4].material.SetTexture("_SecondTex", Resources.Load("Textures/TeleportBlack") as Texture);
        if (icons[4].material.GetFloat("_Tween") <= 0)
        {
            icons[4].rectTransform.localScale = new Vector3(2, 2, 2);
        }
        else
        {
            icons[4].rectTransform.localScale = new Vector3(1, 1, 1);

        }

        icons[5].material.SetFloat("_Tween", playerCooldowns.activeCooldowns[5] / playerCooldowns.abilityCooldowns[5]);
        icons[5].material.SetTexture("_MainTex", Resources.Load("Textures/FearEffect") as Texture);
        icons[5].material.SetTexture("_SecondTex", Resources.Load("Textures/GearEffectBlack") as Texture);
        if (icons[5].material.GetFloat("_Tween") <= 0)
        {
            icons[5].rectTransform.localScale = new Vector3(2, 2, 2);
        }
        else
        {
            icons[5].rectTransform.localScale = new Vector3(1, 1, 1);

        }

        if (players[1].GetComponent<HealerController>().altBuild)
        {
            icons[5].enabled = true;
            icons[4].enabled = false;
            if (healths2[1] == healths1[1])
                portraits[1].GetComponent<Image>().color = Color.HSVToRGB(.2f, .89f, .5f);


        }
        else
        {
            icons[4].enabled = true;
            icons[5].enabled = false;
            if (healths2[1] == healths1[1])
                portraits[1].GetComponent<Image>().color = Color.HSVToRGB(.2f, .89f, .95f);


        }

        icons[6].material.SetFloat("_Tween", playerCooldowns.activeCooldowns[6] / playerCooldowns.abilityCooldowns[6]);
        icons[6].material.SetTexture("_MainTex", Resources.Load("Textures/MeleeStrike") as Texture);
        icons[6].material.SetTexture("_SecondTex", Resources.Load("Textures/MeleeStrikeBlack") as Texture);
        if (icons[6].material.GetFloat("_Tween") <= 0)
        {
            icons[6].rectTransform.localScale = new Vector3(2, 2, 2);
        }
        else
        {
            icons[6].rectTransform.localScale = new Vector3(1, 1, 1);

        }

        icons[7].material.SetFloat("_Tween", playerCooldowns.activeCooldowns[7] / playerCooldowns.abilityCooldowns[7]);
        icons[7].material.SetTexture("_MainTex", Resources.Load("Textures/MeleeCyclone1") as Texture);
        icons[7].material.SetTexture("_SecondTex", Resources.Load("Textures/MeleeCycloneBlack1") as Texture);
        if (icons[7].material.GetFloat("_Tween") <= 0)
        {
            icons[7].rectTransform.localScale = new Vector3(2, 2, 2);
        }
        else
        {
            icons[7].rectTransform.localScale = new Vector3(1, 1, 1);

        }

        icons[8].material.SetFloat("_Tween", playerCooldowns.activeCooldowns[8] / playerCooldowns.abilityCooldowns[8]);
        icons[8].material.SetTexture("_MainTex", Resources.Load("Textures/MeleeLuge") as Texture);
        icons[8].material.SetTexture("_SecondTex", Resources.Load("Textures/MeleeLugeBlack") as Texture);
        if (icons[8].material.GetFloat("_Tween") <= 0)
        {
            icons[8].rectTransform.localScale = new Vector3(2, 2, 2);
        }
        else
        {
            icons[8].rectTransform.localScale = new Vector3(1, 1, 1);

        }

        if (players[2].GetComponent<MeleeController>().altBuild)
        {
            icons[8].enabled = true;
            icons[7].enabled = false;
            if (healths2[2] == healths1[2])
                portraits[2].GetComponent<Image>().color = Color.HSVToRGB(.016f, .788f, .5f);


        }
        else
        {
            icons[7].enabled = true;
            icons[8].enabled = false;
            if (healths2[2] == healths1[2])
                portraits[2].GetComponent<Image>().color = Color.HSVToRGB(.016f, .788f, .95f);


        }

        icons[9].material.SetFloat("_Tween", playerCooldowns.activeCooldowns[9] / playerCooldowns.abilityCooldowns[9]);
        icons[9].material.SetTexture("_MainTex", Resources.Load("Textures/RangedArrowShot") as Texture);
        icons[9].material.SetTexture("_SecondTex", Resources.Load("Textures/RangedArrowShotBlack") as Texture);
        if (icons[9].material.GetFloat("_Tween") <= 0)
        {
            icons[9].rectTransform.localScale = new Vector3(2, 2, 2);
        }
        else
        {
            icons[9].rectTransform.localScale = new Vector3(1, 1, 1);

        }

        icons[10].material.SetFloat("_Tween", playerCooldowns.activeCooldowns[10] / playerCooldowns.abilityCooldowns[10]);
        icons[10].material.SetTexture("_MainTex", Resources.Load("Textures/SmokeBomb") as Texture);
        icons[10].material.SetTexture("_SecondTex", Resources.Load("Textures/SmokeBombBlack") as Texture);
        if (icons[10].material.GetFloat("_Tween") <= 0)
        {
            icons[10].rectTransform.localScale = new Vector3(2, 2, 2);
        }
        else
        {
            icons[10].rectTransform.localScale = new Vector3(1, 1, 1);

        }

        icons[11].material.SetFloat("_Tween", playerCooldowns.activeCooldowns[11] / playerCooldowns.abilityCooldowns[11]);
        icons[11].material.SetTexture("_MainTex", Resources.Load("Textures/BluntTipped") as Texture);
        icons[11].material.SetTexture("_SecondTex", Resources.Load("Textures/BluntTippedBlack") as Texture);
        if (icons[11].material.GetFloat("_Tween") <= 0)
        {
            icons[11].rectTransform.localScale = new Vector3(2, 2, 2);
        }
        else
        {
            icons[11].rectTransform.localScale = new Vector3(1, 1, 1);

        }

        if (players[3].GetComponent<RangedController>().altBuild)
        {
            icons[11].enabled = true;
            icons[10].enabled = false;
            if (healths2[3] == healths1[3])
                portraits[3].GetComponent<Image>().color = Color.HSVToRGB(.216f, .6f, .2f);


        }
        else
        {
            icons[10].enabled = true;
            icons[11].enabled = false;
            if (healths2[3] == healths1[3])
                portraits[3].GetComponent<Image>().color = Color.HSVToRGB(.216f, .6f, .48f);


        }

        for (int i = 0; i < healths1.Length; i++)
        {
            healths1[i] = playerHealth[i].health;

            if (healths2[i] > healths1[i])
            {
                print("okop");
                portraits[i].GetComponent<Image>().color = Color.red;
                healths2[i] = healths1[i];
            }
        }
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
