using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;
public class CostamerController : MonoBehaviour
{
   
    public GameObject ObjTarget;
    private NavMeshAgent Agent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
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
