using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
public class CheckTrain : MonoBehaviour
{
    private ArrowFlashing Arrow;
    private MaskableGraphic UIArrow;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Arrow = GetComponent<ArrowFlashing>();
        UIArrow = GetComponent<MaskableGraphic>();
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
            Arrow.BlinkArrow();

        }
    }

}
