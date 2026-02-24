using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Pool;
public class TrainManeger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    
    public GameObject Train;
    public Transform TrainPlace;
    [SerializeField] private GameObject TrainPool;
    private float TimeCount =  0.0f;
    private float GenerateTime = 10.0f;
    void Start()
    { 

    }

    // Update is called once per frame
    void Update()
    {
        TrainMove();
    }

    public void TrainMove()
    {
        TimeCount += Time.deltaTime;
        if (TimeCount > GenerateTime)
        {
            //Debug.Log(Train == null ? "currentTrain is NULL" : "currentTrain OK");            
            GameObject train = TrainPool.GetComponent<ObjectPool>().Get();
             
            if(train == null)
            {
                Debug.LogWarning("ƒv[ƒ‹‚©‚çæ“¾‚µ‚½train‚ªnull‚Å‚·");
            }

            //train.transform.position = TrainPlace.position;
            //train.transform.rotation = Quaternion.identity;
            Debug.Log("“dÔ‚ª¶¬‚³‚ê‚Ü‚µ‚½");
            
            GenerateTime = 0;
        }
    }

}
