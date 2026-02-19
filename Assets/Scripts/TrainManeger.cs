using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Pool;
public class TrainManeger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

   

    public GameObject Train;
    public Transform TrainPlace;

    float GenerateTime;
    void Start()
    {
        GenerateTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GenerateTime += Time.deltaTime;
        if(GenerateTime > 10)
        {
            Debug.Log("ìdé‘Ç™ê∂ê¨Ç≥ÇÍÇ‹ÇµÇΩ");
            Instantiate(Train, TrainPlace.position, Quaternion.identity);
            GenerateTime = 0;
        }
        else
        {
            Debug.LogWarning("ìdé‘Ç™ê∂ê¨Ç≥ÇÍÇ‹ÇπÇÒ");
        }
    }

}
