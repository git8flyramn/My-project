using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Pool;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
public class trainPoolManeger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject Train;
    GameObject trainPool;
    public Transform LeftTrainPlace1;
    public Transform RightTrainPlalce1;
    public Transform LeftTrainPlace2;
    public Transform RightTrainPlalce2;

    //電車の生成時間のカウント
    private float TrainLeftGenerateTime = 0.0f;
    private float TrainRightGenerateTime = 0.0f;
   // private float TrainBackLeftGenerateTime = 0.0f;
    //private float TrainBackRightGenerateTime = 0.0f;
    private float TrainLeftIntervalTime = 5.0f;
    private float TrainRightIntervalTime = 7.0f;

    [SerializeField] private ObjectPool Pool;

   

    void Start()
    {
        trainPool= Pool.GetComponent<ObjectPool>().Get();

    }

    // Update is called once per frame
    void Update()
    {
        TrainLeftGenerateTime += Time.deltaTime;
        TrainRightGenerateTime += Time.deltaTime;
        GererateTrain();
    }


    private void GererateTrain()
    {
        FrontGeneratetrainPool();
        // BackGeneratetrainPool();
    }
    //前半部分の電車の生成
    void FrontGeneratetrainPool()
    {
        if (TrainLeftGenerateTime > TrainLeftIntervalTime)
        {  
            SetTrainPostion(trainPool, LeftTrainPlace1);
            TrainLeftGenerateTime = 0.0f;
        }
      
        if (TrainRightGenerateTime > TrainRightIntervalTime)
        {
            SetTrainPostion(trainPool, RightTrainPlalce1);
            TrainRightGenerateTime = 0.0f;
        }
      
    }

    
    //後半部分の電車の生成
    //void BackGeneratetrainPool()
    //{
    //    if (TrainBackLeftGenerateTime > TrainLeftIntervalTime)
    //    {
    //        Debug.Log("後半の電車が生成されました");
    //        SetTrainPostion(trainPool, LeftTrainPlace2);
    //        TrainBackLeftGenerateTime = 0.0f;
    //    }

    //    if (TrainBackRightGenerateTime > TrainRightIntervalTime)
    //    {
    //        SetTrainPostion(trainPool, RightTrainPlalce2);
    //        TrainRightGenerateTime = 0.0f;
    //    }
    //}
    //前方から来る敵
    
    
    private void SetTrainPostion(GameObject obj, Transform trans)
    {
        obj.transform.rotation = Quaternion.identity;
        obj.transform.position = trans.transform.position;
    }

   



}


