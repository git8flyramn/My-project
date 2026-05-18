using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Pool;
using Unity.VisualScripting;
public class TrainManeger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject FrontTrain;
    private GameObject TrainPool;

    public Transform LeftTrainPlace1;
    public Transform RightTrainPlalce1;
    public Transform LeftTrainPlace2;
    public Transform RightTrainPlalce2;
    
    //電車の生成時間のカウント
    private float TrainLeftGenerateTime = 0.0f;
    private float TrainRightGenerateTime = 0.0f;

    //電車の生成間隔
    private float TrainLeftIntervalTime = 4.0f;
    private float TrainRightIntervalTime = 6.0f;
    [SerializeField] private ObjectPool Pool;
    
 
    // private float TrainBackRightIntervalTime = 4.0f;
    //private float TrainBackLeftIntervalTime = 6.0f;

    // private float TrainBackLeftGenerateTime = 0.0f;
    //private float TrainBackRightGenerateTime = 0.0f;









    void Start()
    {
        TrainPool = Pool.GetComponent<ObjectPool>().Get();

    }

    // Update is called once per frame
    void Update()
    {
        TrainLeftGenerateTime  += Time.deltaTime;
        TrainRightGenerateTime += Time.deltaTime;
        FrontGenerateTrain();
    }

    //前半部分の電車の生成
    void FrontGenerateTrain()
    {
      
        if (TrainLeftGenerateTime > TrainLeftIntervalTime)
        {
           
            SetTrainPostion(TrainPool, LeftTrainPlace1);
           // SetTrainPostion(TrainPool, RightTrainPlalce2);
           // Debug.Log("前半と後半の電車が生成されました");
            TrainLeftGenerateTime = 0.0f;
        }
      
        if (TrainRightGenerateTime > TrainRightIntervalTime)
        {
            SetTrainPostion(TrainPool, RightTrainPlalce1);
            //SetTrainPostion(TrainPool, LeftTrainPlace2);
            TrainRightGenerateTime = 0.0f;
        }

    }


    //後半部分の電車の生成


    void BackGenerateTrainPool()
    {
        //if (TrainBackLeftGenerateTime > TrainBackLeftIntervalTime)
        //{
          
        //    Debug.Log("後半の電車が生成されました");
        //    SetTrainPostion(TrainPool, LeftTrainPlace2);
        //    TrainBackLeftGenerateTime = 0.0f;
        //}

        //if (TrainBackRightGenerateTime > TrainBackRightIntervalTime)
        //{
            
        //    SetTrainPostion(TrainPool, RightTrainPlalce2);
        //    TrainRightGenerateTime = 0.0f;
        //}
    }


    public void SetTrainPostion(GameObject obj, Transform trans)
    {
        obj.transform.rotation = Quaternion.identity;
        obj.transform.position = trans.transform.position;
    }

   

   



}


