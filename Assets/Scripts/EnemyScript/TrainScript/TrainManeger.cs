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
    public Transform LeftTrainPlace;
    public Transform RightTrainPlalce;
    private float TrainIntervalTime = 30.0f;
    void Start()
    {
        Train = Pool.GetPooledObject();
        Pool.SpawnObject(Trainspawn)
        SE    = GetComponent<SEManeger>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(TrainReturn(Train));
    }

    //ëOîºïîï™ÇÃìdé‘ÇÃê∂ê¨
   

    IEnumerator TrainReturn(PooledObject enemy)
    {
        yield return new WaitForSeconds(TrainIntervalTime);
        enemy.Pool.ReturnToPool(enemy);
        Pool.SpawnObject(SecondTrainspawn);
    }
}


