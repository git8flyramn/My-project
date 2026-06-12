using UnityEngine;
using Unity.VisualScripting;
using System.Collections;
using System.Collections.Generic;
public class ChangeDirection : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created  
    //private Vector3 TrainDir = Vector3.right;
   // private Vector3 ForwardDir = Vector3.forward;
    private RandomDropTrain DropTrain;
    void Start()
    {
        DropTrain = GetComponent<RandomDropTrain>();
    }

    // Update is called once per frame
    void Update()
    { 
    }
    





}
