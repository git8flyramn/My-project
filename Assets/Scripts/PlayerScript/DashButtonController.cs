using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine.EventSystems;
public class DashButtonController : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    [SerializeField] ParticleSystem ParticleSystem;
    public DashGauge Dash;
    private bool isLongTap = false;
    private float Taptime;
    public float LongTapTime = 1f;
    private float decStamina = 5.0f;
    private float defaultSpeed = 20.0f;//通常のスピード 
    public float dashspeed = 40.0f;        //ダッシュ時のスピード
    private float ResetDefaultSpeed = 20.0f; //元のスピードに戻すため
    public StickController Sc;
    void Start()
    {
        Dash = GetComponent<DashGauge>();
      
    }
      

    //ボタンの押し下げ
   public void OnPointerDown(PointerEventData eventData)
   {

        isLongTap = true;
        if(Sc != null)
        {
            Sc.dash = dashspeed;
        }
        Debug.Log("Long Tap true");
   }

    //ボタンの押上
    public void OnPointerUp(PointerEventData eventData)
    {
        isLongTap = false;
        if (Sc != null)
        {
            Sc.dash = ResetDefaultSpeed;
        }
        Debug.Log("Long Tap false");
        StopDash();
    }

    private void Update()
    {
       
        if (isLongTap)
        {
            Taptime += Time.deltaTime;
            //ボタンを長押ししている間
            if (Taptime <= LongTapTime)
            {
                Debug.Log("Long Tap");
                StartDash();
                isLongTap = false;
            }
        }
       
    }


    //長押しの間ダッシュ
    private void StartDash()
    {
        Dash.UseStamina(decStamina);
        Dash.SetDashSpeed(dashspeed);
        ParticleSystem.Play();
        Debug.Log("ダッシュエフェクト再生");
        Debug.Log("ダッシュスピード:" + dashspeed);
    }

    private void StopDash()
    {
        Debug.Log("ダッシュエフェクト停止");
        ParticleSystem.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        defaultSpeed = ResetDefaultSpeed;
        // ParticleSystem.Stop();
        Debug.Log("元のスピード:" + defaultSpeed);   
    }


}
