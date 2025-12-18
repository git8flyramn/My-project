using System.Data;
using UnityEngine;


public class TrainMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private Rigidbody rb;
    private float moveTrain = 5.0f;
    private float MaxSpeed = 20.0f;
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
        rb.AddForce(transform.forward * moveTrain, ForceMode.Acceleration);
        if(rb.angularVelocity.magnitude > MaxSpeed)
        {
            rb.angularVelocity = Vector3.ClampMagnitude(rb.angularVelocity, MaxSpeed);
        }
    }



}