using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class GameStartButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

 
    void Start()
    {
     
    }
     public void StartGame()
    {
        SceneManager.LoadScene("Egorun", LoadSceneMode.Single);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
