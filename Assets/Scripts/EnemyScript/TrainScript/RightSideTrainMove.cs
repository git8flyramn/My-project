using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class RightSideTrainMove : MonoBehaviour
{
    private Rigidbody rb;
    private BothTrainMove BothTrain;
    private SEManeger SE;
    public AudioClip clip;
    private float SeceneChangeTIme = 0.5f;
    private GameObject Player;
    void Start()
    {
        rb        = GetComponent<Rigidbody>();
        BothTrain = GetComponent<BothTrainMove>();
        SE        = GetComponent<SEManeger>();
        Player = GameObject.Find("Player");
    }

// Update is called once per frame
    void Update()
    {
        BothTrain.TrainMove();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            SE.TrainAccident(clip);
            Debug.Log("右の電車とplayerとぶつかった音を再生します");
            Player.GetComponent<StickController>().PlayerDeath();
        }

    }

   
}
