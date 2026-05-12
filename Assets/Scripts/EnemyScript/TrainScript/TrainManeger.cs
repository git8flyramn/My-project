using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Pool;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
public class TrainManeger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject Train;
    public GameObject SecondTrain;
    public Transform TrainPlace;
   
    public Transform SecondTrainPlace;
    [SerializeField] private ObjectPool Pool;
    private float TimeCount =  0.0f;
    private float Timeinterval = 0.0f;
    private float GenerateTime = 5.0f;
    void Start()
    {
     
       
    }

    // Update is called once per frame
    void Update()
    {
       
        TrainMove();
    }

    void TrainMove()
    {
        TimeCount += Time.deltaTime;
        Timeinterval += Time.deltaTime;
      
        if (TimeCount > GenerateTime)
        {
            Debug.Log("“dÔ‚Ì¶¬");
            GameObject train = Pool.GetComponent<ObjectPool>().Get();
            train.transform.rotation = Quaternion.identity;
            train.transform.position = TrainPlace.transform.position;
            TimeCount = 0.0f;
           
        }

        if (Timeinterval > GenerateTime)
        {
            Debug.Log("2‚Â–Ú‚Ì“dÔ¶¬");
            GameObject train = Pool.GetComponent<ObjectPool>().Get();
            train.transform.rotation = Quaternion.identity;
            train.transform.position = SecondTrainPlace.transform.position;
            Timeinterval = 0.0f;
        }
      
    }
  
}


