using UnityEngine;
using UnityEngine.SceneManagement;
public class TimeCounter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private float CurrentTime = 0.0f;
    public float ClearTime = 0.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTime += Time.deltaTime;
    }

    public void ClearTimeGet()
    {
        ClearTime = CurrentTime;
        return ClearTime;
    }
}

