using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEditor.Experimental.GraphView;
public class ArrowFlashing : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //SerializeField


   [SerializeField] private Image img;
    private float Alpha = 0.0f;
    private int FlashTime = 10;
    private Color color;
    private bool isBlinking = false;
    void Start()
    {
      
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void BlinkArrow()
    {
        if (isBlinking == true)
        {
            Alpha = (Mathf.Sin(Time.time * FlashTime)) / 2.0f + 0.5f;
            color = img.color;
            color.a = Alpha;
            img.color = color;

        }

    }

    public void StopBlinking()
    {
        Debug.Log("点滅を終了します");
        color = img.color;
        color.a = Alpha;
        img.color = color;
        isBlinking = false;
       
    }

    public void StartBlinking()
    {
        Debug.Log("点滅を開始します");
        isBlinking = true;
        BlinkArrow();
    }

    
}
