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
    private float MoveSpeed    = 2.0f;
    private float Initvelocity = 3.0f;
    private float FlashTime = 3.0f;
    private float FlashTimer = 0.0f;
    [SerializeField] private Vector3 TrainDir;
    private GameObject LeftArrow;
  //  private GameObject RightArrow;
    private Quaternion ForwardDir = Quaternion.identity;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        LeftArrow = GameObject.Find("LeftArrow");
       // RightArrow = GameObject.Find("RightArrow");

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
            StartCoroutine(LeftArrowBlinkIntervalTime());
            TrainDir = Vector3.forward;
            transform.rotation = ForwardDir;
            
        }
        else
        {
            Debug.LogWarning("進行方向が変更されていません");
        }

        if(other.CompareTag("SecondTrain"))
        {
            TrainDir = Vector3.forward;
            transform.rotation = ForwardDir;
            StartCoroutine(RightArrowBlinkIntervalTime());
        }
        else
        {
            Debug.LogWarning("二台目の電車の進行方向が変更されていません");
        }
    }

    IEnumerator LeftArrowBlinkIntervalTime()
    {
        if(FlashTimer < FlashTime)
        {
            LeftArrow.GetComponent<ArrowFlashing>().StartBlinking();
            FlashTimer += Time.deltaTime;
            yield return null;
        }
        FlashTimer = 0.0f;
        LeftArrow.GetComponent<ArrowFlashing>().StopBlinking();
    }
    IEnumerator RightArrowBlinkIntervalTime()
    {
        yield return new WaitForSeconds(0.2f);
        // RightArrow.GetComponent<ArrowFlashing>().StartBlinking();
        yield return new WaitForSeconds(2.0f);
        // RightArrow.GetComponent<ArrowFlashing>().StopBlinking();
    }
}
