using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.SceneManagement;
public class TrainManeger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject FrontTrain;
    private GameObject TrainPool;
    private SEManeger SE;
    public AudioClip clip;
    [SerializeField] private ObjectPool Pool;

    public Transform LeftTrainPlace1;
    public Transform RightTrainPlalce1;
    
    //電車の生成時間のカウント
    private float TrainLeftGenerateTime = 0.0f;
    private float TrainRightGenerateTime = 0.0f;
   
    //電車の生成間隔
    private float TrainLeftIntervalTime  = 5.0f;
    private float TrainRightIntervalTime = 8.0f;




    void Start()
    {
        TrainPool = Pool.GetComponent<ObjectPool>().Get();
        SE = GetComponent<SEManeger>();
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
            TrainLeftGenerateTime = 0.0f;
        }

        if(TrainRightGenerateTime > TrainRightIntervalTime)
        {
            SetTrainPostion(TrainPool, RightTrainPlalce1);
            TrainRightGenerateTime = 0.0f;
        }
    }
    public void SetTrainPostion(GameObject obj, Transform trans)
    {
        obj.transform.rotation = Quaternion.identity;
        obj.transform.position = trans.transform.position;
     
    }
}


