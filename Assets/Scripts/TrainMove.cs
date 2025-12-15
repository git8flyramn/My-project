using System.Data;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Scripting.APIUpdating;

public class TrainMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    
    float LimitSpeed = 30.0f;
    private Rigidbody rb;
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
       if(rb.angularVelocity.magnitude > LimitSpeed)
        {
            rb.angularVelocity = Vector3.ClampMagnitude(rb.angularVelocity, LimitSpeed);
        }
    }


}