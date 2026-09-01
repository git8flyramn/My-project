using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Pool;
public class TrainManeger : MonoBehaviour
{

    //生成するオブジェクトの定義
    public GameObject FrontTrain;
    public GameObject SecondTrain;
    //電車の生成位置
    [SerializeField] private Transform Trainspawn;
    [SerializeField] private Transform SecondTrainspawn;
    [SerializeField] ObjectPool.PoolType poolType;
    //private bool isReturn = false;


    //電車の生成時間と生成間隔
    private float TrainInterval = 5.0f;
    private float SecondTrainInterval = 7.0f;

    private float TrainGenerateTime = 0.0f;
    private float SecondTrainGenerateTime = 0.0f;

    //電車の返却時間と間隔
    private float ReturnTrainTime = 0.0f;
    private float ReturnTrainInverval = 10.0f;

    void Start()
    {
        
    }

    void Update()
    {
        TrainGenerateTime += Time.deltaTime;
        ReturnTrainTime += Time.deltaTime;
        SecondTrainGenerateTime += Time.deltaTime;
        TrainGenerate();
    }

    //電車の生成
    void TrainGenerate()
    {
        
        if (TrainGenerateTime >= TrainInterval)
        {

            ObjectPool.instance.OnGet(poolType);
            FrontTrain.transform.position = Trainspawn.position;
            TrainGenerateTime = 0.0f;
        }

        if (SecondTrainGenerateTime >= SecondTrainInterval)
        {
            ObjectPool.instance.OnGet(poolType);
            FrontTrain.transform.position = SecondTrainspawn.position;
            SecondTrainGenerateTime = 0.0f;
        }


        //電車を返却するまでの時間
        if (ReturnTrainTime > ReturnTrainInverval)
        {
            ObjectPool.instance.ReturnToPool(FrontTrain, poolType);
            ReturnTrainTime = 0.0f;
        }
    }

   
}