using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class StaminaContoroller : MonoBehaviour
{
    public float SubStamina = 3.0f;
    public Slider slider;
    Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        slider = GameObject.Find("Slider").GetComponent<Slider>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            
        }
    }
}
