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
    private Color color;
    private float FlashTimer = 0.0f;
    private float FlashCycle = 5.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void BlinkArrow()
    {
        FlashTimer *= 3.0f; 
        var repeatValue = Mathf.Repeat(FlashTimer, FlashCycle);
        img.color = new Color(img.color.r, img.color.g, img.color.b, repeatValue);
    }

    public void StopBlinking()
    {
        Debug.Log("点滅を終了します");
        color = img.color;
        color.a = Alpha;
        img.color = new Color(img.color.r, img.color.g, img.color.b);
      //  img.enabled = false;

    }

    public void StartBlinking()
    {
        Debug.Log("点滅を開始します");
        BlinkArrow();
    }

    /*
      Alpha = Mathf.Sin(Time.time / 20.0f) / 2.0f + 0.5f;
      color = img.color;
      color.a = Alpha;
      img.color = color;
     
     */
}
