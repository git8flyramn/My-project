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
    private float Decstamina = 0.5f; //スタミナの減る量
    private float Addstamina = 0.5f;
  
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
       if(Input.GetKey(KeyCode.F) &&  CurrentStamina > 0)
        {
            UseStamina(Decstamina * Time.deltaTime);
        }
       else 
        {
            RegenerateStamina(Addstamina * Time.deltaTime);
        }

       if(Input.GetKey(KeyCode.F) && CurrentStamina < 0)
        {
            DontRun();
        }
    }

   
    public void UseStamina(float dec)
    {
        CurrentStamina -= dec;
        CurrentStamina = Mathf.Clamp(CurrentStamina, 0f, MaxStamina);
        StaminaUpdate();
    }

    public void RegenerateStamina(float add)
    {
        CurrentStamina += add;
        CurrentStamina = Mathf.Clamp(CurrentStamina, 0f, MaxStamina);
        StaminaUpdate();
    }

    private void StaminaUpdate()
    {
        if(DashGage != null)
        {
            DashGage.value = CurrentStamina;
        }
    }

    public void DontRun()
    {
        CurrentStamina = 0f;
    }
}
