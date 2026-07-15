using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.SceneManagement;
public class TrainManeger : MonoBehaviour
{
    
    public GameObject FrontTrain;
    // private GameObject TrainPool;
    [SerializeField] private Transform Trainspawn;
    private PooledObject Train;
    [SerializeField] private ObjectPool Pool;
    private SEManeger SE;
    public AudioClip clip;
    public Transform LeftTrainPlace;
    public Transform RightTrainPlalce;
    private float TrainIntervalTime = 3.0f;
    
    ////電車の生成時間のカウント
    //private float TrainLeftGenerateTime = 0.0f;
    //private float TrainRightGenerateTime = 0.0f;
   
    ////電車の生成間隔
    //private float TrainLeftIntervalTime  = 6.0f;
    //private float TrainRightIntervalTime = 9.0f;

    void Start()
    {
        Train = Pool.GetPooledObject();
        Train.transform.position = Trainspawn.position;
        SE 　　　　= GetComponent<SEManeger>();
    }

    // Update is called once per frame
    void Update()
    {

        //TrainLeftGenerateTime  += Time.deltaTime;
        //TrainRightGenerateTime += Time.deltaTime;
        StartCoroutine(TrainReturn(Train));
    }

    //前半部分の電車の生成
   

    IEnumerator TrainReturn(PooledObject enemy)
    {
        yield return new WaitForSeconds(TrainIntervalTime);
        enemy.Pool.ReturnToPool(enemy);
    }
}


