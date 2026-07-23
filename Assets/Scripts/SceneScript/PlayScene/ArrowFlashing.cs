using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Threading;
public class ArrowFlashing : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   [SerializeField] private Image img; //画像のデータ
    private float FlahingCycle = 1.0f; //点滅の周期サイクル時間
    private Color color;
    [SerializeField, Range(0, 1)] private float FlashRate = 0.5f;　//点滅の間隔
    private Coroutine BlinkRoutine;
    private float StartRate = 0.0f;
    private SEManeger SE;
    public AudioClip clip;
    void Start()
    {
        SE = GetComponent<SEManeger>();
    }

    // Update is called once per frame
    private void Update()
    { 
    }

    //点滅機能
    private void BlinkArrow()
    {
        var ClycleRepeatValue = Mathf.Repeat(Time.time, FlahingCycle);
        StartRate = FlahingCycle * (1 - FlashRate);
        img.enabled = ClycleRepeatValue >= StartRate;
    }

    //点滅の開始機能
    public void StartBlinking()
    {
        if(BlinkRoutine != null)
        {
            StopCoroutine(BlinkRoutine);
        }
        BlinkRoutine = StartCoroutine(BlinkingArrow());
       

    }
    //点滅の終了関数
    public void StopBlinking()
    {
        if (BlinkRoutine != null)
        {
            StopCoroutine(BlinkRoutine);
        }
        img.enabled = true;
        BlinkRoutine = null;
    }

    //矢印の点滅コルーチン
    private IEnumerator BlinkingArrow()
    {
        while(true)
        {
            BlinkArrow();
            SE.BlinkerSE(clip);
            yield return null;
        }
       
    }

}
