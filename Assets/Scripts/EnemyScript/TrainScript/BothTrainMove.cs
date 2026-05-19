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
    Vector3 TrainDir = Vector3.zero;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void TrainRightMove()
    {

        TrainDir = Vector3.left;
        rb.AddForce(TrainDir * Initvelocity * MoveSpeed, ForceMode.Acceleration);
        Debug.Log("âEë§ê≥èÌÇ…çÏìÆ");
    }

    public void TrainLeftMove()
    {
        TrainDir = Vector3.left;
        Debug.Log("ç∂ë§ê≥èÌÇ…çÏìÆ");
        rb.AddForce(TrainDir * Initvelocity * MoveSpeed, ForceMode.Acceleration);
    }


}
