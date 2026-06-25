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
    private float Timer = 3.0f;
    private float FlahingCycle = 1.0f; //点滅の周期サイクル時間
    private Color color;
    //[SerializeField, Range(0, 1)] private float FlashRate = 0.5f; 
    void Start()
    {
      //  DefaultAlpha = img.color.a;
    }

    // Update is called once per frame
    private void Update()
    { 
    }

    //点滅の機能
    private void BlinkArrow()
    {
        //Timer += Time.deltaTime;
        //var ClycleRepeatValue = Mathf.Repeat(Timer, FlahingCycle);
        //img.enabled = ClycleRepeatValue >= FlahingCycle * (1 - FlashRate);
        Timer = Mathf.PingPong(Time.time, FlahingCycle);
        color = img.color;
        color.a = Timer;
        img.color = color;
    }

    //点滅の開始機能を呼び出す関数
    public void StartBlinking()
    {
      //StartCoroutine
        StartCoroutine(BlinkingArrow());
    }

    //点滅の終了関数
    public void StopBlinking()
    {
        StopCoroutine(BlinkingArrow());
        img.enabled = true;
    }
    
    private IEnumerator BlinkingArrow()
    {
        BlinkArrow();
        img.enabled = !img.enabled;
        yield return new WaitForSeconds(2.0f);
    }
}
