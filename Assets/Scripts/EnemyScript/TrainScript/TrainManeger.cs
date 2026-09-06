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

    private PooledObject Train;
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

        if (ReturnTrainTime > ReturnTrainInverval)
        {
            StartCoroutine(TrainReturn(FrontTrain));
        }
    }

     public void SpawnTrain(Transform transform)
    {
         ObjectPool.instance.OnGet(poolType);
        if(FrontTrain != null)
        {
            FrontTrain.transform.position = transform.position;
        }
     }   

    IEnumerator TrainReturn(GameObject obj)
    {
        yield return new WaitForSeconds(3.0f);
        if(obj != null)
        {
            ObjectPool.instance.ReturnToPool(obj,poolType);
            ReturnTrainTime = 0.0f;
        }
        
    }
}