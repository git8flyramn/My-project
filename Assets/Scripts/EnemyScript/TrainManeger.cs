using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Pool;
using System.Runtime.CompilerServices;
public class TrainManeger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    
    public GameObject Train;
    public Transform TrainPlace;
    [SerializeField] private ObjectPool Pool;
    private float TimeCount =  0.0f;
  //  private float DestroyTime = 0.0f;
    private float GenerateTime = 5.0f;
    //Disappear
  //  private float DisappearPosition =  -30.0f;
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
        if (TimeCount > GenerateTime)
        {
            GameObject train = Pool.GetComponent<ObjectPool>().Get();
            train.transform.position = TrainPlace.transform.position;
            train.transform.rotation = Quaternion.identity;
            TimeCount = 0.0f;
        }
        else if(TimeCount == 0.0f)
        {
            Debug.Log("ìdé‘Ç™è¡ñ≈ÇµÇ‹Ç∑");
            Pool.GetComponent<ObjectPool>().Release(Train);
          
        }


       
        





        //TimeCount += Time.deltaTime;
        //if (TimeCount > GenerateTime)
        //{
        //    train.transform.position = TrainPlace.position;
        //    ///Instantiate(Train, TrainPlace.position, Quaternion.identity);
        //    train.transform.rotation = Quaternion.identity;
        //    Debug.Log(Train == null ? "currentTrain is NULL" : "currentTrain OK");
        //    if (train == null)
        //    {
        //        Debug.LogWarning("ÉvÅ[ÉãÇ©ÇÁéÊìæÇµÇΩtrainÇ™nullÇ≈Ç∑");
        //    }
        //    TimeCount = 0.0f;
        //    DestroyTime += 0.5f;
        //    if (DestroyTime > 15.0f)
        //    {
        //        Pool.GetComponent<ObjectPool>().Release(train);
        //       
        //    }

        //}
    }
  
}


