using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Pool;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
public class trainPoolManeger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject FrontTrain;
    public GameObject BackTrain;

    GameObject trainPool;
    public Transform LeftTrainPlace1;
    public Transform RightTrainPlalce1;
    public Transform LeftTrainPlace2;
    public Transform RightTrainPlalce2;

    //電車の生成時間のカウント
    private float TrainLeftGenerateTime = 0.0f;
    private float TrainRightGenerateTime = 0.0f;
    
    private float BackTrainLeftGenerateTime = 0.0f;
    private float BackTrainRightGenerateTime = 0.0f;

    private float TrainLeftIntervalTime = 4.0f;
    private float TrainRightIntervalTime = 6.0f;

    private float BackTrainLeftIntervalTime = 5.0f;
    private float BackTrainRightIntervalTime = 7.0f;

    [SerializeField] private ObjectPool Pool;

   

    void Start()
    {
        trainPool= Pool.GetComponent<ObjectPool>().Get();

    }

    // Update is called once per frame
    void Update()
    {
        TrainLeftGenerateTime     += Time.deltaTime;
        TrainRightGenerateTime    += Time.deltaTime;
        BackTrainLeftGenerateTime += Time.deltaTime;
        BackTrainRightGenerateTime+= Time.deltaTime;

        GererateTrain();
    }


    private void GererateTrain()
    {
        FrontGenerateTrain();
        BackGenerateTrain();
    }
    //前半部分の電車の生成
    void FrontGenerateTrain()
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
    private void BackGenerateTrain()
    {
        if (BackTrainLeftGenerateTime > BackTrainLeftIntervalTime)
        {
            Debug.Log("後半の電車が生成されました");
            SetTrainPostion(trainPool, LeftTrainPlace2);
            BackTrainLeftIntervalTime = 0.0f;
        }

        if (BackTrainRightGenerateTime > BackTrainRightIntervalTime)
        {
            SetTrainPostion(trainPool, LeftTrainPlace2);
            BackTrainRightIntervalTime = 0.0f;
        }
    }



    private void SetTrainPostion(GameObject obj, Transform trans)
    {
        obj.transform.rotation = Quaternion.identity;
        obj.transform.position = trans.transform.position;
    }

   



}


