using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
public class ForWardMoveTrain : MonoBehaviour
{  
    private Rigidbody rb;
    private float MoveSpeed = 3.0f;
    private float Initvelocity = 2.0f;
    private SEManeger SE;
    public AudioClip clip;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        SE = GetComponent<SEManeger>();
    }

    // Update is called once per frame
    void Update()
    {
        TrainForwardMove();
    }

    private void TrainForwardMove()
    {
        rb.AddForce(Vector3.forward * Initvelocity * MoveSpeed, ForceMode.Acceleration);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            SE.TrainAccident(clip); 
        }
    }

  
}
