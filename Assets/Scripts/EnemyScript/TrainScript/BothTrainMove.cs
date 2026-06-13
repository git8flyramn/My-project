using UnityEngine;
using Unity.VisualScripting;
using System.Collections;
using System.Collections.Generic;
using System.Data;
public class BothTrainMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

   
    private Rigidbody rb;
    private ArrowFlashing arrowflash;
    //使用している変数
    private float MoveSpeed       = 3.0f;
    private float Initvelocity    = 2.0f;
    [SerializeField]private Vector3 TrainDir;
    private Quaternion ForwardDir = Quaternion.identity;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        arrowflash = GetComponent<ArrowFlashing>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
            TrainDir = Vector3.forward;
            transform.rotation = ForwardDir;
            IntervalBlink();
        }
        else
        {
            Debug.LogWarning("進行方向が変更されていません");
        }
    }

    IEnumerator IntervalBlink()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("点滅を開始します");
        arrowflash.StartBlinking();
    }
}
