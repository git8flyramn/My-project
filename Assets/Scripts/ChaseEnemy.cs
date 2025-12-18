using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;
public class CostamerController : MonoBehaviour
{
   
    public GameObject ObjTarget; //’N‚ð’Ç‚¢‚©‚¯‚é‚©
     CharacterController con;
    public Animator anim;
    private NavMeshAgent Agent;
    private float Distance;
    bool IsRun;
    Vector3 Startpos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        con = GetComponent<CharacterController>();
        ObjTarget = GameObject.Find("Player");
        Startpos = transform.position;
        IsRun = false;
    }

    // Update is called once per frame
    void Update()
    {
        Distance = Vector3.Distance(transform.position, ObjTarget.transform.position);
        Debug.Log(Distance);
        if(Distance < 10)
        {
            IsRun = true;
            Agent.destination = ObjTarget.transform.position;
            anim.SetBool("IsRun", IsRun);
        }
        else
        {
            IsRun = false;
        }
    }
}
