using System.Data;
using UnityEngine;
using Unity.VisualScripting;
using System.Collections;
using System.Collections.Generic;
public class RandomDropTrain : MonoBehaviour
{

    public GameObject DropObject;
    //電車の座標位置
    private float LeftDropX;
    private float RightDropX;
    private static float DropY;
    private float DropZ;

    //右側の線路のX座標
    private float MinRightRangeX = -50.0f;
    private float MaxRightRangeX = -103.0f;

    //左側の線路のX座標
    private float MaxLeftRangeX = 75.0f;
    private float MinLeftRangeX = 30.0f;

    //左右の電車の生成時間
    private float FirstGenerateTime  = 0.0f;
    private float SecondGenerateTime = 1.0f;
    private float ThirdGenerateTime  = 2.0f;


    private float FirstIntervalTime = 10.0f;
    private float SecondIntervalTime = 11.0f;
    private float ThirdtIntervalTime = 12.0f;


   
    //左右の電車の向き
    private Quaternion LeftTrainRotaion = Quaternion.Euler(0, 270, 0);
    private Quaternion RightTrainRotaion = Quaternion.Euler(0, 90, 0);
    private Vector3 DropPos = Vector3.zero;

    void Start()
    {
        DropY = 1.0f;
        RightDropX = Random.Range(MinRightRangeX, MaxRightRangeX);
        LeftDropX  = Random.Range(MinLeftRangeX, MaxLeftRangeX);



    }

    // Update is called once per frame
    void Update()
    {
        FirstGenerateTime += Time.deltaTime;
        SecondGenerateTime += Time.deltaTime;
        ThirdGenerateTime += Time.deltaTime;
       
        // DropLeftForwardTrain();
        DropRightForwardTrain();
    }

    //電車を横向き右から左で生成する
    public void DropRightForwardTrain()
    {
        //線路内の電車の発生範囲
        //手前
        if (FirstGenerateTime / FirstIntervalTime == 0)
        {
            SetRangePositionZ(-812.0f, -821.0f);
        }

        //奥 
        if (SecondGenerateTime / SecondIntervalTime == 0)
        {
            SetRangePositionZ(-942.0f, -949.0f);
        }
        //真ん中
        if (ThirdGenerateTime / ThirdtIntervalTime == 0)
        {
            //線路の横幅の端の座標
            SetRangePositionZ(-863.0f, -872.0f);
        }
        DropPos = new Vector3(RightDropX, DropY, DropZ);
        Instantiate(DropObject, DropPos, RightTrainRotaion);


    }


    //電車を横向き左から右で生成する
    public void DropLeftForwardTrain()
    {


        //線路内の電車の発生範囲
        LeftDropX = Random.Range(MinLeftRangeX, MaxLeftRangeX);

        //手前
        if (FirstGenerateTime / FirstIntervalTime == 0)
        {
            SetRangePositionZ(-839.0f, -849.0f);

        }

        //真ん中

        if (ThirdGenerateTime / ThirdtIntervalTime == 0)
        {
            SetRangePositionZ(-896.0f, -906.0f);
        }
        ///奥
        if (SecondGenerateTime / SecondIntervalTime == 0)
        {
            SetRangePositionZ(-970.0f, -978.0f);
        }
        DropPos = new Vector3(LeftDropX, DropY, DropZ);
        Instantiate(DropObject, DropPos, LeftTrainRotaion);
    }


    private float SetRangePositionZ(float maxrangeZ, float minrangeZ)
    {
        DropZ = Random.Range(maxrangeZ, minrangeZ);
        return DropZ;
    }

  
}
