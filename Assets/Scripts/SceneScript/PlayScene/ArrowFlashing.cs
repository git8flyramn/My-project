using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEditor.Experimental.GraphView;
public class ArrowFlashing : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   [SerializeField] private Image img;
    private float Alpha = 1.0f;
    private float FlashTimer = 0.0f;
    private float FlashTime = 5.0f;
    private Color color;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
       
    }

    private void BlinkArrow()
    { 
        while(FlashTimer < FlashTime)
        {
            Alpha = (Mathf.Sin(Time.time * 0.5f)) / 2.0f + 0.5f;
            color = img.color;
            color.a = Alpha;
            img.color = color;
            FlashTimer += 1.0f;
        }
       // StopBlinking();
    }

    public void StopBlinking()
    {
        Debug.Log("点滅を終了します");
        color = img.color;
        color.a = Alpha;
        img.color = color;
        FlashTimer = 0.0f;
    }

    public void StartBlinking()
    {
        Debug.Log("点滅を開始します");
        BlinkArrow();
    }


}
