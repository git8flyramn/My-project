using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ChangeDirection : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private BothTrainMove BothTrain;
    private RandomDropTrain RandomDrop;
    private Vector3 Dir = Vector3.forward;
    private Quaternion ChangeQuater = Quaternion.identity;
    void Start()
    {
        BothTrain = GetComponent<BothTrainMove>();
        RandomDrop = GetComponent<RandomDropTrain>();
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

            
            //車両のをQuaternion変更
            RandomDrop.ChangeQuaternion(ChangeQuater);
            //車両の進行方向を左から前に変更する
            BothTrain.ChangeVector(Dir);
            Debug.Log("電車の向きと進行方向が変更されました");

        }
        else
        {
            Debug.LogWarning("向きが変更されていません");
        }
    }
}
