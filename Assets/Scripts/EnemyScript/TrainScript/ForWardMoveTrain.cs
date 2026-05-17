using System.Data;
using UnityEngine;
using Unity.VisualScripting;
using System.Collections;
using System.Collections.Generic;
public class ForWardMoveTrain : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    private Rigidbody rb;

    private float MoveSpeed = 3.0f;
    private float Initvelocity = 2.0f;
    private SEManeger SE;
    public AudioClip clip;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
        if (collision.gameObject.name == "Player")
        {
            SE.TrainAccident(clip);
            Debug.Log("Ç‘Ç¬Ç©Ç¡ÇΩâπÇçƒê∂ÇµÇ‹Ç∑");
        }
    }
}
