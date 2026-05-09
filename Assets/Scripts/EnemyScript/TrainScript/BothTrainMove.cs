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
    Vector3 Train = Vector3.zero;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       
      
    }

    public void RightTrainMove()
    {

        Train = Vector3.right;
        rb.AddForce(Train * Initvelocity * MoveSpeed, ForceMode.Acceleration);
        Debug.Log("ê≥èÌÇ…çÏìÆ");
    }

    public void TrainLeftMove()
    {
        Train = Vector3.left;
        Debug.Log("ç∂ë§ÇÃìÆÇ´ê≥èÌÇ…çÏìÆ");
        rb.AddForce(Train * Initvelocity * MoveSpeed, ForceMode.Acceleration);
    }


}
