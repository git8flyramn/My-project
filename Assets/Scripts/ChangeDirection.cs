using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ChangeDirection : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private BothTrainMove BothTrain;
    private Vector3 Dir = Vector3.forward;
    private Rigidbody rb;
    private float ChangeTime = 3.0f;

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
            //車両のをQuaternion変更
            //車両の進行方向を左から前に変更する
            transform.Rotate(new Vector3(0, 135, 0));
            StartCoroutine(ChangeRotationWait());
            BothTrain.ChangeRotation(Dir);
            Debug.Log("電車の向きと進行方向が変更されました");

        }
        else
        {
            Debug.LogWarning("向きが変更されていません");
        }
    }

    IEnumerator ChangeRotationWait()
    {
        yield return new WaitForSeconds(ChangeTime);
    }

   
   
}
