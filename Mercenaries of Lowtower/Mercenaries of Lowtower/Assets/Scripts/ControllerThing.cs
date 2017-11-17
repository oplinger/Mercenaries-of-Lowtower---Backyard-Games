using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerThing : MonoBehaviour {
    #region Variables
    public int[] deathcount;
    public Collider[] targets;
    public Collider[] IDs;
    public List<GameObject> Player;
    public List<int> PID;
    public MeleeController meleecontroller;
    public TankController tankcontroller;
    public HealerController healercontroller;
    public RangedController rangedcontroller;

    #endregion
    private void Awake()
      {

        DontDestroyOnLoad(transform.gameObject);
        IDs = new Collider[4];

        //FindTarget();
        deathcount = new int[4];
        // AssignIDsToArray();
        for(int i=0; i<4; i++)
        {
            Player.Add(null);
            PID.Add(9);
        }

        SceneManager.sceneLoaded += OnSceneLoaded;


    }


    private void Update()
    {

        //press q to restart the level
        if (Input.GetKeyDown("q"))
        {
            RestartLevel();
        }
        //if you all die, level restarts
        for (int i = 0; i < deathcount.Length; i++)
        {
            if (deathcount[0] == 1 && deathcount[1] == 1 && deathcount[2] == 1 && deathcount[3] == 1)
            {
                RestartLevel();
            }
        }

        #region PlayerIDStuff
        #region CharacterAssignment

        /*Checks a bunch of arrays that hold IDs and GameObjects to eventually assign an unassigned character to a controller ID, this is the basis of our character selection method.
STEP BY STEP:
-checks if the index contains the player ID given by the Joystick Polling Script
-Checks if that index value is null
-if so it loops through the buttons pressed by the joystick assigned that index value
-if the specified button is pressed, it checks to see if the array contains that character already
-if not, it assigns the character to that controller ID.
 */
        if (/*Input.GetKeyDown("joystick 1 button 7")*/ PID.Contains(1))
        {
            if (Player[PID.IndexOf(1)] == null)
            {
                if (Input.GetKeyDown("joystick " + PID[PID.IndexOf(1)] + " button 0"))
                {
                    if (!Player.Contains(IDs[0].gameObject))
                    {
                        Player.Insert(PID.IndexOf(1), IDs[0].gameObject);
                        // Player.RemoveAt(Player.Count - 1);
                        Player.Remove(null);
                        tankcontroller = GameObject.Find("Tank Character(Clone)").GetComponent<TankController>();
                        tankcontroller.CTRLID = 1;
                        IDs[0].gameObject.transform.position = GameObject.Find("P0Select").transform.position;

                    }
                }
                else if (Input.GetKeyDown("joystick " + PID[PID.IndexOf(1)] + " button 1"))
                {
                    if (!Player.Contains(IDs[1].gameObject))
                    {
                        Player.Insert(PID.IndexOf(1), IDs[1].gameObject);
                        // Player.RemoveAt(Player.Count - 1);
                        Player.Remove(null);
                        healercontroller = GameObject.Find("Healer Character(Clone)").GetComponent<HealerController>();
                        healercontroller.CTRLID = 1;
                        IDs[1].gameObject.transform.position = GameObject.Find("P0Select").transform.position;

                    }
                }
                else if (Input.GetKeyDown("joystick " + PID[PID.IndexOf(1)] + " button 2"))
                {
                    if (!Player.Contains(IDs[2].gameObject))
                    {
                        Player.Insert(PID.IndexOf(1), IDs[2].gameObject);
                        // Player.RemoveAt(Player.Count - 1);
                        Player.Remove(null);
                        meleecontroller = GameObject.Find("Melee Character(Clone)").GetComponent<MeleeController>();
                        meleecontroller.CTRLID = 1;
                        IDs[2].gameObject.transform.position = GameObject.Find("P0Select").transform.position;

                    }
                }
                else if (Input.GetKeyDown("joystick " + PID[PID.IndexOf(1)] + " button 3"))
                {
                    if (!Player.Contains(IDs[3].gameObject))
                    {
                        Player.Insert(PID.IndexOf(1), IDs[3].gameObject);
                        // Player.RemoveAt(Player.Count - 1);
                        Player.Remove(null);
                        rangedcontroller = GameObject.Find("Ranged Character(Clone)").GetComponent<RangedController>();
                        rangedcontroller.CTRLID = 1;
                        IDs[3].gameObject.transform.position = GameObject.Find("P0Select").transform.position;

                    }
                }
                else
                {
                }
            }
        }
        if (/*Input.GetKeyDown("joystick 1 button 7")*/ PID.Contains(2))
        {
            if (Player[PID.IndexOf(2)] == null)
            {
                if (Input.GetKeyDown("joystick " + PID[PID.IndexOf(2)] + " button 0"))
                {
                    if (!Player.Contains(IDs[0].gameObject))
                    {
                        Player.Insert(PID.IndexOf(2), IDs[0].gameObject);
                        // Player.RemoveAt(Player.Count - 1);
                        Player.Remove(null);
                        tankcontroller = GameObject.Find("Tank Character(Clone)").GetComponent<TankController>();
                        tankcontroller.CTRLID = 2;
                        IDs[0].gameObject.transform.position = GameObject.Find("P1Select").transform.position;

                    }
                }
                else if (Input.GetKeyDown("joystick " + PID[PID.IndexOf(2)] + " button 1"))
                {
                    if (!Player.Contains(IDs[1].gameObject))
                    {
                        Player.Insert(PID.IndexOf(2), IDs[1].gameObject);
                        // Player.RemoveAt(Player.Count - 1);
                        Player.Remove(null);
                        healercontroller = GameObject.Find("Healer Character(Clone)").GetComponent<HealerController>();
                        healercontroller.CTRLID = 2;
                        IDs[1].gameObject.transform.position = GameObject.Find("P1Select").transform.position;

                    }
                }
                else if (Input.GetKeyDown("joystick " + PID[PID.IndexOf(2)] + " button 2"))
                {
                    if (!Player.Contains(IDs[2].gameObject))
                    {
                        Player.Insert(PID.IndexOf(2), IDs[2].gameObject);
                        // Player.RemoveAt(Player.Count - 1);
                        Player.Remove(null);
                        meleecontroller = GameObject.Find("Melee Character(Clone)").GetComponent<MeleeController>();
                        meleecontroller.CTRLID = 2;
                        IDs[2].gameObject.transform.position = GameObject.Find("P1Select").transform.position;

                    }
                }
                else if (Input.GetKeyDown("joystick " + PID[PID.IndexOf(2)] + " button 3"))
                {
                    if (!Player.Contains(IDs[3].gameObject))
                    {
                        Player.Insert(PID.IndexOf(2), IDs[3].gameObject);
                        // Player.RemoveAt(Player.Count - 1);
                        Player.Remove(null);
                        rangedcontroller = GameObject.Find("Ranged Character(Clone)").GetComponent<RangedController>();
                        rangedcontroller.CTRLID = 2;
                        IDs[3].gameObject.transform.position = GameObject.Find("P1Select").transform.position;

                    }
                }
                else
                {
                }
            }
        }
        if (/*Input.GetKeyDown("joystick 1 button 7")*/ PID.Contains(3))
        {
            if (Player[PID.IndexOf(3)] == null)
            {
                if (Input.GetKeyDown("joystick " + PID[PID.IndexOf(3)] + " button 0"))
                {
                    if (!Player.Contains(IDs[0].gameObject))
                    {
                        Player.Insert(PID.IndexOf(3), IDs[0].gameObject);
                        // Player.RemoveAt(Player.Count - 1);
                        Player.Remove(null);
                        tankcontroller = GameObject.Find("Tank Character(Clone)").GetComponent<TankController>();
                        tankcontroller.CTRLID = 3;
                        IDs[0].gameObject.transform.position = GameObject.Find("P2Select").transform.position;


                    }
                }
                else if (Input.GetKeyDown("joystick " + PID[PID.IndexOf(3)] + " button 1"))
                {
                    if (!Player.Contains(IDs[1].gameObject))
                    {
                        Player.Insert(PID.IndexOf(3), IDs[1].gameObject);
                        // Player.RemoveAt(Player.Count - 1);
                        Player.Remove(null);
                        healercontroller = GameObject.Find("Healer Character(Clone)").GetComponent<HealerController>();
                        healercontroller.CTRLID = 3;
                        IDs[1].gameObject.transform.position = GameObject.Find("P2Select").transform.position;

                    }
                }
                else if (Input.GetKeyDown("joystick " + PID[PID.IndexOf(3)] + " button 2"))
                {
                    if (!Player.Contains(IDs[2].gameObject))
                    {
                        Player.Insert(PID.IndexOf(3), IDs[2].gameObject);
                        // Player.RemoveAt(Player.Count - 1);
                        Player.Remove(null);
                        meleecontroller = GameObject.Find("Melee Character(Clone)").GetComponent<MeleeController>();
                        meleecontroller.CTRLID = 3;
                        IDs[2].gameObject.transform.position = GameObject.Find("P2Select").transform.position;

                    }
                }
                else if (Input.GetKeyDown("joystick " + PID[PID.IndexOf(3)] + " button 3"))
                {
                    if (!Player.Contains(IDs[3].gameObject))
                    {
                        Player.Insert(PID.IndexOf(3), IDs[3].gameObject);
                        // Player.RemoveAt(Player.Count - 1);
                        Player.Remove(null);
                        rangedcontroller = GameObject.Find("Ranged Character(Clone)").GetComponent<RangedController>();
                        rangedcontroller.CTRLID = 3;
                        IDs[3].gameObject.transform.position = GameObject.Find("P2Select").transform.position;

                    }
                }
                else
                {
                }
            }
        }
        if (/*Input.GetKeyDown("joystick 1 button 7")*/ PID.Contains(4))
        {
            if (Player[PID.IndexOf(4)] == null)
            {
                if (Input.GetKeyDown("joystick " + PID[PID.IndexOf(4)] + " button 0"))
                {
                    if (!Player.Contains(IDs[0].gameObject))
                    {
                        Player.Insert(PID.IndexOf(4), IDs[0].gameObject);
                        // Player.RemoveAt(Player.Count - 1);
                        Player.Remove(null);
                        tankcontroller = GameObject.Find("Tank Character(Clone)").GetComponent<TankController>();
                        tankcontroller.CTRLID = 4;
                        IDs[0].gameObject.transform.position = GameObject.Find("P3Select").transform.position;

                    }
                }
                else if (Input.GetKeyDown("joystick " + PID[PID.IndexOf(4)] + " button 1"))
                {
                    if (!Player.Contains(IDs[1].gameObject))
                    {
                        Player.Insert(PID.IndexOf(4), IDs[1].gameObject);
                        // Player.RemoveAt(Player.Count - 1);
                        Player.Remove(null);
                        healercontroller = GameObject.Find("Healer Character(Clone)").GetComponent<HealerController>();
                        healercontroller.CTRLID = 4;
                        IDs[1].gameObject.transform.position = GameObject.Find("P3Select").transform.position;

                    }
                }
                else if (Input.GetKeyDown("joystick " + PID[PID.IndexOf(4)] + " button 2"))
                {
                    if (!Player.Contains(IDs[2].gameObject))
                    {
                        Player.Insert(PID.IndexOf(4), IDs[2].gameObject);
                        // Player.RemoveAt(Player.Count - 1);
                        Player.Remove(null);
                        meleecontroller = GameObject.Find("Melee Character(Clone)").GetComponent<MeleeController>();
                        meleecontroller.CTRLID = 4;
                        IDs[2].gameObject.transform.position = GameObject.Find("P3Select").transform.position;

                    }
                }
                else if (Input.GetKeyDown("joystick " + PID[PID.IndexOf(4)] + " button 3"))
                {
                    if (!Player.Contains(IDs[3].gameObject))
                    {
                        Player.Insert(PID.IndexOf(4), IDs[3].gameObject);
                        // Player.RemoveAt(Player.Count - 1);
                        Player.Remove(null);
                        rangedcontroller = GameObject.Find("Ranged Character(Clone)").GetComponent<RangedController>();
                        rangedcontroller.CTRLID = 4;
                        IDs[3].gameObject.transform.position = GameObject.Find("P3Select").transform.position;

                    }
                }
                else
                {
                }
            }
        }
    }
    #endregion

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        print("Scene Loaded");

        //Instantiate(Resources.Load("Healer Character"));
        //Instantiate(Resources.Load("Melee Character"));
        //Instantiate(Resources.Load("Tank Character"));
        //Instantiate(Resources.Load("Ranged Character"));

        //System.Array.Clear(targets, 0, targets.Length);
        FindTarget();

        for (int i = 0; i<IDs.Length; i++)
        {
            if(GameObject.Find("P" + i + "Spawn") == null)
            {

            } else
            {
                IDs[i].gameObject.transform.position = GameObject.Find("P" + i + "Spawn").transform.position;
                IDs[i].GetComponent<Health>().health = IDs[i].GetComponent<Health>().maxHealth;

            }
        }

    }

    // Rearranges the Target IDs into a static array, so the characters always have the same ID numbers for use in the threat system. possibly other applications. 
    //IE: Tank will always ALWAYS be 0, healer will ALWAYS be 1, etc
    public void sendIDs()
    {
        for (int i = 0; i < targets.Length; i++)
        {
            GameObject currentTar = targets[i].gameObject;
            PlayerID ID = currentTar.GetComponent<PlayerID>();
            //ID.assignSlot(i);
            if (targets[i].gameObject.name == "Tank Character(Clone)")
            {
                ID.assignID(0);
                IDs[0] = targets[i];
            }
            else if (targets[i].gameObject.name == "Melee Character(Clone)")
            {
                ID.assignID(2);
                IDs[2] = targets[i];

            }
            else if (targets[i].gameObject.name == "Healer Character(Clone)")
            {
                ID.assignID(1);
                IDs[1] = targets[i];

            }
            else if (targets[i].gameObject.name == "Ranged Character(Clone)")
            {
                ID.assignID(3);
                IDs[3] = targets[i];

            }
        }
    }

    //Takes in the controller ID from the polling script, assigns that to the PID array
    // IE: if controller 1 pressed start 3rd, he is player 3.
    public void AssignIDsToArray(int ID)
    {
        //targets = IDs;
        for (int i = 0; i < 4; i++)
        {
            if (PID[i] == ID)
            {
                break;
            }else if (PID[i] == 9)
            {
                PID.Insert(i, ID);
                PID.RemoveAt(PID.Count - 1);

                break;
            }
        }
        //PID.Add(ID);
    }
    #endregion
    
    public void RestartLevel()
    {
        SceneManager.LoadScene("Prototype Level", LoadSceneMode.Single);
    }

    // tracks which player is currently dead
    public void DeathCount( int deaths, int playerID)
    {
        deathcount[playerID] = deaths;
    }

    // finds all players in the level, adds them to an array, and then sends out IDs
    void FindTarget()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 1000, 1 << 8, QueryTriggerInteraction.Ignore);
        targets = hitColliders;
        sendIDs();
       
    }
    
    
}