using UnityEngine;
using Unity.VisualScripting;
using System.Collections;
using System.Collections.Generic;
using System.Data;

public class BothTrainMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private TrainMove trainMove;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        trainMove = GetComponent<TrainMove>();
    }

    // Update is called once per frame
    void Update()
    {
        trainMove.TrainRightMove();
    }
}
