using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
public class ForWardMoveTrain : MonoBehaviour
{  
    private Rigidbody rb;
    private float MoveSpeed = 3.0f;
    private float Initvelocity = 4.0f;
    private SEManeger SE;
    public AudioClip clip;
    private GameObject Player;

    void Start()
    {
        Initialize();
    }


    void Initialize()
    {
        rb = GetComponent<Rigidbody>();
        SE = GetComponent<SEManeger>();
        Player = GameObject.Find("Player");
    }


    void Update()
    {
        TrainForwardMove();
    }

    //ìdé‘ÇÃà⁄ìÆèàóù
    private void TrainForwardMove()
    {
        rb.AddForce(Vector3.forward * Initvelocity * MoveSpeed, ForceMode.Acceleration);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            Player.GetComponent<StickController>().PlayerDeath();
        }
    }

 






}
