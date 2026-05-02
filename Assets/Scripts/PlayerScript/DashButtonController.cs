using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine.EventSystems;
public class DashButtonController : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
   

    [SerializeField] ParticleSystem ParticleSystem;
    public DashGauge Dash;
    private bool isLongTap = false;
    private float Taptime;
    public float LongTapTime = 2.0f; //長押しをしている時間
    private float decStamina = 0.1f;
    private float defaultSpeed = 15.0f;//通常のスピード 
    public float dashspeed = 25.0f;        //ダッシュ時のスピード
  //  private float ResetDefaultSpeed = 15.0f; //元のスピードに戻すため
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
            
           
            Sc.dash = dashspeed;
            Debug.Log("Long Tap true");
            
        }
      
   }

    //ボタンの押上
    public void OnPointerUp(PointerEventData eventData)
    {

        isLongTap = false;
        if (Sc != null)
        {
            Debug.Log("Long Tap false");
            
            Sc.dash = defaultSpeed; 
           
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
                StartDash();
                Taptime = 0.0f;
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
       // Debug.Log("ダッシュスピード:" + dashspeed);
    }

    private void StopDash()
    {
       
        Debug.Log("ダッシュエフェクト停止");
        // ParticleSystem.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        //  ParticleSystem.Stop();
        //Debug.Log("元のスピード:" + defaultSpeed);   
    }


}
