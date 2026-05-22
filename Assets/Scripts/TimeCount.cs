using UnityEngine;
using TMPro;
public class TimeCount : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    TextMeshProUGUI TimeText;
    private float ClearTime;
    public bool isTimeCount;
    public static TimeCount instace;
    void Start()
    {
        if (instace == null)
        {
            instace = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ClearTime < 0)
        {
            ClearTime += Time.deltaTime;
            TimeText.text = "ClearTime:" + ClearTime.ToString("F1");
        }

    }

    private void OnCollisionEnter(Collision collision)
    {

    }
}