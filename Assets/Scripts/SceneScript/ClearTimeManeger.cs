using UnityEngine;
using TMPro;
public class ClearTimeManeget : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public TextMeshProUGUI scoreText;
    private float ClearTime;
    void Start()
    { 
        ClearTime = 0;
    }

    // Update is called once per frame
    void Update()
    { 
    }

    public float GetClearTime(float currentTime)
    {
        ClearTime = currentTime;
         Debug.Log($"{ClearTime}");

        return ClearTime;
      
    }

}
