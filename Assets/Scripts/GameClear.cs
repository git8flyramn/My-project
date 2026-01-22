using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameClear : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("ClearGame",2.0f);
    }
    public void ClearGame()
    {
        SceneManager.LoadScene("GameClear");
    }
    // Update is called once per frame
    void Update()
    {
    }

   
}
