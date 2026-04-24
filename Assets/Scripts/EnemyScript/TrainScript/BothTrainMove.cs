using UnityEngine;
using Unity.VisualScripting;
using System.Collections;
using System.Collections.Generic;
using System.Data;

public class BothTrainMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

   
    private Rigidbody rb;
    private float MoveSpeed    = 2.0f;
    private float Initvelocity = 2.0f;
    private RandomDropTrain ramdomDrop;
    private Vector pos;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        ramdomDrop = GetComponent<RandomDropTrain>();
    }

    // Update is called once per frame
    void Update()
    {
        pos = ramdomDrop.GetDropPos();
        if (pos < 0)
        {
            TrainLeftMove();
        }
        else
        {
            TrainRightMove();
        }

            
    }

    public void TrainRightMove()
    {
        rb.AddForce(Vector3.right * Initvelocity * MoveSpeed, ForceMode.Acceleration);
    }

    public void TrainLeftMove()
    {
        rb.AddForce(Vector3.left * Initvelocity * MoveSpeed, ForceMode.Acceleration);
    }


}
