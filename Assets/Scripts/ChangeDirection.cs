using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ChangeDirection : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created  
    private Vector3 TrainDir = Vector3.right;
    private Vector3 ForwardDir = Vector3.forward;
    private RandomDropTrain DropTrain;
    void Start()
    {
        DropTrain = GetComponent<RandomDropTrain>();
    }

    // Update is called once per frame
    void Update()
    { 
    }
    public void OnTriggerEnter(Collider other)
    {
        //電車が方向を変更するポイントに到達したとき
        if (other.CompareTag("train"))
        {
            //車両の進行方向を左方向から前方向に変更する
            TrainDir = ForwardDir;

            //transform.Rotate(0, 135f, 0);
            DropTrain.ChangeDir();
            Debug.Log("進行方向が変更されました");
        }
        else
        {
            Debug.LogWarning("進行方向が変更されていません");
        }
    }







}
