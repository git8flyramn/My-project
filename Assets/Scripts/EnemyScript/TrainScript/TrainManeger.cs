using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Pool;
using Unity.VisualScripting;
public class TrainManeger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject FrontTrain;
    GameObject TrainPool;
    public Transform LeftTrainPlace1;
    public Transform RightTrainPlalce1;
   

    //電車の生成時間のカウント
    private float TrainLeftGenerateTime = 0.0f;
    private float TrainRightGenerateTime = 0.0f;
    private float TrainLeftIntervalTime = 4.0f;
    private float TrainRightIntervalTime = 6.0f;

    [SerializeField] private ObjectPool Pool;



    void Start()
    {
        TrainPool = Pool.GetComponent<ObjectPool>().Get();

    }

    // Update is called once per frame
    void Update()
    {
        TrainLeftGenerateTime     += Time.deltaTime;
        TrainRightGenerateTime    += Time.deltaTime;
       

        GererateTrain();
    }


    private void GererateTrain()
    {
        FrontGenerateTrain();
       
    }
    //前半部分の電車の生成
    void FrontGenerateTrain()
    {
      
        if (TrainLeftGenerateTime > TrainLeftIntervalTime)
        {
           
            SetTrainPostion(TrainPool, LeftTrainPlace1);
            TrainLeftGenerateTime = 0.0f;
        }
      
        if (TrainRightGenerateTime > TrainRightIntervalTime)
        {
           
            SetTrainPostion(TrainPool, RightTrainPlalce1);
            TrainRightGenerateTime = 0.0f;
        }

      
    }


    //後半部分の電車の生成
   


    public void SetTrainPostion(GameObject obj, Transform trans)
    {
        obj.transform.rotation = Quaternion.identity;
        obj.transform.position = trans.transform.position;
    }

   



}


