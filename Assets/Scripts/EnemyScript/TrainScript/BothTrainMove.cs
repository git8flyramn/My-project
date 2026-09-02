using UnityEngine;
using Unity.VisualScripting;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
public class BothTrainMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

   
   
    
    //電車の動作に使用する変数
    private float MoveSpeed    = 4.0f;
    private float Initvelocity = 6.0f;
    [SerializeField] private Vector3 TrainDir;
    private Rigidbody rb;

    //矢印を点滅させるための宣言
    private GameObject LeftArrow;
  　private GameObject RightArrow;

    private Quaternion ForwardDir = Quaternion.identity;
    void Start()
    {
        Initlialize();
    }

    void Initlialize()
    {
        
       
        LeftArrow = GameObject.Find("LeftArrow");
        RightArrow = GameObject.Find("RightArrow");
    
    }

    public void TrainMove()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(TrainDir * Initvelocity * MoveSpeed);
    }

    //電車が方向を変更するポイントに到達したとき
    //車両の進行方向を左右方向それぞれから前方方向に変更
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("train"))
        {
            TrainDir = Vector3.forward;
            transform.rotation = ForwardDir;
            RightArrow.GetComponent<ArrowFlashing>().StopBlinking();
        }
        
        if (other.CompareTag("SecondTrain"))
        {
            TrainDir = Vector3.forward;
            transform.rotation = ForwardDir;
            LeftArrow.GetComponent<ArrowFlashing>().StopBlinking();
        }
    }

}
