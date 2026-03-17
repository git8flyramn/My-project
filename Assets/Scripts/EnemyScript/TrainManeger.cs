using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Pool;
using System.Runtime.CompilerServices;
public class TrainManeger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    
    public GameObject Train;
    public GameObject SecondTrain;
    public Transform TrainPlace;
    public int MaxTrain;
    public Transform SecondTrainPlace;
    [SerializeField] private ObjectPool Pool;
    private float TimeCount =  0.0f;
    private float GenerateTime = 5.0f;
    void Start()
    {
        MaxTrain = Pool.GetComponent<ObjectPool>().GetTrainNum();
       
    }

    // Update is called once per frame
    void Update()
    {
        TrainMove();
    }

    void TrainMove()
    {
        TimeCount += Time.deltaTime;
       
        if (TimeCount > GenerateTime)
        {
            Debug.Log("ìdé‘ÇÃê∂ê¨");
            Instantiate(Train, SecondTrainPlace.position, Quaternion.identity);
            GameObject train = Pool.GetComponent<ObjectPool>().Get();
            train.transform.position = TrainPlace.transform.position;
            train.transform.rotation = Quaternion.identity;
            TimeCount = 0.0f;
        }
      
    }
  
}


