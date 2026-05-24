using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class TimeCounter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private int CurrentTime = 0;
    public  int ClearTime = 0;
    private int addTime = 1;
    private int minute = 60;
    public TextMeshProUGUI TimerText;
    void Start()
    {
        TimerText.text = CurrentTime.ToString("00");
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTime += addTime;
        if (CurrentTime > minute)
        {
            CurrentTime = CurrentTime / minute;
            CurrentTime += addTime;
            TimerText.text = CurrentTime.ToString("00");
        }
    }

    public float TimeGet()
    {
        ClearTime = CurrentTime;
        return ClearTime;
    }
}

