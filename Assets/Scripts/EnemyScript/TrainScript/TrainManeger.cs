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

     //private float TrainIntervalTime = 3.0f;
    private float TrainGenerateTime = 0.0f;
    private float SecondTrainGenerateTime = 0.0f;

    void Start()
    {
        TrainGenerateTime += Time.deltaTime;
        Train = Pool.GetPooledObject();
        SE    = GetComponent<SEManeger>();
        Pool = GetComponent<ObjectPool>();
    }

    void Update()
    {
        if(TrainGenerateTime > 3.0f)
        {
            Debug.Log("プールから表示されます");
        }
    }
}


