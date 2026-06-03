using UnityEngine;
using Unity.VisualScripting;
using System.Collections;
using System.Collections.Generic;
using System.Data;

public class BothTrainMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

   
    private Rigidbody rb;
    public RandomDropTrain RandomTrain;
    GameObject obj;

    //使用している変数
    private float MoveSpeed    = 3.0f;
    private float Initvelocity = 2.0f;

    public Vector3 TrainDir = Vector3.zero;
    private Quaternion ChangeQuater = Quaternion.identity;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        RandomTrain = GetComponent<RandomDropTrain>();
        obj = GameObject.Find("ThirdTrain");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TrainRightMove()
    {
        TrainDir = Vector3.right;
        rb.AddForce(TrainDir * Initvelocity * MoveSpeed, ForceMode.Acceleration);
    }

    public void TrainLeftMove()
    {
        TrainDir = Vector3.left;
       // rb.AddForce(TrainDir * Initvelocity * MoveSpeed, ForceMode.Acceleration);
    }

   public void ChangeRotation()
    {
        obj.transform.rotation = Quaternion.identity;
    }


}
