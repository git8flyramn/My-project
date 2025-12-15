using System.Data;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class TrainMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    float Speed = 1.0f;
    float LimitSpeed = 30.0f;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate()
    {
        Vector3 TrainMove = new Vector3(Input.GetAxis("Horizonal"), 0, 0);
        rb.AddForce(TrainMove, ForceMode.Force);
    }


}