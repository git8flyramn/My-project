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
    private float BlinkTime = 3.0f;
    private float BlinkTimer = 0.0f;
    void Start()
    {
      
    }

    // Update is called once per frame
    private void Update()
    {
        BlinkTimer += Time.deltaTime;
    }

    private void BlinkArrow()
    {
       if(BlinkTime < BlinkTimer)
        {
            Alpha = (Mathf.Sin(Time.time * FlashTime)) / 2.0f + 0.5f;
            color = img.color;
            color.a = Alpha;
            img.color = color;
        }
        else
        {
            StopBlinking();
        }
       
    }

    public void StopBlinking()
    { 
        color = img.color;
        color.a = 1.0f;
        img.color = color;
        Debug.Log("–îˆó‚Ì“_–Å‚ðI—¹‚µ‚Ü‚·");
    }

    public void StartBlinking()
    {
        BlinkArrow();
    }

    
}
