using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LeftDropTrain : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private RandomDropTrain DropTrain;

    void Start()
    {
        DropTrain = new RandomDropTrain();
    }

    // Update is called once per frame
    void Update()
    {
       // DropTrain.DropLeftForwardTrain();
    }
}
