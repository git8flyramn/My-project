using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEditor.Experimental.GraphView;
using Unity.VisualScripting;
public class StaminaContoroller : MonoBehaviour
{
    public float CuurntStamina;
    public float WarstStamina;
    public float MaxStamina;
    public Slider staminaSlider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        staminaSlider.value = CuurntStamina;
        staminaSlider.maxValue = WarstStamina;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            UseStamina();
            Debug.Log("スタミナが減っているよ");
        }
        else
        {
            Debug.Log("スタミナが戻っていくよ");
            ResenStamina();
        }

       
        
      
    }

    void UseStamina()
    {
        CuurntStamina -= 1.0f;
        if (CuurntStamina < WarstStamina)
        {
            CuurntStamina = WarstStamina;
        }
    }

    void ResenStamina()
    {
        CuurntStamina += 1.0f;
        if(CuurntStamina > MaxStamina)
        {
            CuurntStamina = MaxStamina;
        }
    }
}
