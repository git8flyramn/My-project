using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class DashController : MonoBehaviour
{
    public Slider DashGage;
    private float CurrentStamina; // 動作の時に増減する
    private float MaxDash = 10.0f; //最大値(これを超えたらこの値に固定する)
    private float MinDash = 0.0f; //最小値
    private float adjustdecDash = 10.0f;
    private float adjustaddDash = 1.1f;
    // private float Addstamina = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentStamina = MaxDash;
        if (DashGage != null)
        {
            DashGage.maxValue = MaxDash;
            DashGage.value = CurrentStamina;
            StaminaUpdate();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }


    public void UseStamina(float dec)
    {
        CurrentStamina -= dec / adjustdecDash;
         Debug.Log("スタミナ減少");
        CurrentStamina = Mathf.Clamp(CurrentStamina, MinDash, MaxDash);
        StaminaUpdate();

    }

    public void RegenerateStamina(float add)
    {
        CurrentStamina += add * adjustaddDash;
        CurrentStamina = Mathf.Clamp(CurrentStamina, MinDash, MaxDash);
        StaminaUpdate();
    }

    private void StaminaUpdate()
    {
        if (DashGage != null)
        {
            DashGage.value = CurrentStamina;
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

}
