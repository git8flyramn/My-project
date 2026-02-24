using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class StaminaController : MonoBehaviour
{
    public Slider DashGage;
    private float CurrentStamina; // 動作の時に増減する
    private float MaxStamina = 10.0f; //最大値(これを超えたらこの値に固定する)
    private float MinStamina = 0.0f; //最小値
    private float Decstamina = 0.5f; //スタミナの減る量
    private float adjustStamina = 10.0f;
  //  private float Addstamina = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentStamina = MaxStamina;
        if(DashGage != null)
        {
            DashGage.maxValue = MaxStamina;
            DashGage.value = CurrentStamina;
            StaminaUpdate();
        }
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKey(KeyCode.F) &&  CurrentStamina > MinStamina)
        {
            UseStamina(Decstamina * Time.deltaTime);
        }
       
    }

   
    public void UseStamina(float dec)
    {
        CurrentStamina -= dec / adjustStamina;
        CurrentStamina = Mathf.Clamp(CurrentStamina, MinStamina, MaxStamina);
        StaminaUpdate();
    }

    public void RegenerateStamina(float add)
    {
        CurrentStamina += add;
        CurrentStamina = Mathf.Clamp(CurrentStamina, MinStamina, MaxStamina);
        StaminaUpdate();
    }

    private void StaminaUpdate()
    {
        if(DashGage != null)
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
