using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class LeftSideTrainMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private Rigidbody rb;
    private BothTrainMove BothTrain;
    private RandomDropTrain DropTrain;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        BothTrain = GetComponent<BothTrainMove>();
        DropTrain = GetComponent<RandomDropTrain>();
    }

    // Update is called once per frame
    void Update()
    {
        BothTrain.TrainLeftMove();
    }
}
