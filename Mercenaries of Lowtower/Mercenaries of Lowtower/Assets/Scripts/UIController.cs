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
    PlayerControls controller;
    PlayerCDController playerCooldowns;
    public float timer = 600;
    public Text[] texts;
    public Image[] images;
    public List<Image> healthBars;
    public List<Image> icons;
    public List<Image> portraits;

    public GameObject[] healthBarSprites;
    public GameObject[] labels;

    public Camera mainCamera;

    float[] healths1;
    float[] healths2;



   public  float[] playerCurrentHealth;
    public float[] playerMaxHealth;
    public float bossMaxHealth;
    public float bossCurrentHealth;

    // Health bossHealth;
    #endregion

    // Use this for initialization
    void Start()
    {

        controllerThing = GameObject.Find("Controller Thing");
        controller = controllerThing.GetComponent<PlayerControls>();
        //players = new GameObject[4];
        texts = GetComponentsInChildren<Text>();
        images = GetComponentsInChildren<Image>();
        timer = 600;
        //bossHealth = boss.GetComponent<Health>();
        playerCooldowns = controller.GetComponent<PlayerCDController>();
        healths1 = new float[4];

        healths2 = new float[4];

        playerCurrentHealth = new float[4];
        playerMaxHealth = new float[4];
        

        // Assigns players to slots based on IDs, for use with UI placement.
        //IE: Tank is in the top left, always.
        //This might be changed to player positions. So P1 is in the top left, P2 top right, etc
        for (int i = 0; i < controller.PID.Count; i++)
        {

            players[i] = controller.players[i];


            //healths2[i] = playerHealth[i].health;

        }
        playerMaxHealth[0] = controller.players[0].GetComponent<TankClass>().maxHealth;
        playerMaxHealth[1] = controller.players[1].GetComponent<HealerClass>().maxHealth;
        playerMaxHealth[2] = controller.players[2].GetComponent<MeleeClass>().maxHealth;
        playerMaxHealth[3] = controller.players[3].GetComponent<RangedClass>().maxHealth;
        bossMaxHealth = boss.GetComponent<BossClass>().maxHealth;
        

        foreach (Image element in images)
        {
            //print("image found");
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
        playerCurrentHealth[0] = players[0].GetComponent<TankClass>().currentHealth;
        playerCurrentHealth[1] = players[1].GetComponent<HealerClass>().currentHealth;
        playerCurrentHealth[2] = players[2].GetComponent<MeleeClass>().currentHealth;
        playerCurrentHealth[3] = players[3].GetComponent<RangedClass>().currentHealth;
        bossCurrentHealth = boss.GetComponent<BossClass>().currentHealth;

        for (int i = 0; i < labels.Length; i++)
        {
            labels[i].transform.position = Vector3.Lerp(mainCamera.transform.position, players[i].transform.position, .5f);
        }




        //print(playerCurrentHealth[0]);
        //print(playerCurrentHealth[1]);
        //print(playerCurrentHealth[2]);
        //print(playerCurrentHealth[3]);




        #region Timers
        timer -= Time.deltaTime;
        //texts[5].text = timer.ToString();
        //texts[4].text = bossHealth.health.ToString();
        #endregion

        //#region Cooldown Icons

        ////Fades from one textures into another. Visualization of the CD rather than a timer.


        //icons[0].material.SetFloat("_Tween", players[0].GetComponent<TankCooldowns>().cooldowns["magnetCD"] / players[0].GetComponent<TankCooldowns>().magnetCD);
        //icons[0].material.SetTexture("_MainTex", Resources.Load("Textures/Icon_Tank_Grab") as Texture);
        //icons[0].material.SetTexture("_SecondTex", Resources.Load("Textures/Icon_Tank_Grab_2") as Texture);
        //if (icons[0].material.GetFloat("_Tween") <= 0)
        //{
        //    icons[0].rectTransform.localScale = new Vector3(2, 2, 2);
        //}
        //else
        //{
        //    icons[0].rectTransform.localScale = new Vector3(1, 1, 1);

        //}

        //icons[1].material.SetFloat("_Tween", players[0].GetComponent<TankCooldowns>().cooldowns["shieldCD"] / players[0].GetComponent<TankCooldowns>().shieldCD);
        //icons[1].material.SetTexture("_MainTex", Resources.Load("Textures/Icon_Tank_Bubble") as Texture);
        //icons[1].material.SetTexture("_SecondTex", Resources.Load("Textures/Icon_Tank_Bubble_2") as Texture);
        //if (icons[1].material.GetFloat("_Tween") <= 0)
        //{
        //    icons[1].rectTransform.localScale = new Vector3(2, 2, 2);
        //}
        //else
        //{
        //    icons[1].rectTransform.localScale = new Vector3(1, 1, 1);

        //}

        //icons[2].material.SetFloat("_Tween", 0);
        //icons[2].material.SetTexture("_MainTex", Resources.Load("Textures/Icon_Transparent") as Texture);
        //icons[2].material.SetTexture("_SecondTex", Resources.Load("Textures/Icon_Transparent") as Texture);
        //if (icons[2].material.GetFloat("_Tween") <= 0)
        //{
        //    icons[2].rectTransform.localScale = new Vector3(2, 2, 2);
        //}
        //else
        //{
        //    icons[2].rectTransform.localScale = new Vector3(1, 1, 1);

        //}

        ////if (players[0].GetComponent<TankController>().altBuild)
        ////{
        ////    icons[2].enabled = true;
        ////    icons[0].enabled = false;
        ////    if (healths2[0] == healths1[0])
        ////        portraits[0].GetComponent<Image>().color = Color.HSVToRGB(.613f, .537f, .4f);

        ////}
        ////else
        ////{
        ////    icons[0].enabled = true;
        ////    icons[2].enabled = false;
        ////    if (healths2[0] == healths1[0])
        ////        portraits[0].GetComponent<Image>().color = Color.HSVToRGB(.613f, .537f, .82f);


        ////}

        //icons[3].material.SetFloat("_Tween", players[1].GetComponent<HealerCooldowns>().cooldowns["healCD"] / players[1].GetComponent<HealerCooldowns>().healCD);
        //icons[3].material.SetTexture("_MainTex", Resources.Load("Textures/Icon_Healer_Heal") as Texture);
        //icons[3].material.SetTexture("_SecondTex", Resources.Load("Textures/Icon_Healer_Heal_2") as Texture);
        //if (icons[3].material.GetFloat("_Tween") <= 0)
        //{
        //    icons[3].rectTransform.localScale = new Vector3(2, 2, 2);
        //}
        //else
        //{
        //    icons[3].rectTransform.localScale = new Vector3(1, 1, 1);

        //}

        //icons[4].material.SetFloat("_Tween", players[1].GetComponent<HealerCooldowns>().cooldowns["stunCD"] / players[1].GetComponent<HealerCooldowns>().stunCD);
        //icons[4].material.SetTexture("_MainTex", Resources.Load("Textures/Icon_Healer_Stun") as Texture);
        //icons[4].material.SetTexture("_SecondTex", Resources.Load("Textures/Icon_Healer_Stun_2") as Texture);
        //if (icons[4].material.GetFloat("_Tween") <= 0)
        //{
        //    icons[4].rectTransform.localScale = new Vector3(2, 2, 2);
        //}
        //else
        //{
        //    icons[4].rectTransform.localScale = new Vector3(1, 1, 1);

        //}

        //icons[5].material.SetFloat("_Tween", 0);
        //icons[5].material.SetTexture("_MainTex", Resources.Load("Textures/Icon_Transparent") as Texture);
        //icons[5].material.SetTexture("_SecondTex", Resources.Load("Textures/Icon_Transparent") as Texture);
        //if (icons[5].material.GetFloat("_Tween") <= 0)
        //{
        //    icons[5].rectTransform.localScale = new Vector3(2, 2, 2);
        //}
        //else
        //{
        //    icons[5].rectTransform.localScale = new Vector3(1, 1, 1);

        //}

        ////if (players[1].GetComponent<HealerController>().altBuild)
        ////{
        ////    icons[5].enabled = true;
        ////    icons[4].enabled = false;
        ////    if (healths2[1] == healths1[1])
        ////        portraits[1].GetComponent<Image>().color = Color.HSVToRGB(.2f, .89f, .5f);


        ////}
        ////else
        ////{
        ////    icons[4].enabled = true;
        ////    icons[5].enabled = false;
        ////    if (healths2[1] == healths1[1])
        ////        portraits[1].GetComponent<Image>().color = Color.HSVToRGB(.2f, .89f, .95f);


        ////}

        //icons[6].material.SetFloat("_Tween", players[2].GetComponent<MeleeCooldowns>().cooldowns["meleeCD"] / players[2].GetComponent<MeleeCooldowns>().meleeCD);
        //icons[6].material.SetTexture("_MainTex", Resources.Load("Textures/Icon_Melee_Attack") as Texture);
        //icons[6].material.SetTexture("_SecondTex", Resources.Load("Textures/Icon_Melee_Attack_2") as Texture);
        //if (icons[6].material.GetFloat("_Tween") <= 0)
        //{
        //    icons[6].rectTransform.localScale = new Vector3(2, 2, 2);
        //}
        //else
        //{
        //    icons[6].rectTransform.localScale = new Vector3(1, 1, 1);

        //}

        //icons[7].material.SetFloat("_Tween", 0);
        //icons[7].material.SetTexture("_MainTex", Resources.Load("Textures/Icon_Transparent") as Texture);
        //icons[7].material.SetTexture("_SecondTex", Resources.Load("Textures/Icon_Transparent") as Texture);
        //if (icons[7].material.GetFloat("_Tween") <= 0)
        //{
        //    icons[7].rectTransform.localScale = new Vector3(2, 2, 2);
        //}
        //else
        //{
        //    icons[7].rectTransform.localScale = new Vector3(1, 1, 1);

        //}

        //icons[8].material.SetFloat("_Tween", players[2].GetComponent<MeleeCooldowns>().cooldowns["lungeCD"] / players[2].GetComponent<MeleeCooldowns>().lungeCD);
        //icons[8].material.SetTexture("_MainTex", Resources.Load("Textures/Icon_Melee_Dash") as Texture);
        //icons[8].material.SetTexture("_SecondTex", Resources.Load("Textures/Icon_Melee_Dash_2") as Texture);
        //if (icons[8].material.GetFloat("_Tween") <= 0)
        //{
        //    icons[8].rectTransform.localScale = new Vector3(2, 2, 2);
        //}
        //else
        //{
        //    icons[8].rectTransform.localScale = new Vector3(1, 1, 1);

        //}

        ////if (players[2].GetComponent<MeleeController>().altBuild)
        ////{
        ////    icons[8].enabled = true;
        ////    icons[7].enabled = false;
        ////    if (healths2[2] == healths1[2])
        ////        portraits[2].GetComponent<Image>().color = Color.HSVToRGB(.016f, .788f, .5f);


        ////}
        ////else
        ////{
        ////    icons[7].enabled = true;
        ////    icons[8].enabled = false;
        ////    if (healths2[2] == healths1[2])
        ////        portraits[2].GetComponent<Image>().color = Color.HSVToRGB(.016f, .788f, .95f);


        ////}

        //icons[9].material.SetFloat("_Tween", players[3].GetComponent<RangedCooldowns>().cooldowns["boltCD"] / players[3].GetComponent<RangedCooldowns>().boltCD);
        //icons[9].material.SetTexture("_MainTex", Resources.Load("Textures/Icon_Ranger_Bolt") as Texture);
        //icons[9].material.SetTexture("_SecondTex", Resources.Load("Textures/Icon_Ranger_Bolt_2") as Texture);
        //if (icons[9].material.GetFloat("_Tween") <= 0)
        //{
        //    icons[9].rectTransform.localScale = new Vector3(2, 2, 2);
        //}
        //else
        //{
        //    icons[9].rectTransform.localScale = new Vector3(1, 1, 1);

        //}

        //icons[10].material.SetFloat("_Tween", 0);
        //icons[10].material.SetTexture("_MainTex", Resources.Load("Textures/Icon_Transparent") as Texture);
        //icons[10].material.SetTexture("_SecondTex", Resources.Load("Textures/Icon_Transparent") as Texture);
        //if (icons[10].material.GetFloat("_Tween") <= 0)
        //{
        //    icons[10].rectTransform.localScale = new Vector3(2, 2, 2);
        //}
        //else
        //{
        //    icons[10].rectTransform.localScale = new Vector3(1, 1, 1);

        //}

        //icons[11].material.SetFloat("_Tween", players[3].GetComponent<RangedCooldowns>().cooldowns["knockbackCD"] / players[3].GetComponent<RangedCooldowns>().knockbackCD);
        //icons[11].material.SetTexture("_MainTex", Resources.Load("Textures/Icon_Ranger_Knockback") as Texture);
        //icons[11].material.SetTexture("_SecondTex", Resources.Load("Textures/Icon_Ranger_Knockback_2") as Texture);
        //if (icons[11].material.GetFloat("_Tween") <= 0)
        //{
        //    icons[11].rectTransform.localScale = new Vector3(2, 2, 2);
        //}
        //else
        //{
        //    icons[11].rectTransform.localScale = new Vector3(1, 1, 1);

        //}

        ////if (players[3].GetComponent<RangedController>().altBuild)
        ////{
        ////    icons[11].enabled = true;
        ////    icons[10].enabled = false;
        ////    if (healths2[3] == healths1[3])
        ////        portraits[3].GetComponent<Image>().color = Color.HSVToRGB(.216f, .6f, .2f);


        ////}
        ////else
        ////{
        ////    icons[10].enabled = true;
        ////    icons[11].enabled = false;
        ////    if (healths2[3] == healths1[3])
        ////        portraits[3].GetComponent<Image>().color = Color.HSVToRGB(.216f, .6f, .48f);


        ////}

        //#endregion

        #region Health Bars
        //Health bars. Also changes the size of the health bars based on current health vs max health.

        healthBarSprites[0].transform.localScale = new Vector3(200 * (playerCurrentHealth[0] / playerMaxHealth[0]), 20,1);
        healthBarSprites[1].transform.localScale = new Vector3(200 * (playerCurrentHealth[1] / playerMaxHealth[1]), 20, 1);
        healthBarSprites[2].transform.localScale = new Vector3(200 * (playerCurrentHealth[2] / playerMaxHealth[2]), 20, 1);
        healthBarSprites[3].transform.localScale = new Vector3(200 * (playerCurrentHealth[3] / playerMaxHealth[3]), 20, 1);


        //healthBars[0].rectTransform.sizeDelta = new Vector2(100 * (playerCurrentHealth[0] / playerMaxHealth[0]), 20);
        //healthBars[1].rectTransform.sizeDelta = new Vector2(100 * (playerCurrentHealth[1] / playerMaxHealth[1]), 20);
        //healthBars[2].rectTransform.sizeDelta = new Vector2(100 * (playerCurrentHealth[2] / playerMaxHealth[2]), 20);
        //healthBars[3].rectTransform.sizeDelta = new Vector2(100 * (playerCurrentHealth[3] / playerMaxHealth[3]), 20);

        //healthBars[4].rectTransform.sizeDelta = new Vector2(355 * (bossCurrentHealth / bossMaxHealth), 25);

#endregion

        
    }
}
