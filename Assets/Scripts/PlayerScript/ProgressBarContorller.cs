using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.UI;
public class ProgressBarContorller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    public Slider Progress;
    private float CurrentProgressPosition;
    private float MaxProgress = 10.0f;
   // private float MinProgress = 0.0f;
    private float addProgress = 0;
   // private float addProgress = 0.1f;

    void Start()
    {
        CurrentProgressPosition = MaxProgress;
        if(Progress != null)
        {
            Progress.maxValue = MaxProgress;
            Progress.value = CurrentProgressPosition;
            ProgressBarUpdate();
        }
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartProgressBar()
    {
        addProgress += 0.001f;
        if(addProgress > MaxProgress)
        {
            addProgress = 0;
        }
        Progress.value = addProgress;

        //îÕàÕì‡Ç…êßå¿Ç∑ÇÈ
        // CurrentProgressPosition = Mathf.Clamp(CurrentProgressPosition, MaxProgress, MinProgress);
        //ProgressBarUpdate();

    }


    private void ProgressBarUpdate()
    {
       if (Progress != null)
       {
           
            Progress.value = CurrentProgressPosition;
       }
    }

}
