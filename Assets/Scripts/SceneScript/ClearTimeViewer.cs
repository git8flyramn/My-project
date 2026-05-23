using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class ClearTimeViewer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float ViewTime;
    public Text ClearTimeText;
    private TimeCounter time;
    void Start()
    {
        ViewTime = time.TimeGet();
        ClearTimeText.text = string.Format("ÉXÉRÉA:", ViewTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
