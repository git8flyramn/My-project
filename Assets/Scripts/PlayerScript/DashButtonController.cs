using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.EventSystems;
public class DashButtonController : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    [SerializeField] ParticleSystem ParticleSystem;
    public DashController Dash;
    private bool isLongTap = false;
    private float Taptime;
    public float LongTapTime = 1f;
    private float decStamina = 5.0f;
    private float defaultSpeed = 10.0f;//通常のスピード 
    private float dash = 15.0f;        //ダッシュ時のスピード
    private float ResetDefaultSpeed = 10.0f; //元のスピードに戻すため

    void Start()
    {
        Dash = GetComponent<DashController>();
    }

    //ボタンの押し下げ
   public void OnPointerDown(PointerEventData eventData)
   {
        isLongTap = true;
        Taptime = 0f;
   }

    //ボタンの押上
    public void OnPointerUp(PointerEventData eventData)
    {
        isLongTap = false;
        StopDash();
    }

    private void Update()
    {
        if(isLongTap)
        {

            Taptime += Time.deltaTime;
            
            //ボタンを長押ししている間
            if (Taptime >= LongTapTime)
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
      ParticleSystem.Play();
      Debug.Log("ダッシュエフェクト再生");
      defaultSpeed = dash;
      Debug.Log("ダッシュの速さ:" + defaultSpeed);
    }

    private void StopDash()
    {
      Debug.Log("ダッシュエフェクト停止");
      ParticleSystem.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
      // ParticleSystem.Stop();
      defaultSpeed = ResetDefaultSpeed;
      Debug.Log("ダッシュの速さ:" + defaultSpeed);   
    }
}
