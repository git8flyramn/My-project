using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ProgressBarContorller : MonoBehaviour
{

    [SerializeField] private Slider ProgressBar;
    //プログレスバーの最大値
    float MaxProgress = 10;
    float MinProgress = 0;
    //プログレスバーの現在値
    float CurrentProgress = 0;
    const float AddValue = 0.1f;
    void Start()
    {
        ProgressBar.maxValue = MaxProgress;
        ProgressBar.minValue = MinProgress;
        ProgressBar.value = CurrentProgress;

    }

    // Update is called once per frame
    public void Update()
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
