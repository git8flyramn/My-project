using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class ArrowFlashing : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   //SerializeField
    [SerializeField] private Image Arrow;
    private float alpha = 0.0f; //•Ï‰»‚³‚¹‚é’l
    private Color color; //F‚ğæ“¾‚·‚é•Ï”

    void Start()
    {
        StartBlinking();
    }

    // Update is called once per frame
    private void Update()
    {
        alpha = Mathf.Sin(Time.time) / 2 + 0.5f;
    }

    private void BlinkArrow()
    {
        StartCoroutine(ColorAppar());
    }

    public void StopBlinking()
    {
    }

    public void StartBlinking()
    {
        //isBlinking = true;
        Debug.Log("–îˆó‚Ì“_–Å’†");
        BlinkArrow();
    }
    IEnumerator ColorAppar()
    {
        yield return new WaitForEndOfFrame();

        color = Arrow.material.color;
        color.a = alpha;
        Arrow.material.color = color;

    }

}
