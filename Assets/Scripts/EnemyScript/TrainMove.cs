using System.Data;
using UnityEngine;
using UnityEngine.Pool;
using Unity.VisualScripting;

public class TrainMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private Rigidbody rb;
    private float moveTrain = 2.0f;
    private float MaxSpeed = 10.0f;
    [SerializeField] private GameObject TrainPool;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        Debug.Log("“dŽÔ‚ª“®‚¢‚Ä‚¢‚é");
        FixedUpdate();
    }
    private void FixedUpdate()
    {
        // ForceMode.Acceleration
        rb.AddForce(transform.forward * moveTrain);
        if (rb.angularVelocity.magnitude > MaxSpeed)
        {
            rb.angularVelocity = Vector3.ClampMagnitude(rb.angularVelocity, MaxSpeed);
        }
      

    }



}