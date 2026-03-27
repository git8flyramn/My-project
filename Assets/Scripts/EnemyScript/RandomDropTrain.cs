using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class RandomDropTrain : MonoBehaviour
{

    public GameObject DropObject;
    private TrainMove move;
    private float DropX;
    private static float DropY;
    private float DropZ;

  //  private float PosRange = 40.0f;
    //右から生成する座標
    private float MinRightRangeX;
    private float MaxRightRangeX;
    //左から生成
    private float MinLeftRangeX;
    private float MaxLeftRangeX;

    private float RightGenerateTime = 0.0f;
    private float LeftGenerateTime = 0.0f;
    
    private Quaternion Rotaion = Quaternion.Euler(0, 90, 0);
    private Vector3 DropPos = Vector3.zero;

    void Start()
    {
        DropY = 1.0f;
        //右側の線路のX座標
        MaxRightRangeX = -50.0f;
        MinRightRangeX = -103.0f;

        //側の線路のX座標
        MaxLeftRangeX = 75.0f;
        MinLeftRangeX = 30.0f;
        move = GetComponent<TrainMove>();
    }

    // Update is called once per frame
    void Update()
    {

        DropRightForwardTrain();
        DropLeftForwardTrain();
    }

    //電車を横向き右から左で生成する
    void DropRightForwardTrain()
    {
        //線路内の電車の発生範囲
        RightGenerateTime += Time.deltaTime;
        DropX = Random.Range(MinRightRangeX, MaxRightRangeX);
        //手前
        if (RightGenerateTime == 5)
        {
            SetRangeDropZ(-835.0f, -842.0f);
            DropPos = new Vector3(DropX, DropY, DropZ);
        }
        //奥 
        if (RightGenerateTime == 6)
        {
            SetRangeDropZ(-994.0f, -1003.0f);
            DropPos = new Vector3(DropX, DropY, DropZ);
        }
        //真ん中
        if (RightGenerateTime == 7)
        {
            //線路の横幅の端の座標
            SetRangeDropZ(-905.0f, -915.0f);
            DropPos = new Vector3(DropX, DropY, DropZ);
        }
        move.TrainRightMove();
        Instantiate(DropObject, DropPos, Rotaion);
        Debug.Log("電車が右向きで生成されました");
    }

    void DropLeftForwardTrain()
    {
        //線路内の電車の発生範囲
        LeftGenerateTime += Time.deltaTime;
        DropX = Random.Range(MinLeftRangeX, MaxLeftRangeX);

        //手前
        if (LeftGenerateTime == 5)
        {
            SetRangeDropZ(-860.0f, -868.0f);
            DropPos = new Vector3(DropX, DropY, DropZ);
        }
        //真ん中
        if (LeftGenerateTime == 6)
        {
            SetRangeDropZ(-941.0f, -953.0f);
            DropPos = new Vector3(DropX, DropY, DropZ);
        }
        //奥
        if (LeftGenerateTime == 7)
        {
            SetRangeDropZ(-1030.0f, -1040.0f);
            DropPos = new Vector3(DropX, DropY, DropZ);
        }
        move.TrainLeftMove();
        Instantiate(DropObject, DropPos, Rotaion);
        Debug.Log("電車が左向きで生成されました");

    }

    private float SetRangeDropZ(float maxrangeZ, float minrangeZ)
    {
        float MaxRange;
        float MinRange;
        MaxRange = maxrangeZ;
        MinRange = minrangeZ;
        DropZ = Random.Range(MaxRange, MinRange);
        return DropZ;
    }
}
