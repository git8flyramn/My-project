using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class RandomDropTrain : MonoBehaviour
{

    public GameObject DropObject;
    //private int frame = 30;
    private float DropX;
    private float DropY = 1.0f;
    private float DropZ;

    private float PosRange = 40.0f;
    //右から生成する座標
    private float MinRightRangeX;
    private float MaxRightRangeX;
    private float MinRightRangeZ;
    private float MaxRightRangeZ;

    //左から生成
    private float MinLeftRangeX;
    private float MaxLeftRangeX;
    private float MinLeftRangeZ;
    private float MaxLeftRangeZ;

    private float RightGenerateTime = 0.0f;
    private float LeftGenerateTime = 0.0f;
    
    private Quaternion Rotaion = Quaternion.Euler(0, 90, 0);
    private Vector3 DropPos = Vector3.zero;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RightGenerateTime += Time.deltaTime;
        LeftGenerateTime += Time.deltaTime;
        if (RightGenerateTime > 5)
        {
            DropRightForwardTrain();
            RightGenerateTime = 0.0f;
        }
        if(LeftGenerateTime > 5)
        {
            DropLeftForwardTrain();
            LeftGenerateTime = 0.0f;
        }
    }

    //電車を横向き右から左で生成する
    void DropRightForwardTrain()
    {
        //線路内の電車の発生範囲
        MaxRightRangeX = -50.0f;
        MinRightRangeX = -103.0f;

        MaxRightRangeZ = -837.0f; // 840
        MinRightRangeZ = -996.0f; //990
        DropX = Random.Range(MinRightRangeX, MaxRightRangeX);
            DropZ = Random.Range(MinRightRangeZ, MaxRightRangeZ);
            DropPos = new Vector3(DropX, DropY, DropZ);
           Instantiate(DropObject, DropPos, Rotaion);
            Debug.Log("電車が右向きで生成されました");

        /*
      for(int i = 0; i < 100; i+= PosRange )
     {
       Instantiate(DropObject, new Vector3( DropPos.x,  DropPos.y,  DropPos.z  + PosRange), Rotaion);
     }
      */

    }

    void DropLeftForwardTrain()
    {
        //線路内の電車の発生範囲
        MaxLeftRangeX = 75.0f;
        MinLeftRangeX = 30.0f;

        MaxLeftRangeZ = -861.0f; //860
        MinLeftRangeZ = -1036.0f;//1040
     
        DropX = Random.Range(MinLeftRangeX, MaxLeftRangeX);
        DropZ = Random.Range(MinLeftRangeZ, MaxLeftRangeZ);
        DropPos = new Vector3(DropX, DropY, DropZ);
        Instantiate(DropObject, DropPos, Rotaion);
        Debug.Log("電車が左向きで生成されました");


        /*
         for(int i = 0; i < 100; i+= PosRange )
        {
          Instantiate(DropObject, new Vector3( DropPos.x,  DropPos.y,  DropPos.z  + PosRange), Rotaion);
        }
         */

    }
}
