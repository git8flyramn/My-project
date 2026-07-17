using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.SceneManagement;
using UnityEngine.WSA;
public class TrainManeger : MonoBehaviour
{

    //生成するオブジェクトの定義
    public GameObject FrontTraint;
    //電車の生成位置
    [SerializeField] private Transform Trainspawn;
    [SerializeField] private Transform SecondTrainspawn;

    //オブジェクトプールの宣言
    private PooledObject Train;
    [SerializeField] private ObjectPool Pool;

    //電車の生成時間と生成間隔
    private float TrainInterval            = 3.0f;
    private float SecondTrainInterval 　   = 5.0f;
    
    private　float TrainGenerateTime 　　　 = 0.0f;
    private float SecondTrainGenerateTime  =　0.0f;
    
    //電車の返却時間と間隔
    private float ReturnTrainTime          = 0.0f;
    private float ReturnTrainInverval      = 9.0f;

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
            SpawnTrain(Trainspawn);
            TrainGenerateTime = 0.0f;
        }

        if(SecondTrainGenerateTime >= SecondTrainInterval)
        {
            SpawnTrain(SecondTrainspawn);
            SecondTrainGenerateTime = 0.0f;
        }

        //電車を返却するまでの時間
        if(ReturnTrainTime > ReturnTrainInverval)
        {
            StartCoroutine(TrainReturn(Train));
        }

        
    }

    public void SpawnTrain(Transform transform)
    {
        Train = Pool.GetPooledObject();
        if(Train != null)
        {
            Train.transform.position = transform.position;
        }
    }

    IEnumerator TrainReturn(PooledObject pooledobject)
    {
        yield return new WaitForSeconds(TrainInterval);
        if (Pool != null)
        {
            Pool.ReturnToPool(pooledobject);
            ReturnTrainTime = 0.0f;
        }

    }

}


