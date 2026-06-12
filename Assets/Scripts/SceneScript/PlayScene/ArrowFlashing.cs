using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class ArrowFlashing : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    MeshRenderer mesh;
    [SerializeField] private float blinkTime = 0f;
    private MaskableGraphic UIArrow;
    private float alpha = 0.0f;
    
    Color color;
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        UIArrow = GetComponent<MaskableGraphic>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void BlinkArrow()
    {
       
        if (UIArrow == null)
        {
            Debug.Log("中身が空です");
        }
        alpha = Mathf.Sin(Time.time * blinkTime) / 2 + 0.5f;
        color = UIArrow.color;
        color.a = alpha;
        UIArrow.color = color;
        Debug.Log("正常に作動中");
    }

    public void StartBlinkArrow()
    {
       
        BlinkArrow();
    }

    public void StopBlinkArrow()
    {
        if(UIArrow == null)
        {
            Debug.LogWarning("矢印の数値が空です");
        }
        else
        {
            alpha = 1.0f;
            color.a = alpha;
            UIArrow.color = color;
          
        }
    }

   
}
