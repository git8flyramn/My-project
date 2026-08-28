using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Pool;
public class RandomDropTrain : MonoBehaviour
{
    //生成する電車のモデルを受け取る変数
    public GameObject DropObject;
    public GameObject OtherSideDropObject;
    private string DropTrainName;
    private string DropSideTrainName;
  
    public bool IsTrainStart = false;

    private GameObject LeftArrow;
    private GameObject RightArrow;
   
    //電車の生成座標
    private float LeftDropX;
    private float RightDropX;
    private const float DropY = 1.0f;
    private float LeftDropZ;
    private float RightDropZ;

   
    /// 電車の生成位置
    private Vector3 LeftDropPos = Vector3.zero;
    private Vector3 RightDropPos = Vector3.zero;

    //左右の線路のX座標範囲
    private float MinRightRangeX = -50.0f;
    private float MaxRightRangeX = -103.0f;
    
    private float MaxLeftRangeX = 75.0f;
    private float MinLeftRangeX = 30.0f;

    //左右の電車それぞれの生成時間
    private float RightTrainGenerateTime = 0.0f;
    private float SecondRightTrainGenerateTime = 0.0f;

    private float LeftTrainGenerateTime = 0.0f;
    private float SecondLeftTrainGenerateTime = 0.0f;

    //左右の電車それぞれの生成間隔時間
    private float RightTrainFirstIntervalTime = 8.0f;
    private float RightTrainSecondIntervalTime = 10.0f;

    private float LeftTrainFirstIntervalTime = 8.0f;
    private float LeftTrainSecondIntervalTime = 10.0f;

    private float ReturnTrainInverval = 11.0f;
    private float ReturnTrainTime = 0.0f;
  

    //左右の電車の向き
    private Quaternion LeftTrainRotaion = Quaternion.Euler(0, 260, 0);
    private Quaternion RightTrainRotaion = Quaternion.Euler(0, 90, 0);
  
    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        DropTrainName = "SecondTrain";
        DropSideTrainName = "ThirdTrain";
        RightArrow = GameObject.Find("RightArrow");
        LeftArrow = GameObject.Find("LeftArrow");
    }

    void FixedUpdate()
    {
        if (IsTrainStart == true)
        {
            DropRightForwardTrain();
            DropLeftForwardTrain();
            ReturnTrainTime += Time.deltaTime;
            
        }
        else if (IsTrainStart == false)
        {
            return;
        }

        if (ReturnTrainTime > ReturnTrainInverval)
        {
            ObjectPool.instance.ReturnToPool(DropObject, DropTrainName);
            ObjectPool.instance.ReturnToPool(OtherSideDropObject, DropSideTrainName);
            ReturnTrainTime = 0.0f;
        }
    }

    //右からの電車生成
    private void DropRightForwardTrain()
    {
        //線路内の電車の発生範囲
        RightDropX = Random.Range(MinRightRangeX, MaxRightRangeX);
        RightTrainGenerateTime += Time.deltaTime;
        LeftTrainGenerateTime += Time.deltaTime;
       
        //1枚目の線路
        if (RightTrainGenerateTime > RightTrainFirstIntervalTime)
        {
            RightArrow.GetComponent<ArrowFlashing>().StartBlinking();
            SetRangeRightPositionZ(-842.0f, -850.0f);

            RightDropPos = new Vector3(RightDropX, DropY, RightDropZ);
           
            TrainSetting(DropObject, RightTrainRotaion, RightDropPos, DropTrainName);
            RightTrainGenerateTime = 0.0f;
           
        }
        //3枚目の線路
        if (SecondRightTrainGenerateTime > RightTrainSecondIntervalTime)
        {
            RightArrow.GetComponent<ArrowFlashing>().StartBlinking();
            SetRangeRightPositionZ(-934.0f, -942.0f);

            RightDropPos = new Vector3(RightDropX, DropY, RightDropZ);
            TrainSetting(DropObject, RightTrainRotaion, RightDropPos, DropTrainName);
            SecondRightTrainGenerateTime = 0.0f;
        }
    }

    //右からの電車生成
    private void DropLeftForwardTrain()
    {
        //線路内の電車の発生範囲
        LeftDropX = Random.Range(MinLeftRangeX, MaxLeftRangeX);

        SecondRightTrainGenerateTime += Time.deltaTime;
        SecondLeftTrainGenerateTime += Time.deltaTime;

        ///2枚目の線路からの生成
        if (LeftTrainGenerateTime > LeftTrainFirstIntervalTime)
        {
            LeftArrow.GetComponent<ArrowFlashing>().StartBlinking();
            SetRangeLeftPositionZ(-885.6f, -898.0f);

            LeftDropPos = new Vector3(LeftDropX, DropY, LeftDropZ);
            TrainSetting(OtherSideDropObject, LeftTrainRotaion, LeftDropPos, DropSideTrainName);
            LeftTrainGenerateTime = 0.0f;
        }
        ///4枚目の線路からの生成
        if (SecondLeftTrainGenerateTime > LeftTrainSecondIntervalTime)
        {
            LeftArrow.GetComponent<ArrowFlashing>().StartBlinking();
            SetRangeLeftPositionZ(-969.0f, -980.0f);

            LeftDropPos = new Vector3(LeftDropX, DropY, LeftDropZ);
            TrainSetting(OtherSideDropObject, LeftTrainRotaion, LeftDropPos, DropSideTrainName);
            SecondLeftTrainGenerateTime = 0.0f;
        }
    }

    //各電車の生成するZ座標の設定する関数
    public float SetRangeLeftPositionZ(float LeftMaxRangeZ, float LeftMinRangeZ)
    {
        LeftDropZ = Random.Range(LeftMaxRangeZ, LeftMinRangeZ);
        return LeftDropZ;
    }

    private float SetRangeRightPositionZ(float RightMaxRangeZ, float RightMinRangeZ)
    {
        RightDropZ = Random.Range(RightMaxRangeZ, RightMinRangeZ);
        return RightDropZ;
    }

    //生成する電車のオブジェクト、座標、向きを設定する関数
    public void TrainSetting(GameObject obj, Quaternion dir, Vector3 pos,string key)
    {
        obj.transform.position = pos;
        obj.transform.rotation = dir;
        ObjectPool.instance.GetPooledObject(key);
        
    }

   
    public void TrainIsStart()
    {
        IsTrainStart = true;
    }
}