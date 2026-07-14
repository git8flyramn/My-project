using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.SceneManagement;
public class TrainManeger : MonoBehaviour
{
    
    public GameObject FrontTrain;
    private GameObject TrainPool;
    private SEManeger SE;
    public AudioClip clip;
    [SerializeField] private ObjectPool Pool;

    public Transform LeftTrainPlace;
    public Transform RightTrainPlalce;
    
    //電車の生成時間のカウント
    private float TrainLeftGenerateTime = 0.0f;
    private float TrainRightGenerateTime = 0.0f;
   
    //電車の生成間隔
    private float TrainLeftIntervalTime  = 6.0f;
    private float TrainRightIntervalTime = 9.0f;

    void Start()
    {
        TrainPool = Pool.GetComponent<ObjectPool>().Get();
        SE 　　　　= GetComponent<SEManeger>();
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
            SetTrainPostion(FrontTrain, LeftTrainPlace);
            TrainLeftGenerateTime = 0.0f;
          
        }

        if(TrainRightGenerateTime > TrainRightIntervalTime)
        {
            SetTrainPostion(FrontTrain, RightTrainPlalce);
            TrainRightGenerateTime = 0.0f;
            
        }
    }
    public void SetTrainPostion(GameObject obj, Transform trans)
    {
        obj.transform.rotation = Quaternion.identity;
        obj.transform.position = trans.transform.position;
    }
}


