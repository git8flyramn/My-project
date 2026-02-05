using UnityEngine;
using System.Collections;
using System.Collections.Generic;
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
        GenerateTime = Time.deltaTime;
        if(GenerateTime > 5)
        {
            Instantiate(Train, TrainPlace.position, Quaternion.identity);
        }
    }
}
