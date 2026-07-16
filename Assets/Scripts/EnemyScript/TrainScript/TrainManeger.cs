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
    private PooledObject SecondTrain;
    [SerializeField] private ObjectPool Pool;
    private SEManeger SE;
    public AudioClip clip;
    private float TrainIntervalTime = 5.0f;
    private float TrainGenerateTime = 0.0f;
    private float SecondTrainGenerateTime = 0.0f;

    void Start()
    {
        Train = Pool.GetPooledObject();
        TrainGenerateTime += 1.0f;
        SecondTrainGenerateTime += 1.0f;
      
       
        SE    = GetComponent<SEManeger>();
    }

    // Update is called once per frame
    void Update()
    {
        TrainGenerate();
    }

    //ëOîºïîï™ÇÃìdé‘ÇÃê∂ê¨
   void TrainGenerate()
    { 
            StartCoroutine(TrainReturn(Train));  
   }

    IEnumerator TrainReturn(PooledObject enemy)
    {
        yield return new WaitForSeconds(TrainIntervalTime);
        enemy.Pool.ReturnToPool(enemy);
        Debug.Log("ï‘ãpÇ≥ÇÍÇ‹ÇµÇΩ");
    }
}


