using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class ArrowFlashing : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    MeshRenderer mesh;
   // private float BlinkTime = 0.2f;
    private MaskableGraphic UIArrow;
    private float alpha = 0.0f;
    Color color;
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

    private void BlinkArrow()
    {
        if (UIArrow == null)
        {
            Debug.Log("中身が空です");
        }
        alpha = Mathf.Sin(Time.time * 10) / 2 + 0.5f;
        color = UIArrow.color;
        color.a = alpha;
        UIArrow.color = color;
    }
}
