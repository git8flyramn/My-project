using System.Data;
using UnityEngine;
using Unity.VisualScripting;
using System.Collections;
using System.Collections.Generic;
public class RandomDropTrain : MonoBehaviour
{

    public GameObject DropObject;
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
      
        //右側の線路のX座標
        MaxRightRangeX = -50.0f;
        MinRightRangeX = -103.0f;

        //左側の線路のX座標
        MaxLeftRangeX = 75.0f;
        MinLeftRangeX = 30.0f;
        
       


    }

    // Update is called once per frame
    void Update()
    {
        DropRightForwardTrain();
        DropLeftForwardTrain();
    }

    //電車を横向き右から左で生成する
    public void DropRightForwardTrain()
    {
        //線路内の電車の発生範囲
       

        FirstGenerateTime  += Time.deltaTime;
        SecondGenerateTime += Time.deltaTime;
        ThirdGenerateTime  += Time.deltaTime;
        DropX = Random.Range(MinRightRangeX, MaxRightRangeX);

       
        //手前
        if (FirstGenerateTime > FirstIntervalTime)
        {
            Debug.Log("1電車が右向きで生成されました");
           
            SetRangePositionZ(-812.0f, -821.0f);
            DropPos = new Vector3(DropX, DropY, DropZ);
            Instantiate(DropObject, DropPos, RightTrainRotaion);
            
            FirstGenerateTime = 0.0f;
        }

        //奥 
        if (SecondGenerateTime > SecondIntervalTime)
        {

            SetRangePositionZ(-942.0f, -949.0f);
            DropPos = new Vector3(DropX, DropY, DropZ);
            Instantiate(DropObject, DropPos, RightTrainRotaion);
          
            Debug.Log("2電車が右向きで生成されました");
            SecondGenerateTime = 0.0f;
        }
        //真ん中
        if (ThirdGenerateTime > ThirdtIntervalTime)
        {
            //線路の横幅の端の座標
            SetRangePositionZ(-863.0f, -872.0f);
            DropPos = new Vector3(DropX, DropY, DropZ);
            Instantiate(DropObject, DropPos, RightTrainRotaion);
          
            ThirdGenerateTime = 0.0f;
        }


      
    }


    //電車を横向き左から右で生成する
    public void DropLeftForwardTrain()
    {
        FirstGenerateTime += Time.deltaTime;
        SecondGenerateTime += Time.deltaTime;
        ThirdGenerateTime += Time.deltaTime;

        //線路内の電車の発生範囲
        DropX = Random.Range(MinLeftRangeX, MaxLeftRangeX);

        //手前
        if (FirstGenerateTime > FirstIntervalTime)
        {
            SetRangePositionZ(-839.0f, -849.0f);
            DropPos = new Vector3(DropX, DropY, DropZ);
            Instantiate(DropObject, DropPos, LeftTrainRotaion);
            FirstGenerateTime = 0.0f;
        }

        //真ん中
        if (SecondGenerateTime > SecondIntervalTime)
        {
            SetRangePositionZ(-896.0f, -906.0f);
            DropPos = new Vector3(DropX, DropY, DropZ);
            Instantiate(DropObject, DropPos, LeftTrainRotaion);
            SecondGenerateTime = 0.0f;
        }
        ///奥
        if (ThirdGenerateTime > ThirdtIntervalTime)
        {
            SetRangePositionZ(-970.0f, -978.0f);
            DropPos = new Vector3(DropX, DropY, DropZ);
            Instantiate(DropObject, DropPos, LeftTrainRotaion);
            ThirdGenerateTime = 0.0f;
        }

        Debug.Log("電車が左向きで生成されました");
    }


    private float SetRangePositionZ(float maxrangeZ, float minrangeZ)
    {
        DropZ = Random.Range(maxrangeZ, minrangeZ);
        return DropZ;
    }

  
}
