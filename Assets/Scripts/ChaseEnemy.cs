using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;
public class CostamerController : MonoBehaviour
{
   
    public GameObject ObjTarget;
     CharacterController con;
    public Animator anim;
    private NavMeshAgent Agent;
    Vector3 Startpos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        con = GetComponent<CharacterController>();
        Startpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (ObjTarget)
        {
            Agent.destination = ObjTarget.transform.position;
        }
    }
}
