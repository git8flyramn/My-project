using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.SceneManagement;
public class TrainManeger : MonoBehaviour
{

    public GameObject FrontTraint;
    //電車の生成位置
    [SerializeField] private Transform Trainspawn;
    [SerializeField] private Transform SecondTrainspawn;

    //オブジェクトプールの取得
    private PooledObject Train;
    private PooledObject SecondTrain;
    [SerializeField] private ObjectPool Pool;
    private SEManeger SE;
    public AudioClip clip;
    private float TrainInterval = 3.0f;
    private float TrainGenerateTime = 0.0f;
    private float SecondTrainGenerateTime = 0.0f;

    void Start()
    {
        TrainGenerateTime += Time.deltaTime;
        SecondTrainGenerateTime += Time.deltaTime;
        SE    = GetComponent<SEManeger>();
        Pool = GetComponent<ObjectPool>();
    }

    void Update()
    {
        TrainGenerate();
    }

    void TrainGenerate()
    {
        //objecPoolから取得する
        Train = Pool.GetPooledObject();
        if (TrainGenerateTime >= TrainInterval)
        {
            TrainSetting(Train, Trainspawn, TrainGenerateTime);
            Debug.Log("電車が生成されました");
        }

        if (SecondTrainGenerateTime >= TrainInterval)
        {
            TrainSetting(Train, SecondTrainspawn, SecondTrainGenerateTime);
            Debug.Log("2つ目の電車が生成されました");
            StartCorutine(TrainReturn(Train));
        }
    }

    public void TrainSetting(PooledObject obj,Transform trans,float time)
    {
        obj.transform.position = trans.position;
        time = 0.0f;
    }

    IEnumerator TrainReturn(PooledObject pooledobject)
    {
        yield return new WaitForSeconds(TrainInterval);
        if (Pool != null)
        {
            Pool.ReturnToPool(pooledobject);
        }

    }

}


