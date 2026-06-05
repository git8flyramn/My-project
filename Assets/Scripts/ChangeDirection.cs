using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ChangeDirection : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private BothTrainMove BothTrain;
    private Vector3 Dir = Vector3.zero;
    private Rigidbody rb;
    private float waitTime = 5.0f;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        BothTrain = GetComponent<BothTrainMove>();
    }

    public void OnTriggerEnter(Collider other)
    {
        //電車が方向を変更するポイントに到達したとき
        if (other.CompareTag("train"))
        {
            //ぶつかったらまず車両の向きが変更される
            transform.Rotate(new Vector3(0, 140, 0));
            //次に電車の進行方向を右方向から前方向に変更する
            StartCoroutine(ChangeVecTime());
            Debug.Log("電車の向きと進行方向が変更されました");
        }
        else
        {
            Debug.LogWarning("向きが変更されていません");
        }
    }

    IEnumerator ChangeVecTime()
    {
       
        BothTrain.ChangeRotation();
        yield return new WaitForSeconds(waitTime);
    }

   

   
   
}
