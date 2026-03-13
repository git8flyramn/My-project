using System.Data;
using UnityEngine;
using UnityEngine.Pool;
using Unity.VisualScripting;
using System.Collections;
using System.Collections.Generic;
public class TrainMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private Rigidbody rb;
    
  //  private float moveTrain = 3.0f;
    private float MoveSpeed = 5.0f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        FixedUpdate();
    }
    private void FixedUpdate()
    {

        rb.AddForce(Vector3.forward * MoveSpeed, ForceMode.Acceleration);


    }



}