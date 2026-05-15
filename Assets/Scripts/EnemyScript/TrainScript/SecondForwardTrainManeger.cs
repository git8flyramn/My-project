using UnityEngine;
using UnityEngine.Pool;
using System.Collections;
using System.Collections.Generic;
public class SecondForwardTrainManeger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private TrainManeger Maneger;
    public GameObject BackTrain;
    private float BackTrainLeftGenerateTime = 0.0f;
    private float BackTrainRightGenerateTime = 0.0f;
    private float BackTrainLeftIntervalTime = 5.0f;
    private float BackTrainRightIntervalTime = 7.0f;
    public Transform LeftTrainPlace2;
    public Transform RightTrainPlalce2;
    GameObject TrainPool;
    [SerializeField] private ObjectPool Pool;
    void Start()
    {
        Maneger = GetComponent<TrainManeger>();
        TrainPool = Pool.GetComponent<ObjectPool>().Get();
    }

    // Update is called once per frame
    void Update()
    {
        BackTrainLeftGenerateTime += Time.deltaTime;
        BackTrainRightGenerateTime += Time.deltaTime;

        BackGenerateTrain();
    }

    private void BackGenerateTrain()
    {
        if (BackTrainLeftGenerateTime > BackTrainLeftIntervalTime)
        {
            Debug.Log("後半の電車が生成されました");
             Maneger.SetTrainPostion(TrainPool, LeftTrainPlace2);
            BackTrainLeftIntervalTime = 0.0f;
        }

        if (BackTrainRightGenerateTime > BackTrainRightIntervalTime)
        {
            Maneger.SetTrainPostion(TrainPool, LeftTrainPlace2);
            BackTrainRightIntervalTime = 0.0f;
        }
    }

}
