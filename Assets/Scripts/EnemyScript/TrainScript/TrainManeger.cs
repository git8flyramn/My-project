using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.SceneManagement;
public class TrainManeger : MonoBehaviour
{

    //生成するオブジェクトの定義
    public GameObject FrontTrain;
    //電車の生成位置
    [SerializeField] private Transform Trainspawn;
    [SerializeField] private Transform SecondTrainspawn;
   

    //オブジェクトプールの宣言
    [SerializeField] ObjectPool.PoolType poolType;
    [SerializeField] private GameObject Pool;

    //電車の生成時間と生成間隔
    private float TrainInterval = 5.0f;
    private float SecondTrainInterval = 8.0f;

    private float TrainGenerateTime = 0.0f;
    private float SecondTrainGenerateTime = 0.0f;

    //電車の返却時間と間隔
    private float ReturnTrainTime = 0.0f;
    private float ReturnTrainInverval = 9.0f;

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
            SpawnTrain(Trainspawn, ObjectPool.PoolType.ForwardTrain,FrontTrain);
            TrainGenerateTime = 0.0f;
        }

        if (SecondTrainGenerateTime >= SecondTrainInterval)
        {
            SpawnTrain(SecondTrainspawn, ObjectPool.PoolType.ForwardTrain,FrontTrain);
            SecondTrainGenerateTime = 0.0f;
        }

        //電車を返却するまでの時間
        if (ReturnTrainTime > ReturnTrainInverval)
        {
            CallPoolReturn(ObjectPool.PoolType.ForwardTrain,FrontTrain);
        }
    }

    public void SpawnTrain(Transform transform, ObjectPool.PoolType type,GameObject obj)
    {
        ObjectPool.instance.GetPooledObject(obj);
        ObjectPool.instance.GetObjectPosition(transform, obj);
        ObjectPool.instance.OnGet(type);
           
        
    }
    public void CallPoolReturn(ObjectPool.PoolType pooltype, GameObject obj)
    {
        ObjectPool.instance.ReturnToPool(pooltype,obj);
        ReturnTrainTime = 0.0f;

    }

}