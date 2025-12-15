using System.Data;
using UnityEngine;


public class TrainMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created



    float moveSpeed = 0.2f;
    
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(transform.forward * moveSpeed * Time.deltaTime,Space.World);
    }



}