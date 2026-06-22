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
    private float FlahingCycle = 1.0f; //点滅の周期サイクル時間
    private float DefaultAlpha;//元の色の値を保持する変数
    [SerializeField, Range(0, 1)] private float FlashRate = 0.5f; 
    void Start()
    {
        DefaultAlpha = img.color.a;
    }

    // Update is called once per frame
    private void Update()
    {
       
    }

    //点滅の機能
    private void BlinkArrow()
    {
     
            Timer += Time.deltaTime;
            img.enabled = !img.enabled;
            var ClycleRepeatValue = Mathf.Repeat(Timer, FlahingCycle);
            img.enabled = ClycleRepeatValue >= FlahingCycle * (1 - FlashRate);
        
      
    }

    //点滅の開始機能を呼び出す関数
    public void StartBlinking()
    {
      
        BlinkArrow();
    }

    //点滅の終了関数
    public void StopBlinking()
    {
        SetAlpha();
    }
    
   //停止させた後に元の色に戻すための関数
    private void SetAlpha()
    {
        StartCoroutine(SetAlphaTime(DefaultAlpha));
    }

    private IEnumerator SetAlphaTime(float alpha)
    {
        
        var color = img.color;
        color.a = alpha;
        img.color = color;
        Debug.Log("元に戻りました");
        img.enabled = true;
        yield return new WaitForSeconds(0.5f);
    }
}
