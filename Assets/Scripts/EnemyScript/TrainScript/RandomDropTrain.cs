using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;
using UnityEngine.Pool;
public class RandomDropTrain : MonoBehaviour
{
    [Header("生成する電車")]
    public GameObject RightSideDropObject;
    public GameObject LeftSideDropObject;
    [SerializeField] ObjectPool.PoolType RightTrainType;
    [SerializeField] ObjectPool.PoolType LeftTrainType;


    public bool IsTrainStart = false;

    private GameObject LeftArrow;
    private GameObject RightArrow;


    [Header("電車生成位置")]
    public Transform RightTrainSpawn_1;
    public Transform RightTrainSpawn_2;
    public Transform LeftTrainSpawn_1;
    public Transform LeftTrainSpawn_2;

   

    [Header("電車生成時間")]
    private float RightTrainGenerateTime = 0.0f;
    private float RightSecondTrainGenerateTime = 0.0f;
    private float LeftTrainGenerateTime = 0.0f;
    private float LeftSecondTrainGenerateTime = 0.0f;

    [Header("電車生成間隔時間")]
    private float RightTrainFirstIntervalTime = 8.0f;
    private float RightTrainSecondIntervalTime = 10.0f;

    private float LeftTrainFirstIntervalTime = 8.0f;
    private float LeftTrainSecondIntervalTime = 10.0f;

    [Header("電車の進行向き")]
    private Quaternion LeftTrainRotaion = Quaternion.Euler(0, 260, 0);
    private Quaternion RightTrainRotaion = Quaternion.Euler(0, 90, 0);

    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        RightArrow = GameObject.Find("RightArrow");
        LeftArrow = GameObject.Find("LeftArrow");
    }

    void FixedUpdate()
    {
        if (IsTrainStart == true)
        {
            DropLeftForwardTrain();
            DropRightForwardTrain();
        }
        else if (IsTrainStart == false)
        {
            return;
        }

       
    }

    //右からの電車生成
    private void DropRightForwardTrain()
    {
       
        RightTrainGenerateTime += Time.deltaTime;
        RightSecondTrainGenerateTime += Time.deltaTime;


        //1枚目の線路
        if (RightTrainGenerateTime > RightTrainFirstIntervalTime)
        {
            RightArrow.GetComponent<ArrowFlashing>().StartBlinking();
            GameObject train = ObjectPool.instance.OnGet(RightTrainType);
            TrainSetting(train, RightTrainRotaion, RightTrainSpawn_1);
            RightTrainGenerateTime = 0.0f;
        }
        //3枚目の線路
        if (RightSecondTrainGenerateTime > RightTrainSecondIntervalTime)
        {
            RightArrow.GetComponent<ArrowFlashing>().StartBlinking();
            GameObject train = ObjectPool.instance.OnGet(RightTrainType);
            TrainSetting(train, RightTrainRotaion, RightTrainSpawn_2);
            RightSecondTrainGenerateTime = 0.0f;
        }
    }

    //右からの電車生成
    private void DropLeftForwardTrain()
    {
     

        LeftTrainGenerateTime += Time.deltaTime;
        LeftSecondTrainGenerateTime += Time.deltaTime;

        ///2枚目の線路からの生成
        if (LeftTrainGenerateTime > LeftTrainFirstIntervalTime)
        {
            LeftArrow.GetComponent<ArrowFlashing>().StartBlinking();
            GameObject train = ObjectPool.instance.OnGet(LeftTrainType);
            TrainSetting(train, LeftTrainRotaion, LeftTrainSpawn_1);
            LeftTrainGenerateTime = 0.0f;
        }
        ///4枚目の線路からの生成
        if (LeftSecondTrainGenerateTime > LeftTrainSecondIntervalTime)
        {
            LeftArrow.GetComponent<ArrowFlashing>().StartBlinking();
            GameObject train = ObjectPool.instance.OnGet(LeftTrainType);
            TrainSetting(train, LeftTrainRotaion, LeftTrainSpawn_2);
            LeftSecondTrainGenerateTime = 0.0f;
        }
    }

    //生成する電車のオブジェクト、座標、向きを設定する関数
    public void TrainSetting(GameObject obj, Quaternion dir, Transform pos)
    {
        obj.transform.position = pos.position;
        obj.transform.rotation = dir;
    }
    public void TrainIsStart()
    {
        IsTrainStart = true;
    }
}