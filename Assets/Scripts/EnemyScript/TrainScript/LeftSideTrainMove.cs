using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class LeftSideTrainMove : MonoBehaviour
{
    

    private Rigidbody rb;
    private BothTrainMove BothTrain;
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
        BothTrain = GetComponent<BothTrainMove>();
        SE = GetComponent<SEManeger>();
        Player = GameObject.Find("Player");
    }

    private void FixedUpdate()
    {
        BothTrain.TrainMove();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            SE.TrainAccident(clip);
            Player.GetComponent<StickController>().PlayerDeath();
        }
    }
}
