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
    private float FlashTime = 0.5f;
    private float FlashTimer = 0.0f;
    private float StopFlashTime = 3.0f;
    private Color color;
    private CanvasGroup canvas;
    void Start()
    {
        canvas = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void BlinkArrow()
    { 
       Alpha     = (Mathf.Sin(Time.time * FlashTime)) / 2.0f + 0.5f;
       color     = img.color;
       color.a   = Alpha;
       img.color = color;
    }

    public void StopBlinking()
    {
        Debug.Log("点滅を終了します");
        color = img.color;
        color.a = Alpha;
        img.color = color;
    }

    public void StartBlinking()
    {
        Debug.Log("点滅を開始します");
        StartCoroutine(BrinkingArrow());
    }

    IEnumerator BrinkingArrow()
    {
        while(FlashTimer < StopFlashTime)
        {
            canvas.alpha = (canvas.alpha == Alpha) ? 0f : Alpha;
            yield return new WaitForSeconds(FlashTime);
            FlashTimer += FlashTime;
        }

        canvas.alpha = Alpha;
    }
}
