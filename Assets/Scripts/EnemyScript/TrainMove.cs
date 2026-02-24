using System.Data;
using UnityEngine;
using UnityEngine.Pool;
using Unity.VisualScripting;

public class TrainMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private Rigidbody rb;
    private float moveTrain = 2.0f;
    private float MaxSpeed = 5.0f;
    [SerializeField] private GameObject TrainPool;
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
       if (rb.angularVelocity.magnitude > MaxSpeed)
       {
                rb.angularVelocity = Vector3.ClampMagnitude(rb.angularVelocity, MaxSpeed);
       }
        
    }

    private void Release()
    {
                                                        //GameObject
        TrainPool.GetComponent<ObjectPool>().Release(this.gameObject);
    }



}