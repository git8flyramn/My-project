using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.Pool;
public class TrainManeger : MonoBehaviour
{

    //生成するオブジェクトの定義
    public GameObject FrontTrain;
    public GameObject OtherFrontTrain;
    //電車の生成位置
    [SerializeField] private Transform LeftTrainSpawn;
    [SerializeField] private Transform RightTrainSpawn;
    [SerializeField] ObjectPool.PoolType poolType;
    [SerializeField] ObjectPool.PoolType OtherpoolType;
    //電車の生成時間と生成間隔
    private float TrainInterval = 9.5f;
    private float SecondTrainInterval = 6.0f;

    private float TrainGenerateTime = 0.0f;
    private float SecondTrainGenerateTime = 0.0f;

   



   
    void Update()
    {
        TrainGenerateTime       += Time.deltaTime;
        SecondTrainGenerateTime += Time.deltaTime;
      
        TrainGenerate();
    }

    //前方方向からの電車生成
    void TrainGenerate()
    {

        if (TrainGenerateTime > TrainInterval)
        {
            SpawnTrain(LeftTrainSpawn);
            ObjectPool.instance.OnGet(poolType);
            TrainGenerateTime = 0.0f;
        }

        if (SecondTrainGenerateTime > SecondTrainInterval)
        {
             SpawnTrain(RightTrainSpawn);
            ObjectPool.instance.OnGet(OtherpoolType);
            SecondTrainGenerateTime = 0.0f;
        }
    }

      void SpawnTrain(Transform trans)
      {
        gameObject.transform.position = trans.position;
      }

     

}