using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine.EventSystems;
public class DashButtonController : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
   

   
    public DashGauge Dash;
    private bool isLongTap = true;
    private float Taptime;
    public float LongTapTime = 2.0f; //長押しをしている時間
    private float decStamina = 0.01f;
    //private float RegeneStamina = 0.01f;
    private float defaultSpeed = 30.0f;//通常のスピード 
    public float dashspeed = 35.0f;        //ダッシュ時のスピード
    public StickController Sc;
    void Start()
    {
        Dash = GetComponent<DashGauge>();
      
    }
      

    //ボタンの押し下げ
   public void OnPointerDown(PointerEventData eventData)
   {
        isLongTap = true;
        if (Sc != null)
        {
            Sc.dash = defaultSpeed;
            StartDash();
            Dash.UseStamina(decStamina);
            // Debug.Log("ボタンを長押していません");

        }
      
   }

    //ボタンの押上
    public void OnPointerUp(PointerEventData eventData)
    {

        isLongTap = false;
        if (Sc != null)
        {
           
            StopDash();
            //defaultSpeed
            Sc.dash = dashspeed;
           
            // Debug.Log("ボタンを長押しています");

        }
      
       
    }

    private void Update()
    {

        if (isLongTap)
        {
            Taptime += Time.deltaTime;

            //ボタンを長押ししている間
            //(押し続けている時間が長押しの判定より長かったらスタミナが減る)
            if (Taptime >= LongTapTime)
            {
                Debug.Log("Long Tap");

                Taptime = 0.0f;
                isLongTap = false;

            }

        }
    }


    //長押しの間ダッシュ
    private void StartDash()
    {
      
        Dash.SetDashSpeed(dashspeed);
        Debug.Log("ダッシュエフェクト再生");
      // Debug.Log("ダッシュスピード:" + dashspeed);
    }

    private void StopDash()
    {
       
        Debug.Log("ダッシュエフェクト停止");
       
        // ParticleSystem.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        //  
        // Debug.Log("元のスピード:" + defaultSpeed);   
    }


}
