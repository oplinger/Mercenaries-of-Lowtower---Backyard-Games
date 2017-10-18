using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerThing : MonoBehaviour {
    public int[] deathcount;
    public Collider[] targets;
    public Collider[] IDs;
    public List<GameObject> Player;
    public List<int> PID;
    public MeleeController meleecontroller;
    public TankController tankcontroller;
    public HealerController healercontroller;
    public RangedController rangedcontroller;




    //    Movement move;
    //    HealthScript health;
    //    MeleeAttack melee;
    //    Attraction attractBeam;
    //    public GameObject[] prefabs;

    //    public float no = 19;
    private void Awake()
      {
        IDs = new Collider[4];

        FindTarget();
        deathcount = new int[4];
        // AssignIDsToArray();
        for(int i=0; i<4; i++)
        {
            Player.Add(null);
            PID.Add(9);
        }



    }
    //    //public void CastJumpRay(Vector3 origin, Vector3 direction, GameObject actor)
    //    //{
    //    //    move = actor.GetComponent<Movement>();
    //    //    RaycastHit hit;
    //    //    Ray ray = new Ray(origin, direction);
    //    //    if (Physics.Raycast(ray, out hit))
    //    //    {
    //    //        Vector3 incomingVec = hit.point - origin;
    //    //        Vector3 reflectVec = Vector3.Reflect(incomingVec, hit.normal);

    //    //        move.SetDirection(reflectVec);

    //    //        print(reflectVec);
    //    //    }
    //    //}
    //    public void ModifyHealth(int modifier, GameObject target)
    //    {

    //        health = target.GetComponent<HealthScript>();
    //        health.ChangeHealth(modifier);

    //    }

    //    //public void CastAttackRay(Vector3 origin, Vector3 direction, int damage, float range, string indicator)
    //    //{
    //    //    if (indicator == "Attack")
    //    //    {
    //    //        GameObject target;
    //    //        RaycastHit hit;
    //    //        Ray ray = new Ray(origin, direction);
    //    //        if (Physics.Raycast(ray, out hit, range))
    //    //        {
    //    //            target = hit.collider.gameObject;
    //    //            ModifyHealth(damage, target);

    //    //        }
    //    //    }
    //    //}
    //    public void SpawnRope(GameObject rope, Vector3 hit)
    //    {
    //        GameObject clone;
    //        clone = Instantiate(rope, hit, Quaternion.identity);
    //    }
    //    //public void CastRopeRay (Vector3 origin, Vector3 direction, float range)
    //    //{
    //    //    Debug.DrawRay(origin, direction*range, Color.white, 3);
    //    //    RaycastHit hit;
    //    //    Ray ray = new Ray(origin, direction);
    //    //    f (Physics.Raycast(ray, out hit, range))
    //    //    {
    //    //        SpawnRope(prefabs[1], hit.point);
    //    //    }
    //    //}
    //    //public void CastAttractRay(GameObject origin, Vector3 direction, float range)
    //    //{
    //    //    GameObject target;
    //    //    RaycastHit hit;
    //    //    Ray ray = new Ray(origin.transform.position, direction);
    //    //    if (Physics.Raycast(ray, out hit, range))
    //    //    {
    //    //        attractBeam = origin.GetComponent<Attraction>();
    //    //        target = hit.collider.gameObject;
    //    //        attractBeam.Attract(target, 5*Time.deltaTime);


    //    //    }
    //    //}
    //    public void CastRay(GameObject origin, Vector3 direction, int damage, float range, string indicator)
    //    {
    //        if (indicator == "Attack")
    //        {
    //            GameObject target;
    //            RaycastHit hit;
    //            Ray ray = new Ray(origin.transform.position, direction);
    //            if (Physics.Raycast(ray, out hit, range))
    //            {
    //                target = hit.collider.gameObject;
    //                ModifyHealth(damage, target);

    //            }
    //        }
    //        if (indicator == "Attract")
    //        {
    //            GameObject target;
    //            RaycastHit hit;
    //            Ray ray = new Ray(origin.transform.position, direction);
    //            if (Physics.Raycast(ray, out hit, range))
    //            {
    //                attractBeam = origin.GetComponent<Attraction>();
    //                target = hit.collider.gameObject;
    //                attractBeam.Attract(target, 5 * Time.deltaTime);


    //            }
    //        }
    //        if (indicator == "Rope")
    //        {
    //            Debug.DrawRay(origin.transform.position, direction * range, Color.white, 3);
    //            RaycastHit hit;
    //            Ray ray = new Ray(origin.transform.position, direction);
    //            if (Physics.Raycast(ray, out hit, range))
    //            {
    //                SpawnRope(prefabs[1], hit.point);
    //            }
    //        }
    //        if (indicator == "Jump")
    //        {
    //            move = origin.GetComponent<Movement>();
    //            RaycastHit hit;
    //            Ray ray = new Ray(origin.transform.position, direction);
    //            if (Physics.Raycast(ray, out hit))
    //            {
    //                Vector3 incomingVec = hit.point - origin.transform.position;
    //                Vector3 reflectVec = Vector3.Reflect(incomingVec, hit.normal);

    //                move.SetDirection(reflectVec);

    //                print(reflectVec);
    //            }
    //        }
    //    }
    private void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            RestartLevel();
        }

        for(int i=0; i < deathcount.Length; i++)
        {
            if(deathcount[0] == 1 && deathcount[1] == 1 && deathcount[2] == 1 && deathcount[3] == 1)
             {
            RestartLevel();
              }
        }

        if(/*Input.GetKeyDown("joystick 1 button 7")*/ PID.Contains(1))
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
                        tankcontroller = GameObject.Find("Tank Character").GetComponent<TankController>();
                        tankcontroller.CTRLID = 1;
                    }
                }
                else if (Input.GetKeyDown("joystick " + PID[PID.IndexOf(1)] + " button 1"))
                {
                    if (!Player.Contains(IDs[1].gameObject))
                    {
                        Player.Insert(PID.IndexOf(1), IDs[1].gameObject);
                        // Player.RemoveAt(Player.Count - 1);
                        Player.Remove(null);
                        healercontroller = GameObject.Find("Healer Character").GetComponent<HealerController>();
                        healercontroller.CTRLID = 1;
                    }
                }
                else if (Input.GetKeyDown("joystick " + PID[PID.IndexOf(1)] + " button 2"))
                {
                    if (!Player.Contains(IDs[2].gameObject))
                    {
                        Player.Insert(PID.IndexOf(1), IDs[2].gameObject);
                        // Player.RemoveAt(Player.Count - 1);
                        Player.Remove(null);
                        meleecontroller = GameObject.Find("Melee Character").GetComponent<MeleeController>();
                        meleecontroller.CTRLID = 1;
                    }
                }
                else if (Input.GetKeyDown("joystick " + PID[PID.IndexOf(1)] + " button 3"))
                {
                    if (!Player.Contains(IDs[3].gameObject))
                    {
                        Player.Insert(PID.IndexOf(1), IDs[3].gameObject);
                        // Player.RemoveAt(Player.Count - 1);
                        Player.Remove(null);
                        rangedcontroller = GameObject.Find("Ranged Character").GetComponent<RangedController>();
                        rangedcontroller.CTRLID = 1;
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
                        tankcontroller = GameObject.Find("Tank Character").GetComponent<TankController>();
                        tankcontroller.CTRLID = 2;
                    }
                }
                else if (Input.GetKeyDown("joystick " + PID[PID.IndexOf(2)] + " button 1"))
                {
                    if (!Player.Contains(IDs[1].gameObject))
                    {
                        Player.Insert(PID.IndexOf(2), IDs[1].gameObject);
                        // Player.RemoveAt(Player.Count - 1);
                        Player.Remove(null);
                        healercontroller = GameObject.Find("Healer Character").GetComponent<HealerController>();
                        healercontroller.CTRLID = 2;
                    }
                }
                else if (Input.GetKeyDown("joystick " + PID[PID.IndexOf(2)] + " button 2"))
                {
                    if (!Player.Contains(IDs[2].gameObject))
                    {
                        Player.Insert(PID.IndexOf(2), IDs[2].gameObject);
                        // Player.RemoveAt(Player.Count - 1);
                        Player.Remove(null);
                        meleecontroller = GameObject.Find("Melee Character").GetComponent<MeleeController>();
                        meleecontroller.CTRLID = 2;
                    }
                }
                else if (Input.GetKeyDown("joystick " + PID[PID.IndexOf(2)] + " button 3"))
                {
                    if (!Player.Contains(IDs[3].gameObject))
                    {
                        Player.Insert(PID.IndexOf(2), IDs[3].gameObject);
                        // Player.RemoveAt(Player.Count - 1);
                        Player.Remove(null);
                        rangedcontroller = GameObject.Find("Ranged Character").GetComponent<RangedController>();
                        rangedcontroller.CTRLID = 2;
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
                        tankcontroller = GameObject.Find("Tank Character").GetComponent<TankController>();
                        tankcontroller.CTRLID = 3;

                    }
                }
                else if (Input.GetKeyDown("joystick " + PID[PID.IndexOf(3)] + " button 1"))
                {
                    if (!Player.Contains(IDs[1].gameObject))
                    {
                        Player.Insert(PID.IndexOf(3), IDs[1].gameObject);
                        // Player.RemoveAt(Player.Count - 1);
                        Player.Remove(null);
                        healercontroller = GameObject.Find("Healer Character").GetComponent<HealerController>();
                        healercontroller.CTRLID = 3;
                    }
                }
                else if (Input.GetKeyDown("joystick " + PID[PID.IndexOf(3)] + " button 2"))
                {
                    if (!Player.Contains(IDs[2].gameObject))
                    {
                        Player.Insert(PID.IndexOf(3), IDs[2].gameObject);
                        // Player.RemoveAt(Player.Count - 1);
                        Player.Remove(null);
                        meleecontroller = GameObject.Find("Melee Character").GetComponent<MeleeController>();
                        meleecontroller.CTRLID = 3;
                    }
                }
                else if (Input.GetKeyDown("joystick " + PID[PID.IndexOf(3)] + " button 3"))
                {
                    if (!Player.Contains(IDs[3].gameObject))
                    {
                        Player.Insert(PID.IndexOf(3), IDs[3].gameObject);
                        // Player.RemoveAt(Player.Count - 1);
                        Player.Remove(null);
                        rangedcontroller = GameObject.Find("Ranged Character").GetComponent<RangedController>();
                        rangedcontroller.CTRLID = 3;
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
                        tankcontroller = GameObject.Find("Tank Character").GetComponent<TankController>();
                        tankcontroller.CTRLID = 4;
                    }
                }
                else if (Input.GetKeyDown("joystick " + PID[PID.IndexOf(4)] + " button 1"))
                {
                    if (!Player.Contains(IDs[1].gameObject))
                    {
                        Player.Insert(PID.IndexOf(4), IDs[1].gameObject);
                        // Player.RemoveAt(Player.Count - 1);
                        Player.Remove(null);
                        healercontroller = GameObject.Find("Healer Character").GetComponent<HealerController>();
                        healercontroller.CTRLID = 4;
                    }
                }
                else if (Input.GetKeyDown("joystick " + PID[PID.IndexOf(4)] + " button 2"))
                {
                    if (!Player.Contains(IDs[2].gameObject))
                    {
                        Player.Insert(PID.IndexOf(4), IDs[2].gameObject);
                        // Player.RemoveAt(Player.Count - 1);
                        Player.Remove(null);
                        meleecontroller = GameObject.Find("Melee Character").GetComponent<MeleeController>();
                        meleecontroller.CTRLID = 4;
                    }
                }
                else if (Input.GetKeyDown("joystick " + PID[PID.IndexOf(4)] + " button 3"))
                {
                    if (!Player.Contains(IDs[3].gameObject))
                    {
                        Player.Insert(PID.IndexOf(4), IDs[3].gameObject);
                        // Player.RemoveAt(Player.Count - 1);
                        Player.Remove(null);
                        rangedcontroller = GameObject.Find("Ranged Character").GetComponent<RangedController>();
                        rangedcontroller.CTRLID = 4;
                    }
                }
                else
                {
                }
            }
        }


    }
    public void RestartLevel()
    {
        SceneManager.LoadScene("Prototype Level", LoadSceneMode.Single);
    }
    public void DeathCount( int deaths, int playerID)
    {
        deathcount[playerID] = deaths;
    }
    void FindTarget()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 100, 1 << 8, QueryTriggerInteraction.Ignore);
        targets = hitColliders;
        sendIDs();
    }
    public void sendIDs()
    {
        for (int i = 0; i < targets.Length; i++)
        {
            GameObject currentTar = targets[i].gameObject;
           PlayerID ID = currentTar.GetComponent<PlayerID>();
            //ID.assignSlot(i);
            if (targets[i].gameObject.name == "Tank Character")
            {
                ID.assignID(0);
                IDs[0] = targets[i];
            }
            else if (targets[i].gameObject.name == "Melee Character")
            {
                ID.assignID(2);
                IDs[2] = targets[i];

            }
            else if (targets[i].gameObject.name == "Healer Character")
            {
                ID.assignID(1);
                IDs[1] = targets[i];

            }
            else if (targets[i].gameObject.name == "Ranged Character")
            {
                ID.assignID(3);
                IDs[3] = targets[i];

            }
        }
        //AssignIDsToArray();

    }
    public void AssignIDsToArray(int ID)
    {
        //targets = IDs;
        for ( int i=0; i<4; i++)
        {
            if (PID[i] == ID)
            {
                break;
            }
            if (PID[i] == 9 )
            {
                PID.Insert(i, ID);
                PID.RemoveAt(PID.Count - 1);

                break;
            }
        }
        //PID.Add(ID);
    }
}