using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.Pool;
public class TrainManeger : MonoBehaviour
{

    //生成するオブジェクトの定義
    public GameObject FrontTrain;
    //電車の生成位置
    [SerializeField] private Transform LeftTrainSpawn;
    [SerializeField] private Transform RightTrainSpawn;
    [SerializeField] ObjectPool.PoolType poolType;
   
    //電車の生成時間と生成間隔
    private float TrainInterval = 6.0f;
    private float SecondTrainInterval = 8.0f;

    private float TrainGenerateTime = 0.0f;
    private float SecondTrainGenerateTime = 0.0f;

   



   
    void Update()
    {
        TrainGenerateTime       += Time.deltaTime;
        SecondTrainGenerateTime += Time.deltaTime;
      
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

      void SpawnTrain(Transform transform)
      { 
         ObjectPool.instance.OnGet(poolType);
      }

     

}