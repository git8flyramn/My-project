using UnityEngine;
using TMPro;
public class ClearTimeManeget : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public TextMeshProUGUI scoreText;
    private float ClearTime;
    private float CurrntTime;
    void Start()
    {
        CurrntTime = 0;
        ClearTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CurrntTime += 0.1f;
    }

    public float GetClearTime()
    {
        ClearTime = CurrntTime;
        return ClearTime;
    }

}
