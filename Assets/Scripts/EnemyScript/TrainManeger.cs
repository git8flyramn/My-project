using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Pool;
public class TrainManeger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    
    public GameObject Train;
    public Transform TrainPlace;
    [SerializeField] private GameObject TrainPool;
    private float TimeCount =  0.0f;
    private float GenerateTime = 10.0f;
    //Disappear
    private float DisappearPosition = -10.0f;
    void Start()
    { 

    }

    // Update is called once per frame
    void Update()
    {
        TrainMove();
    }

    public void TrainMove()
    {
        GameObject train = TrainPool.GetComponent<ObjectPool>().Get();
        TimeCount += Time.deltaTime;
        if (TimeCount > GenerateTime)
        {
            //Debug.Log(Train == null ? "currentTrain is NULL" : "currentTrain OK");            
            if(train == null)
            {
                Debug.LogWarning("プールから取得したtrainがnullです");
            }
            train.transform.position = TrainPlace.position;
            train.transform.rotation = Quaternion.identity;
          //  Debug.Log("電車が生成されました");
            GenerateTime = 0;
        }

        if(train.transform.position .z < DisappearPosition)
        {
            TrainPool.GetComponent<ObjectPool>().Release(train);
            Debug.Log("電車が消滅します");
        }

    }

}
