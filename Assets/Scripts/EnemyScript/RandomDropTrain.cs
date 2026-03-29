using System.Data;
using UnityEngine;
using Unity.VisualScripting;
using System.Collections;
using System.Collections.Generic;
public class RandomDropTrain : MonoBehaviour
{

    public GameObject DropObject;
    private TrainMove train;
    private float DropX;
    private static float DropY;
    private float DropZ;

    //右から生成する座標
    private float MinRightRangeX;
    private float MaxRightRangeX;
    //左から生成
    private float MinLeftRangeX;
    private float MaxLeftRangeX;

    //左右の電車の生成時間
    // private float RightGenerateTime = 0.0f;
    private float FirstGenerateTime  = 0.0f;
    private float SecondGenerateTime = 1.0f;
    private float ThirdGenerateTime  = 2.0f;


    private float LeftGenerateTime = 0.0f;
    
    //左右の電車の向き
    private Quaternion LeftTrainRotaion = Quaternion.Euler(0, 270, 0);
    private Quaternion RightTrainRotaion = Quaternion.Euler(0, 90, 0);
    private Vector3 DropPos = Vector3.zero;

    void Start()
    {
              
        train = GetComponent<TrainMove>();
        DropY = 1.0f;
        //右側の線路のX座標
        MaxRightRangeX = -50.0f;
        MinRightRangeX = -103.0f;

        //側の線路のX座標
        MaxLeftRangeX = 75.0f;
        MinLeftRangeX = 30.0f;

        //GetComponent<Rigidbody>();
                           //TrainMove       
    }

    // Update is called once per frame
    void Update()
    {
        train.TrainRightMove();
         DropRightForwardTrain();
       // DropLeftForwardTrain();
    }

    //電車を横向き右から左で生成する
    void DropRightForwardTrain()
    {
        train.TrainRightMove();
        //線路内の電車の発生範囲

        FirstGenerateTime  += Time.deltaTime;
        SecondGenerateTime += Time.deltaTime;
        ThirdGenerateTime  += Time.deltaTime;

        DropX = Random.Range(MinRightRangeX, MaxRightRangeX);
        //手前
        if (FirstGenerateTime > 5)
        {
            //Debug.Log("電車が右向きで生成されました");
          
            SetRangePosition(-835.0f, -842.0f);
            Instantiate(DropObject, DropPos, RightTrainRotaion);
            FirstGenerateTime = 0.0f;


        }
        //奥 
        if (SecondGenerateTime > 6)
        {

            SetRangePosition(-994.0f, -1003.0f);
            Instantiate(DropObject, DropPos, RightTrainRotaion);
            SecondGenerateTime = 0.0f;
        }
        //真ん中
        if (ThirdGenerateTime > 7)
        {

            //線路の横幅の端の座標
            SetRangePosition(-905.0f, -915.0f);
            Instantiate(DropObject, DropPos, RightTrainRotaion);
            ThirdGenerateTime = 0.0f;
        }


        //Debug.Log("電車が右向きで生成されました");
    }


    //電車を横向き左から右で生成する
    void DropLeftForwardTrain()
    {
        FirstGenerateTime += Time.deltaTime;
        SecondGenerateTime += Time.deltaTime;
        ThirdGenerateTime += Time.deltaTime;

        //線路内の電車の発生範囲
        LeftGenerateTime += Time.deltaTime;
        DropX = Random.Range(MinLeftRangeX, MaxLeftRangeX);

        手前
        if (FirstGenerateTime > 5)
        {
            SetRangePosition(-860.0f, -868.0f);
            Instantiate(DropObject, DropPos, LeftTrainRotaion);
            FirstGenerateTime = 0.0f;
        }

        //真ん中
        if (SecondGenerateTime > 6)
        {
            SetRangePosition(-941.0f, -953.0f);
            Instantiate(DropObject, DropPos, LeftTrainRotaion);
            SecondGenerateTime = 0.0f;
        }
        ///奥
        if (ThirdGenerateTime > 7)
        {
            SetRangePosition(-1030.0f, -1040.0f);
            Instantiate(DropObject, DropPos, LeftTrainRotaion);
            ThirdGenerateTime = 0.0f;
        }
    }


    private float SetRangePosition(float maxrangeZ, float minrangeZ)
    {
        DropZ = Random.Range(maxrangeZ, minrangeZ);
        DropPos = new Vector3(DropX, DropY, DropZ);
    }
}
