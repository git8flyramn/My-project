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
    private PooledObject Train;
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

    void Initialize()
    {
        Pool = GameObject.Find("TrainManeger");
    }



    //電車の生成
    void TrainGenerate()
    {

        if (TrainGenerateTime >= TrainInterval)
        {
            ObjectPool.instance.OnGet(ObjectPool.PoolType.LeftForwardTrain);
            SpawnTrain(Trainspawn);
            TrainGenerateTime = 0.0f;
        }

        if (SecondTrainGenerateTime >= SecondTrainInterval)
        {
            ObjectPool.instance.OnGet(ObjectPool.PoolType.RightForwardTrain);
            SpawnTrain(SecondTrainspawn);
            SecondTrainGenerateTime = 0.0f;
        }

        //電車を返却するまでの時間
        if (ReturnTrainTime > ReturnTrainInverval)
        {
            CallPoolReturn();
        }


    }

    public void SpawnTrain(Transform transform)
    {
       
        if (Train != null)
        {
            Train.transform.position = transform.position;
        }
    }
    

    IEnumerator TrainReturn(PooledObject pooledobject)
    {
        yield return new WaitForSeconds(TrainInterval);
        if (Pool != null)
        {
            ObjectPool.instance.ReturnToPool(poolType, pooledobject);
            ReturnTrainTime = 0.0f;
        }

    }

    public void CallPoolReturn()
    {
        StartCoroutine(TrainReturn(Train));
    }

}