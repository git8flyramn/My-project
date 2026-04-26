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
    public RandomDropTrain RandomTrain;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
        rb = GetComponent<Rigidbody>();
        TrainRightMove();
        TrainLeftMove();

    }

    public void TrainRightMove()
    {
        Debug.Log("ê≥èÌÇ…çÏìÆ");
        rb.AddForce(Vector3.right * Initvelocity * MoveSpeed, ForceMode.Acceleration);
    }

    public void TrainLeftMove()
    {
        Debug.Log("ç∂ë§ÇÃìÆÇ´ê≥èÌÇ…çÏìÆ");
        rb.AddForce(Vector3.left * Initvelocity * MoveSpeed, ForceMode.Acceleration);
    }


}
