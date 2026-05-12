using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class RightSideTrainMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private RandomDropTrain DroprTrain;
    private Rigidbody rb;
    private BothTrainMove BothTrain;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        BothTrain = GetComponent<BothTrainMove>();
        DroprTrain = GetComponent<RandomDropTrain>();
    }

// Update is called once per frame
    void Update()
    {
        DroprTrain.DropRightForwardTrain();
        BothTrain.TrainRightMove();
       
    }

}
