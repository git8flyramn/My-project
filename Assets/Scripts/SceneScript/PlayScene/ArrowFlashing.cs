using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class ArrowFlashing : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //SerializeField


   [SerializeField] private Image img;
    private float Alpha = 0.0f;
    private int 
    void Start()
    {
      
    }

    // Update is called once per frame
    private void Update()
    {
        StartBlinking();
    }

    private void BlinkArrow()
    {
        Alpha = (Mathf.Sin(Time.time * 10)) / 2.0f + 0.5f;

        Color color = img.color;
        color.a = Alpha;
        img.color = color;
    }

    public void StopBlinking()
    {
    }

    public void StartBlinking()
    {
        //isBlinking = true;
        Debug.Log("–îˆó‚Ì“_–Å’†");
        BlinkArrow();
    }

    
}
