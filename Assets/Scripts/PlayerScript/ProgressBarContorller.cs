using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.UI;
public class ProgressBarContorller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Slider Progress;
    private float CurrentProgress;//走るマークの進むスピード
    private float MaxProgress = 10.0f;
    private float decProgress = 1.0f;
    private float MinProgress = 0.0f;

    void Start()
    {
        CurrentProgress = MaxProgress;
        if(Progress != null)
        {
            Progress.value = CurrentProgress;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartProgressBar()
    {
        CurrentProgress -= decProgress;
        Debug.Log("バーが進んでいる");
        CurrentProgress = Mathf.Clamp(CurrentProgress, MinProgress, MaxProgress);
    }


    private void ProgressBarUpdate()
    {
        if(Progress != null)
        {
            Progress.value = CurrentProgress;
        }
    }

}
