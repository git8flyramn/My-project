using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class TrainLeftMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private TrainMove trainmove;
   void Start()
    {
        trainmove = GetComponent<TrainMove>();
    }

    // Update is called once per frame
    void Update()
    {
        trainmove.TrainLeftMove();
    }
}
