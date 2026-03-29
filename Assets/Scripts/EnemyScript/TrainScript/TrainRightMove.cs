using System.Data;
using UnityEngine;
using Unity.VisualScripting;
using System.Collections;
using System.Collections.Generic;

public class TrainRightMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private Rigidbody rb;

    private float MoveSpeed = 2.0f;
    private float Initvelocity = 2.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        FixUpdate();
    }
    private void FixUpdate()
    {
        rb.AddForce(Vector3.right * Initvelocity * MoveSpeed, ForceMode.Acceleration);
    }
}
