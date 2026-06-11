using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class ArrowFlashing : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    MeshRenderer mesh;
    private MaskableGraphic UIArrow;
    private float alpha = 0.0f;
    [SerializeField] private int ChangeBlinkTime;
    Color color;
   // private bool isBlinking = false;
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        UIArrow = GetComponent<MaskableGraphic>();
    }

    // Update is called once per frame
    private void Update()
    {
        BlinkArrow();
    }

    public void BlinkArrow()
    {
        if (UIArrow == null)
        {
            Debug.Log("中身が空です");
        }
        else
        {
            alpha = Mathf.Sin(Time.time * ChangeBlinkTime) / 2 + 0.5f;
            color = UIArrow.color;
            color.a = alpha;
            UIArrow.color = color;
        }
       
       
    }

    public void StopBlinking()
    {
        if (UIArrow == null)
        {
            Debug.Log("中身が空です");
          
        }
        else
        {
            color = UIArrow.color;
            color.a = 1.0f;
            UIArrow.color = color;
           
        }
    }

    public void StartBlinking()
    {
        if (UIArrow == null)
        {
            Debug.Log("中身が空です");

        }
        else
        {
            //BlinkArrow();
        }
    }

    //public void OnTriggerEnter(Collider other)
    //{
    //    //電車が一定の距離まで近づいて来た時に点滅を開始する
    //    if (other.CompareTag("train") && isBlinking == false)
    //    {
    //        isBlinking = true;
          
    //    }
    //    else
    //    {
    //        Debug.LogWarning("正常な動作を行う事が出来ません"); 
    //    }

    //    if(isBlinking == true)
    //    {
    //        StartBlinking();
    //    }
    //    else
    //    {
    //        StopBlinking();
    //    }
    //}
}
