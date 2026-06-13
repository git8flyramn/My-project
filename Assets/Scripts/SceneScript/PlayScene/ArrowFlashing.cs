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
       color = UIArrow.color;
       color.a = 1.0f;
       UIArrow.color = color;
      // isBlinking = false;
    }

    public void StartBlinking()
    {
        //isBlinking = true;
        BlinkArrow();
    }
}
