using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class GameStartButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("StartGame", 2.0f);
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
