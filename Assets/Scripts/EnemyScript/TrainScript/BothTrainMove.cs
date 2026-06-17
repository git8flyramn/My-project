using UnityEngine;
using Unity.VisualScripting;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
public class BothTrainMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

   
    private Rigidbody rb;
    //使用している変数
    private float MoveSpeed    = 4.0f;
    private float Initvelocity = 3.0f;
   
    [SerializeField] private Vector3 TrainDir;
    private GameObject LeftArrow;
  //  private GameObject RightArrow;
    private Quaternion ForwardDir = Quaternion.identity;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        LeftArrow = GameObject.Find("LeftArrow");
        //RightArrow = GameObject.Find("RightArrow");
    }

    // Update is called once per frame
    void Update()
    {

        LeftArrow.GetComponent<ArrowFlashing>().StartBlinking();
    }

    public void TrainMove()
    {
      
        rb.AddForce(TrainDir * MoveSpeed * Initvelocity);
    }
    public void OnTriggerEnter(Collider other)
    {
        //電車が方向を変更するポイントに到達したとき
        if (other.CompareTag("train"))
        {
            //車両の進行方向を左右方向それぞれから前方方向に変更
           
            TrainDir = Vector3.forward;
            transform.rotation = ForwardDir;
          
        }
      

        if (other.CompareTag("SecondTrain"))
        {
            TrainDir = Vector3.forward;
            transform.rotation = ForwardDir;
        }
       
    }
}
