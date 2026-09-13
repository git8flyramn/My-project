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
    [SerializeField] ObjectPool.PoolType TrainType;
    //電車の返却時間と間隔
    private float ReturnTrainInverval = 10.0f;
    private float ReturnTrainTime = 0.0f;

    void Start()
    {
        rb        = GetComponent<Rigidbody>();
        BothTrain = GetComponent<BothTrainMove>();
        SE        = GetComponent<SEManeger>();
        Player = GameObject.Find("Player");
    }
   
    private void FixedUpdate()
    {
        ReturnTrainTime += Time.deltaTime;
        BothTrain.TrainMove();
        if(ReturnTrainTime > ReturnTrainInverval)
        {
            RightTrainReturn();
            ReturnTrainTime = 0.0f;
        }
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

    void RightTrainReturn()
    {
        ObjectPool.instance.ReturnToPool(gameObject,TrainType);
    }

   
}
