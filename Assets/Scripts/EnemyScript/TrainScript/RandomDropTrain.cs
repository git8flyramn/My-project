using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
public class RandomDropTrain : MonoBehaviour
{
    //生成する電車のモデルを受け取る変数
    public GameObject DropObject;
    //電車の生成位置
    private float LeftDropX;
    private float RightDropX;

    private const float DropY = 1.0f;
    
    private float LeftDropZ;
    private float RightDropZ;

    private Vector3 LeftDropPos = Vector3.zero;
    private Vector3 RightDropPos = Vector3.zero;

    //右側の線路のX座標範囲
    private float MinRightRangeX =  -50.0f;
    private float MaxRightRangeX = -103.0f;

    //左側の線路のX座標範囲
    private float MaxLeftRangeX = 75.0f;
    private float MinLeftRangeX = 30.0f;

    //左右の電車の生成時間
    private float RightTrainGenerateTime = 0.0f;
    private float LeftTrainGenerateTime = 0.0f;
    private float secondGenrateTime = 0.0f;

    //各電車のそれぞれの生成間隔時間
    private float FirstIntervalTime = 5.0f;
    private float SecondIntervalTime = 10.0f;
   
    //左右の電車の向き
     private Quaternion LeftTrainRotaion = Quaternion.Euler(0, 0, 0);
     private Quaternion RightTrainRotaion = Quaternion.Euler(0, 90, 0);

   




    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        RightTrainGenerateTime+= Time.deltaTime;
        LeftTrainGenerateTime += Time.deltaTime;
        secondGenrateTime     += Time.deltaTime;
        DropRightForwardTrain();
       // DropLeftForwardTrain();
    }

    //右から生成
    public void DropRightForwardTrain()
    {
        //線路内の電車の発生範囲
        RightDropX = Random.Range(MinRightRangeX, MaxRightRangeX);
        
        //経過時間が10秒を超えたら生成される
        //手前
        if (RightTrainGenerateTime > FirstIntervalTime)
        {
            SetRangeRightPositionZ(-812.0f, -821.0f);
            RightDropPos = new Vector3(RightDropX,DropY,RightDropZ);
            TrainSetting(DropObject, RightTrainRotaion, RightDropPos);
            RightTrainGenerateTime = 0.0f;

        }
        //真ん中
        else if (secondGenrateTime > SecondIntervalTime)
        {
            Debug.Log("2つ目の電車が生成されました");
            SetRangeRightPositionZ(-942.0f, -949.0f);
            RightDropPos = new Vector3(RightDropX, DropY, RightDropZ);
            TrainSetting(DropObject, RightTrainRotaion, RightDropPos);

            secondGenrateTime = 0.0f;
           
        }
        //奥
        else
        {
            //SetRangeLeftPositionZ(-863.0f, -872.0f);
            /*
             RightDropPos = new Vector3(RightDropX, DropY, RightDropZ);
             TrainSetting(DropObject, RightTrainRotaion, RightDropPos);
             Debug.Log("生成時間がリセットされました");
             RightTrainGenerateTime = 0.0f;
             */
        }
    }

    //右から生成
    public void DropLeftForwardTrain()
    {
        //線路内の電車の発生範囲
        LeftDropX = Random.Range(MinLeftRangeX, MaxLeftRangeX);

        ///奥
        if (LeftTrainGenerateTime > FirstIntervalTime)
        { 
            SetRangeLeftPositionZ(-839.0f, -849.0f);
            LeftDropPos = new Vector3(LeftDropX, DropY, LeftDropZ);
            TrainSetting(DropObject, LeftTrainRotaion, LeftDropPos);
            LeftTrainGenerateTime = 0.0f;

        }//手前
        if (LeftTrainGenerateTime > SecondIntervalTime)
        {
            SetRangeLeftPositionZ(-970.0f, -978.0f);
            LeftDropPos = new Vector3(LeftDropX, DropY, LeftDropZ);
            TrainSetting(DropObject, LeftTrainRotaion, LeftDropPos);
            LeftTrainGenerateTime = 0.0f;
        }
        //真ん中
        else
        {
            //SetRangeLeftPositionZ(-896.0f, -906.0f);
            //LeftDropPos = new Vector3(LeftDropX, DropY, LeftDropZ);
            //TrainSetting(DropObject, LeftTrainRotaion, LeftDropPos);
            //ThirdGenerateTime = 0.0f;
        }
    }


    //各電車の生成するZ座標の設定する関数
    private float SetRangeLeftPositionZ(float LeftMaxRangeZ, float LeftMinRangeZ)
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
      //  Debug.Log("電車が生成されました");
    }

    public void ChangeRotaion()
    {
        LeftTrainRotaion = Quaternion.Euler(0, 135, 0);
    }
}
