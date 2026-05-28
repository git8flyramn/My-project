using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class TimeCounter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private int CurrentTime = 0; //•\¦‚³‚ê‚éŠÔ
    public int ClearTime = 0;   //‰æ–Ê‘JˆÚŒã‚É“n‚·—p‚Ì•Ï”
    private int minutes = 60;
    public TextMeshProUGUI TimerText;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CurrentTime += 1;
        TransformMinites(CurrentTime);
    }

    public float TimeGet()
    {
        ClearTime = CurrentTime;
        return ClearTime;
    }

    private void TransformMinites(int time)
    {
        TimerText.text = ((int)time / minutes).ToString("00.0");
    }

}


