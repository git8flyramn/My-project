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
    public Transform LefttrainPoolPlace1;
    public Transform RighttrainPoolPlace1;
    public Transform LefttrainPoolPlace2;
    public Transform RighttrainPoolPlace2;

    private Quaternion LeftTrainRotaion = Quaternion.Euler(0, 270, 0);
    //電車の生成時間のカウント
    private float TrainLeftGenerateTime = 0.0f;
    private float TrainRightGenerateTime = 0.0f;
    private float TrainBackLeftGenerateTime = 0.0f;
    private float TrainBackRightGenerateTime = 0.0f;
    private float TrainLeftIntervalTime = 5.0f;
    private float TrainRightIntervalTime = 8.0f;

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
        TrainBackLeftGenerateTime += Time.deltaTime;
        TrainBackRightGenerateTime += Time.deltaTime;

        FrontGeneratetrainPool();
        BackGeneratetrainPool();
    }

    //前半部分の電車の生成
    void FrontGeneratetrainPool()
    {
        if (TrainLeftGenerateTime > TrainLeftIntervalTime)
        {  
            SetTrainPostion(trainPool, LefttrainPoolPlace1);
            TrainLeftGenerateTime = 0.0f;

        }
      
        if (TrainRightGenerateTime > TrainRightIntervalTime)
        {
            SetTrainPostion(trainPool, RighttrainPoolPlace1);
            TrainRightGenerateTime = 0.0f;
        }
      
    }

    
    //後半部分の電車の生成
    void BackGeneratetrainPool()
    {
        if (TrainBackLeftGenerateTime > TrainLeftIntervalTime)
        {
           BackSetTrainPostion(trainPool, LefttrainPoolPlace2);
            TrainBackLeftGenerateTime = 0.0f;
        }

        if (TrainBackRightGenerateTime > TrainRightIntervalTime)
        {
           BackSetTrainPostion(trainPool, RighttrainPoolPlace2);
            TrainRightGenerateTime = 0.0f;
        }
    }
    //前方から来る敵
    private void SetTrainPostion(GameObject obj, Transform trans)
    {
        obj.transform.rotation = Quaternion.identity;
        obj.transform.position = trans.transform.position;
    }

    private void BackSetTrainPostion(GameObject obj, Transform trans)
    {
        obj.transform.rotation = Quaternion.identity;
        obj.transform.position = trans.transform.position;
    }



}


