using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RandomDropTrain : MonoBehaviour
{

    public GameObject DropObject;
  
    //電車の座標位置
    private float LeftDropX;
    private float RightDropX;
    private const float DropY = 1.0f;
    private float DropZ;
    // Transform left
    //

    //右側の線路のX座標
    private float MinRightRangeX = -50.0f;
    private float MaxRightRangeX = -103.0f;

    //左側の線路のX座標
    //private float MaxLeftRangeX = 75.0f;
    //private float MinLeftRangeX = 30.0f;

    //左右の電車の生成時間
    private float RightTrainGenerateTime = 0.0f;

    //各電車のそれぞれの生成間隔時間
    private float FirstIntervalTime = 10.0f;
    private float SecondIntervalTime = 15.0f;
    private float ThirdtIntervalTime = 20.0f;




    //左右の電車の向き
    private Quaternion LeftTrainRotaion = Quaternion.Euler(0, 270, 0);
    private Quaternion RightTrainRotaion = Quaternion.Euler(0, 90, 0);
   
    //private Quaternion ForwardRotaion = Quaternion.identity;
    private Vector3 DropPos = Vector3.zero;


    public void Awake()
    {
      
    }

    void Start()
    {

     
    }

    // Update is called once per frame
    void Update()
    {
        
        RightTrainGenerateTime += Time.deltaTime;
        DropRightForwardTrain();
       
    }

    //電車を横向き右から左で生成する
    public void DropRightForwardTrain()
    {
        //線路内の電車の発生範囲
        RightDropX = Random.Range(MinRightRangeX, MaxRightRangeX);

        //経過時間が10秒を超えたら生成される
        //手前
        if (RightTrainGenerateTime == FirstIntervalTime)
        {
            SetRangePositionZ(-812.0f, -821.0f);
            DropPos = new Vector3(RightDropX, DropY, DropZ);
            Instantiate(DropObject, DropPos, RightTrainRotaion);
        }

        //真ん中
        if (RightTrainGenerateTime == SecondIntervalTime)
        {
            SetRangePositionZ(-863.0f, -872.0f);
            DropPos = new Vector3(RightDropX, DropY, DropZ);
            Instantiate(DropObject, DropPos, RightTrainRotaion);
        }
        ////奥 
        if (RightTrainGenerateTime == ThirdtIntervalTime)
        {
            SetRangePositionZ(-863.0f, -872.0f);
            DropPos = new Vector3(RightDropX, DropY, DropZ);
            Instantiate(DropObject, DropPos, RightTrainRotaion);
            RightTrainGenerateTime = 0.0f;
            Debug.Log("生成時間がリセットされました");
        }

       
    }

    //電車を横向き左から右で生成する

    //public void DropLeftForwardTrain()
    // {


    //   //線路内の電車の発生範囲
    //   LeftDropX = Random.Range(MinLeftRangeX, MaxLeftRangeX);

    //     ///奥
    //     if (FirstGenerateTime > FirstIntervalTime)
    //     {
    //       Debug.Log("電車が左に生成されました");
    //       SetRangePositionZ(-839.0f, -849.0f);
    //       DropPos = new Vector3(LeftDropX, DropY, DropZ);
    //       Instantiate(DropObject, DropPos, LeftTrainRotaion);
    //       FirstGenerateTime = 0.0f;
    //     }


    //     //手前
    //     if (SecondGenerateTime > SecondIntervalTime)
    //     {

    //         SetRangePositionZ(-970.0f, -978.0f);
    //         DropPos = new Vector3(LeftDropX, DropY, DropZ);
    //         Instantiate(DropObject, DropPos, LeftTrainRotaion);
    //         SecondGenerateTime = 0.0f;
    //     }

    //     //真ん中

    //     if (ThirdGenerateTime > ThirdtIntervalTime)
    //     {
    //       SetRangePositionZ(-896.0f, -906.0f);
    //       DropPos = new Vector3(LeftDropX, DropY, DropZ);
    //       Instantiate(DropObject, DropPos, LeftTrainRotaion);
    //       ThirdGenerateTime = 0.0f;

    //     }

    // }


    //各電車の生成するZ座標の設定する関数


    private float SetRangePositionZ(float maxrangeZ, float minrangeZ)
    {
        DropZ = Random.Range(maxrangeZ, minrangeZ);
        return DropZ;
    }


    public void TrainSetting(GameObject obj,Quaternion dir,Vector3 pos)
    {
        obj.transform.rotation = dir;
        obj.transform.position = pos;
        Instantiate(obj, obj.transform.position, obj.transform.rotation);
    }

}
