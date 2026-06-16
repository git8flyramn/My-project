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
    void Start()
    {
      
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void BlinkArrow()
    {
       
            Alpha = (Mathf.Sin(Time.time * FlashTime)) / 2.0f + 0.5f;
            color = img.color;
            color.a = Alpha;
            img.color = color;
        
    }

    public void StopBlinking()
    { 
        color = img.color;
        color.a = 2.0f;
        img.color = color;
        Debug.Log("ì_ñ≈ÇèIóπÇµÇ‹Ç∑");
    }

    public void StartBlinking()
    {
        BlinkArrow();
    }

    
}
