using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class GameStartButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private float StartTime = 2.0f;
    void Start()
    {
        Invoke("StartGame", StartTime);
    }
     public void StartGame()
    {
        SceneManager.LoadScene("Egorun");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
