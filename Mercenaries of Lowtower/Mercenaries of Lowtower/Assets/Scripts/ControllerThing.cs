using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerThing : MonoBehaviour {

//    Movement move;
//    HealthScript health;
//    MeleeAttack melee;
//    Attraction attractBeam;
//    public GameObject[] prefabs;

//    public float no = 19;
//    private void Start()
//    {

//    }
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
}