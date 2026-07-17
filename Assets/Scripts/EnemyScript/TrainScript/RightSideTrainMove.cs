using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class RightSideTrainMove : MonoBehaviour
{
    
    private Rigidbody rb;
    private GameObject Player;

    //必要なインスタンスの宣言
    private BothTrainMove BothTrain;
    private SEManeger SE;
    public AudioClip clip;

   
    void Start()
    {
        rb        = GetComponent<Rigidbody>();
        BothTrain = GetComponent<BothTrainMove>();
        SE        = GetComponent<SEManeger>();
        Player = GameObject.Find("Player");
    }
    void Update()
    {
        BothTrain.TrainMove();
    }


    //Playerがぶつかった時にSEを鳴らす機能
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            SE.TrainAccident(clip);
            Player.GetComponent<StickController>().PlayerDeath();
        }

    }

   
}
