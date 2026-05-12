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
        GameObject train = Pool.GetComponent<ObjectPool>().Get();
        if (TimeCount > GenerateTime)
        {
            Debug.Log("ìdé‘ÇÃê∂ê¨");
            
            train.transform.position = TrainPlace.transform.position;
            train.transform.rotation = Quaternion.identity;
            TimeCount = 0.0f;
        }

        if (Timeinterval > GenerateTime)
        {
            // Debug.Log("2Ç¬ñ⁄ÇÃìdé‘ê∂ê¨");
            //Instantiate(SecondTrain, SecondTrainPlace.position, Quaternion.identity);
            Debug.Log("2Ç¬ñ⁄ÇÃìdé‘ê∂ê¨");
            train.transform.position = SecondTrainPlace.transform.position;
            train.transform.rotation = Quaternion.identity;
            Timeinterval = 0.0f;
        }
      
    }
  
}


