using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class DashGauge : MonoBehaviour
{
    public Slider Gauge;
    private float CurrentStamina; // 動作の時に増減する
    private float MaxGauge = 10.0f; //最大値(これを超えたらこの値に固定する)
    private float MinGauge = 0.0f; //最小値
    private float DashSpeed = 0.0f;
    //private float adjustdecDash = 10.0f;
    private float adjustaddDash = 0.3f;
    // private float Addstamina = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentStamina = MaxGauge;
        if (Gauge != null)
        {
            Gauge.maxValue = MaxGauge;
            Gauge.value = CurrentStamina;
            StaminaUpdate();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }


    public void UseStamina(float dec)
    {
        CurrentStamina -= dec / 10;
         Debug.Log("スタミナ減少");
        CurrentStamina = Mathf.Clamp(CurrentStamina, MinGauge, MaxGauge);
        StaminaUpdate();

    }

    public void RegenerateStamina(float add)
    {
        CurrentStamina += add * adjustaddDash;
        CurrentStamina = Mathf.Clamp(CurrentStamina, MinGauge, MaxGauge);
        StaminaUpdate();
    }

    private void StaminaUpdate()
    {
        if (Gauge != null)
        {
            Gauge.value = CurrentStamina;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        /* playerがアイテムに触れたらアイテムを消滅させスタミナを回復する処理*/
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("スタミナが回復しました");
            Destroy(gameObject);
        }
    }

    public void SetDashSpeed(float speed)
    {
        DashSpeed = speed;
    }


}
