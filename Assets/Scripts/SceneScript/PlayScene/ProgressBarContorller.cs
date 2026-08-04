using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class ProgressBarContorller : MonoBehaviour
{

    public Slider ProgressBar;
    //プログレスバーの最大値
    float MaxProgress = 10;
    float MinProgress = 0;
    //プログレスバーの現在値
    float CurrentProgress = 0;
    const float AddValue = 0.3f;
    void Start()
    {
        ProgressBar.maxVaule = MaxProgress;
        ProgressBar.minVaule = MinProgress;
        ProgressBar.value = CurrentProgress;

    }

    // Update is called once per frame
    void Update()
    {
        if(CurrentProgress > MaxProgress)
        {
            CurrentProgress = MaxProgress;
        }
        AddProgress(AddValue);
    }

    float AddProgress(float AddValue)
    {
        ProgressBar.value += AddValue;
        return ProgressBar.value;
    }
   
}
