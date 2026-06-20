using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
public class RandomDropTrain : MonoBehaviour
{
    //生成する電車のモデルを受け取る変数
    public GameObject DropObject;
    public GameObject OtherSideDropObject;
   // private GameObject LeftArrow;
    private GameObject RightArrow;
    
    //電車の生成座標
    private float LeftDropX;
    private float RightDropX;

    private const float DropY = 1.0f;

    private float LeftDropZ;
    private float RightDropZ;

    private Vector3 LeftDropPos = Vector3.zero;
    private Vector3 RightDropPos = Vector3.zero;

    //右側の線路のX座標範囲
    private float MinRightRangeX = -50.0f;
    private float MaxRightRangeX = -103.0f;


    //左側の線路のX座標範囲
    private float MaxLeftRangeX = 75.0f;
    private float MinLeftRangeX = 30.0f;

    //左右の電車の生成時間
    private float RightTrainGenerateTime = 0.0f;
    private float SecondRightTrainGenerateTime = 0.0f;

    private float LeftTrainGenerateTime = 0.0f;
    private float SecondLeftTrainGenerateTime = 0.0f;


    //左右の電車それぞれの生成間隔時間
    private float RightTrainFirstIntervalTime = 15.0f;
    private float RightTrainSecondIntervalTime = 15.0f;

    private float LeftTrainFirstIntervalTime = 15.0f;
    private float LeftTrainSecondIntervalTime = 20.0f;

    //左右の電車の向き
    private Quaternion LeftTrainRotaion = Quaternion.Euler(0, 260, 0);
    private Quaternion RightTrainRotaion = Quaternion.Euler(0, 90, 0);

    void Start()
    {
        RightArrow = GameObject.Find("RightArrow");
    }

    void Update()
    {

      
        DropRightForwardTrain();
        DropLeftForwardTrain();
    }

    //右からの生成
    private void DropRightForwardTrain()
    {
        //線路内の電車の発生範囲
        RightDropX = Random.Range(MinRightRangeX, MaxRightRangeX);
        RightTrainGenerateTime += Time.deltaTime;
        LeftTrainGenerateTime += Time.deltaTime;
        //経過時間が10秒を超えたら生成される
        //手前
        if (RightTrainGenerateTime > RightTrainFirstIntervalTime)
        {
            RightArrow.GetComponent<ArrowFlashing>().StartBlinking();
            SetRangeRightPositionZ(-812.0f, -821.0f);
            RightDropPos = new Vector3(RightDropX, DropY, RightDropZ);
            TrainSetting(DropObject, RightTrainRotaion, RightDropPos);
            RightTrainGenerateTime = 0.0f;


        }

        if (SecondRightTrainGenerateTime > RightTrainSecondIntervalTime)
        {
            //RightArrow.GetComponent<ArrowFlashing>().StartBlinking();
            SetRangeRightPositionZ(-903.0f, -912.0f);
            RightDropPos = new Vector3(RightDropX, DropY, RightDropZ);
            TrainSetting(DropObject, RightTrainRotaion, RightDropPos);
            SecondRightTrainGenerateTime = 0.0f;
        }
    }

    //右からの生成
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
            SetRangeLeftPositionZ(-857.0f, -866.0f);
            LeftDropPos = new Vector3(LeftDropX, DropY, LeftDropZ);
            TrainSetting(OtherSideDropObject, LeftTrainRotaion, LeftDropPos);
            LeftTrainGenerateTime = 0.0f;

        }

        ///4枚目の線路からの生成
        if (SecondLeftTrainGenerateTime > LeftTrainSecondIntervalTime)
        {
            SetRangeLeftPositionZ(-945.0f, -956.0f);
            LeftDropPos = new Vector3(LeftDropX, DropY, LeftDropZ);
            TrainSetting(OtherSideDropObject, LeftTrainRotaion, LeftDropPos);
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
    public void TrainSetting(GameObject obj, Quaternion dir, Vector3 pos)
    {
        obj.transform.rotation = dir;
        obj.transform.position = pos;
        Instantiate(obj, obj.transform.position, obj.transform.rotation);

    }
}