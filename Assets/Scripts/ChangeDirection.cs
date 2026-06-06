using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ChangeDirection : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private BothTrainMove BothTrain;
    private RandomDropTrain DropTrain;
    private Vector3 Dir = Vector3.forward;
    public Transform target;
    // private float waittime = 3.0f;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        BothTrain = GetComponent<BothTrainMove>();
        DropTrain = GetComponent<RandomDropTrain>();
    }

    public void OnTriggerEnter(Collider other)
    {
        //電車が方向を変更するポイントに到達したとき
        if (other.CompareTag("train"))
        {
            //車両のをQuaternion変更
            //車両の進行方向を左から前に変更する
            DropTrain.ChangeRotaion();
            Debug.Log("電車の向きが変更されました");
        }
        else
        {
            Debug.LogWarning("向きが変更されていません");
        }
    }

  

   

   
   
}
