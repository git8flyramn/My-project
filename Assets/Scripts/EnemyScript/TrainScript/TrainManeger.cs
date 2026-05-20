using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;
public class TrainManeger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject FrontTrain;
    private GameObject TrainPool;
    [SerializeField] private ObjectPool Pool;

    public Transform LeftTrainPlace1;
    public Transform RightTrainPlalce1;
    public Transform LeftTrainPlace2;
    public Transform RightTrainPlalce2;
    
    //電車の生成時間のカウント
    private float TrainLeftGenerateTime = 0.0f;
    private float TrainRightGenerateTime = 0.0f;
    private float TrainLeftBackGenerateTime = 0.0f;
    private float RightTrainBackGenerateTime = 0.0f;
   
    //電車の生成間隔
    private float TrainLeftIntervalTime     = 4.0f;
    private float TrainLeftBackIntervalTime = 8.0f;
    private float TrainRightIntervalTime    = 6.0f;
    private float RightTrainBackIntervalTime= 7.0f;

    









    void Start()
    {
        TrainPool = Pool.GetComponent<ObjectPool>().Get();

    }

    // Update is called once per frame
    void Update()
    {
        TrainLeftGenerateTime  += Time.deltaTime;
        TrainRightGenerateTime += Time.deltaTime;
        TrainLeftBackGenerateTime += Time.deltaTime;

        FrontGenerateTrain();
        //BackGenerateTrain();
    }

    //前半部分の電車の生成
    void FrontGenerateTrain()
    {
      
        if (TrainLeftGenerateTime > TrainLeftIntervalTime)
        {
            Debug.Log("前半の電車が生成されました");
            SetTrainPostion(TrainPool, LeftTrainPlace2);
            TrainLeftGenerateTime = 0.0f;
           
        }
       
        if(TrainRightGenerateTime > TrainRightIntervalTime)
        {
            SetTrainPostion(TrainPool, RightTrainPlalce2);
            TrainRightGenerateTime = 0.0f;
        }

    }


    //後半部分の電車の生成


    void BackGenerateTrain()
    {
        if (TrainLeftBackGenerateTime > TrainLeftBackIntervalTime)
        {
            SetTrainPostion(TrainPool, LeftTrainPlace2);
            Debug.Log("後半の電車が生成されました");
            TrainLeftBackGenerateTime = 0.0f;

        }

        if (RightTrainBackGenerateTime > RightTrainBackIntervalTime)
        {
            SetTrainPostion(TrainPool, RightTrainPlalce2);
            TrainLeftBackGenerateTime = 0.0f;

        }
    }


    public void SetTrainPostion(GameObject obj, Transform trans)
    {
        obj.transform.rotation = Quaternion.identity;
        obj.transform.position = trans.transform.position;
    }
}


