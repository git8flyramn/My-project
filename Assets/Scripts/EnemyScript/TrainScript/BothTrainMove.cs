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
    private float MoveSpeed       = 3.0f;
    private float Initvelocity    = 3.0f;
    [SerializeField] private Vector3 TrainDir;
    private GameObject LeftArrow;


    private Quaternion ForwardDir = Quaternion.identity;
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
       

    }

    // Update is called once per frame
    void Update()
    {
        LeftArrow = GameObject.Find("LeftArrow");
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
            //車両の進行方向を左方向から前方向に変更

            LeftArrow = GameObject.Find("LeftArrow");
            LeftArrow.GetComponent<ArrowFlashing>().StopBlinking();
            StartCoroutine(TrainDirectionChange());

        }
        else
        {
            Debug.LogWarning("進行方向が変更されていません");
        }
    }

    IEnumerator TrainDirectionChange()
    {
        TrainDir = Vector3.forward;
        transform.rotation = ForwardDir;
        yield return new WaitForSeconds(0.1f);
       
    }
}
