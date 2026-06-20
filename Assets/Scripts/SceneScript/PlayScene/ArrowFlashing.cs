using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Rendering;
using System.Threading;
public class ArrowFlashing : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   [SerializeField] private Image img;
   // private float Alpha = 0.0f;
    private Color color;
    private float Timer;
    private float FlahingCycle = 1.0f;
    [SerializeField, Range(0, 1)] private float FlashRate = 0.5f; 
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
 
    }

    private void BlinkArrow()
    {
        Timer += Time.deltaTime;
        var ClycleRepeatValue = Mathf.Repeat(Timer, FlahingCycle);
        img.enabled = ClycleRepeatValue >= FlahingCycle * (1 - FlashRate);
    }

    public void StopBlinking()
    {
        //Debug.Log("点滅を終了します");
        //color = img.color;
        //color.a = Alpha;
        //img.color = color;
        img.enabled = false;
    }

    public void StartBlinking()
    {
       //Debug.Log("点滅を開始します");
        BlinkArrow();
    }


}
