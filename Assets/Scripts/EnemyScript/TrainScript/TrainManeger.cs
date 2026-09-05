using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;
public class TrainManeger : MonoBehaviour
{

    //生成するオブジェクトの定義
    public GameObject FrontTrain;
    //電車の生成位置
    [SerializeField] private Transform LeftTrainSpawn;
    [SerializeField] private Transform RightTrainSpawn;

    private PooledObject pooledobject;

    [SerializeField] ObjectPool.PoolType poolType;

    //電車の生成時間と生成間隔
    private float TrainInterval = 5.0f;
    private float SecondTrainInterval = 8.0f;

    private float TrainGenerateTime = 0.0f;
    private float SecondTrainGenerateTime = 0.0f;

    //電車の返却時間と間隔
    private float ReturnTrainTime = 0.0f;
    private float ReturnTrainInverval = 10.0f;

   

   

    void Update()
    {
        TrainGenerateTime += Time.deltaTime;
        SecondTrainGenerateTime += Time.deltaTime;
        ReturnTrainTime += Time.deltaTime;
       
        if (ReturnTrainTime > ReturnTrainInverval)
        {
            //Debug.Log("返却対象: " + FrontTrain);
            //Debug.Log("activeSelf: " + FrontTrain.activeSelf);
            StartCoroutine(TrainReturn());
            ReturnTrainTime = 0.0f;

        }
            TrainGenerate();
    }

    //電車の生成
    void TrainGenerate()
    {

        if (TrainGenerateTime > TrainInterval)
        {
             SpawnTrain(LeftTrainSpawn);
            TrainGenerateTime = 0.0f;
        }

        if (SecondTrainGenerateTime > SecondTrainInterval)
        {
            SpawnTrain(RightTrainSpawn);
            SecondTrainGenerateTime = 0.0f;
        }
    }

     public void SpawnTrain(Transform transform)
    {
           ObjectPool.instance.GetPooledObject(FrontTrain);
            ObjectPool.instance.OnGet(poolType);
           FrontTrain.transform.position = transform.position;
        
     }   

    IEnumerator TrainReturn()
    {
        yield return new WaitForSeconds(3.0f);
        ObjectPool.instance.ReturnToPool(FrontTrain, poolType);
    }
}