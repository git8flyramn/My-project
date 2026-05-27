using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class RightSideTrainMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody rb;
    private BothTrainMove BothTrain;
    private float ChangeTime = 5.0f;
    private float TurnMoveTime = 0.0f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        BothTrain = GetComponent<BothTrainMove>();
        
    }

// Update is called once per frame
    void Update()
    {
        TurnMoveTime += Time.deltaTime;
        BothTrain.TrainRightMove();
        if( TurnMoveTime > 15)
        {
            StartCoroutine(ChangeMoveTime());
            BothTrain.TrainLeftMove();
            TurnMoveTime = 0.0f;
        }
             
    }

    IEnumerator ChangeMoveTime()
    {
        yield return new WaitForSeconds(ChangeTime);
    }



}
