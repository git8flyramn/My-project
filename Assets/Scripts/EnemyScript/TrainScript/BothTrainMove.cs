using UnityEngine;
using Unity.VisualScripting;
using System.Collections;
using System.Collections.Generic;
using System.Data;
public class BothTrainMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

   
    private Rigidbody rb;

    //使用している変数
   private float MoveSpeed    = 3.0f;
   private float Initvelocity = 2.0f;

    private Vector3 TrainDir = Vector3.right;
    private Vector3 ForwardDir = Vector3.forward;
   // private float WaitTimer = 3.0f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TrainRightMove()
    {
       rb.AddForce(TrainDir * MoveSpeed * Initvelocity);
    }

    public void TrainLeftMove()
    {
       // rb.AddForce(TrainDir * Initvelocity * MoveSpeed, ForceMode.Acceleration);
    }

    public void OnTriggerEnter(Collider other)
    {
        //電車が方向を変更するポイントに到達したとき
        if (other.CompareTag("train"))
        {
            //車両の進行方向を左方向から前方向に変更する
            TrainDir = ForwardDir;
            //Quaternion.Euler(0, 135f, 0);
            transform.Rotate(0,135f,0);
            Debug.Log("進行方向が変更されました");
        }
        else
        {
            Debug.LogWarning("進行方向が変更されていません");
        }
    }
}
