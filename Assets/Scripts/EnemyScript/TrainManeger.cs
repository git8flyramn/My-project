using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Pool;
using System.Runtime.CompilerServices;
public class TrainManeger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    
    public GameObject Train;
    public Transform TrainPlace;
    [SerializeField] private ObjectPool Pool;
    private float TimeCount =  0.0f;
    private float DestroyTime = 0.0f;
    private float GenerateTime = 10.0f;
    //Disappear
  //  private float DisappearPosition =  -30.0f;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        TrainMove();
    }

     void TrainMove()
    {
        GameObject train = Pool.GetComponent<ObjectPool>().Get();
        TimeCount += Time.deltaTime;
        if (TimeCount > GenerateTime)
        {
            train.transform.position = TrainPlace.position;
            ///Instantiate(Train, TrainPlace.position, Quaternion.identity);
            train.transform.rotation = Quaternion.identity;
            Debug.Log(Train == null ? "currentTrain is NULL" : "currentTrain OK");
            if (train == null)
            {
                Debug.LogWarning("プールから取得したtrainがnullです");
            }
            TimeCount = 0.0f;
            DestroyTime += 0.5f;
            if (DestroyTime > 15.0f)
            {
                Pool.GetComponent<ObjectPool>().Release(train);
                Debug.Log("電車が消滅します");
            }

        }
       
        //train.transform.position = TrainPlace.position;
        /////Instantiate(Train, TrainPlace.position, Quaternion.identity);
        //train.transform.rotation = Quaternion.identity;
        //Debug.Log(Train == null ? "currentTrain is NULL" : "currentTrain OK");
        //if (train == null)
        //{
        //    Debug.LogWarning("プールから取得したtrainがnullです");
        //}


        //train.transform.position = TrainPlace.position;
        //train.transform.rotation = Quaternion.identity;
        //Debug.Log("電車が生成されました");
        //GenerateTime = 0;



    }
  
}


