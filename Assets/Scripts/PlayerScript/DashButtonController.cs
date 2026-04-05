using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.EventSystems;
public class DashButtonController : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    [SerializeField] ParticleSystem ParticleSystem;
    public DashGage Dash;
   
    private bool isLongTap = false;
    private float Taptime;
    public float LongTapTime = 3f;
    private float decStamina = 5.0f;
    private float defaultSpeed = 5.0f;//通常のスピード 
    private float dash = 15.0f;        //ダッシュ時のスピード
    private float ResetDefaultSpeed = 5.0f; //元のスピードに戻すため

    void Start()
    {
        Dash = GetComponent<DashGage>();
       
    }

    //ボタンの押し下げ
   public void OnPointerDown(PointerEventData eventData)
   {

        isLongTap = true;
        Debug.Log("Long Tap true");
        defaultSpeed = dash;
        Taptime = 0f;
       
    }

    //ボタンの押上
    public void OnPointerUp(PointerEventData eventData)
    {
        isLongTap = false;
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
                isLongTap = false;
                StartDash();
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
        defaultSpeed = ResetDefaultSpeed;
        // ParticleSystem.Stop();
        Debug.Log("元のスピード:" + defaultSpeed);   
    }
}
