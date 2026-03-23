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
    private float MinRightRangeX;
    private float MaxLeftRangeX;
    private float MinRightRangeZ;
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
        }
        if(LeftGenerateTime > 5)
        {
            DropLeftForwardTrain();
        }
    }

    //電車を横向き右から左で生成する
    void DropRightForwardTrain()
    {
            MinRightRangeX = -105.0f;
            MaxLeftRangeX = -59.0f;
            MinRightRangeZ = -930.0f;
            MaxLeftRangeZ = -780.0f;

            DropX = Random.Range(MinRightRangeX, MaxLeftRangeX);
            DropZ = Random.Range(MinRightRangeZ, MaxLeftRangeZ);
            DropPos = new Vector3(DropX, DropY, DropZ);
           Instantiate(DropObject, DropPos, Rotaion);
            Debug.Log("電車が右向きで生成されました");
            RightGenerateTime = 0.0f;
    }
    void DropLeftForwardTrain()
    {
        MinRightRangeX = 20.0f;
        MaxLeftRangeX =  67.0f;
        MinRightRangeZ = -880.0f;
        MaxLeftRangeZ = -1034.0f;

        DropX = Random.Range(MinRightRangeX, MaxLeftRangeX);
        DropZ = Random.Range(MinRightRangeZ, MaxLeftRangeZ);
        DropPos = new Vector3(DropX, DropY, DropZ);
        Instantiate(DropObject, DropPos, Rotaion);
        Debug.Log("電車が左向きで生成されました");
        LeftGenerateTime = 0.0f;
    }
}
