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
    [SerializeField] private Transform SecondTrainspawn;

    private PooledObject Train;
    [SerializeField] private ObjectPool Pool;
    private SEManeger SE;
    public AudioClip clip;
    private float TrainIntervalTime = 30.0f;
    private float TrainGenerateTime = 0.0f;
    private float SecondTrainGenerateTime = 0.0f;

    void Start()
    {
        Train = Pool.GetPooledObject();
        TrainGenerateTime += 1.0f;
        SecondTrainGenerateTime += 1.0f;
        Train.transform.position = Trainspawn.position;
        SE    = GetComponent<SEManeger>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TrainGenerateTime > 5)
        {
            Train.transform.position = Trainspawn.position;
            TrainGenerateTime = 0.0f;
        }
        if(SecondTrainGenerateTime > 10)
        {
            Train.transform.position = SecondTrainspawn.position;
            SecondTrainGenerateTime = 0.0f;
        }
        StartCoroutine(TrainReturn(Train));
    }

    //ëOîºïîï™ÇÃìdé‘ÇÃê∂ê¨
   

    IEnumerator TrainReturn(PooledObject enemy)
    {
        yield return new WaitForSeconds(TrainIntervalTime);
        enemy.Pool.ReturnToPool(enemy);
    }
}


