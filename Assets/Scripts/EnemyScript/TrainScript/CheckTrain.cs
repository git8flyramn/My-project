using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;

public class CheckTrain : MonoBehaviour
{
    private ArrowFlashing Arrow;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Arrow = GetComponent<ArrowFlashing>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("train"))
        {
            Debug.Log("もうすぐ電車がまいります");
            Arrow.StartBlinkArrow();

        }
    }

}
