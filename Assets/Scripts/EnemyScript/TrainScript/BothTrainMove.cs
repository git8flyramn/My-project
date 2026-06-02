using UnityEngine;
using Unity.VisualScripting;
using System.Collections;
using System.Collections.Generic;
using System.Data;

public class BothTrainMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

   
    private Rigidbody rb;
    private float MoveSpeed    = 3.0f;
    private float Initvelocity = 2.0f;
    public Vector3 TrainDir = Vector3.zero;
  
    private float time = 0;
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
        time += Time.deltaTime;
        TrainDir = Vector3.right;
        rb.AddForce(TrainDir * Initvelocity * MoveSpeed, ForceMode.Acceleration);
    }

    public void TrainLeftMove()
    {
        TrainDir = Vector3.left;
       // rb.AddForce(TrainDir * Initvelocity * MoveSpeed, ForceMode.Acceleration);
    }

    public void ChangeTrainDir(Vector3 dir)
    {
        TrainDir = dir;
        rb.AddForce(TrainDir * Initvelocity * MoveSpeed, ForceMode.Acceleration);
    }


}
