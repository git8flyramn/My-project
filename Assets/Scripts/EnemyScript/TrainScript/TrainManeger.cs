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
    [SerializeField] private Transform Trainspawn;
    [SerializeField] private Transform SecondTrainspawn;
    [SerializeField] ObjectPool.PoolType poolType;
    private PooledObject Train;

    //電車の生成時間と生成間隔
    private float TrainInterval = 3.0f;
    private float SecondTrainInterval = 6.0f;

    private float TrainGenerateTime = 0.0f;
    private float SecondTrainGenerateTime = 0.0f;

    //電車の返却時間と間隔
    private float ReturnTrainTime = 0.0f;
    private float ReturnTrainInverval = 8.0f;

   

   

    void Update()
    {
        TrainGenerateTime += Time.deltaTime;
        ReturnTrainTime += Time.deltaTime;
        SecondTrainGenerateTime += Time.deltaTime;
        if (ReturnTrainTime > ReturnTrainInverval)
        {
            Debug.Log("返却対象: " + FrontTrain);
            Debug.Log("activeSelf: " + FrontTrain.activeSelf);
            ObjectPool.instance.ReturnToPool(FrontTrain, poolType);
            ReturnTrainTime = 0.0f;

        }
            TrainGenerate();
    }

    //電車の生成
    void TrainGenerate()
    {

        if (TrainGenerateTime > TrainInterval)
        {
            FrontTrain = SpawnTrain();
           // ObjectPool.instance.GetPooledObject(FrontTrain);
            FrontTrain.transform.position = Trainspawn.position;
            TrainGenerateTime = 0.0f;
        }

        if (SecondTrainGenerateTime > SecondTrainInterval)
        {
            FrontTrain.transform.position = SecondTrainspawn.position;
            SecondTrainGenerateTime = 0.0f;
        }
    }

     public GameObject  SpawnTrain()
    {
       
        FrontTrain = ObjectPool.instance.OnGet(poolType);
        return FrontTrain;
    }

}