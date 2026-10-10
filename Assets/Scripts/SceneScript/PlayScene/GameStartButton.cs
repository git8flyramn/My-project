using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
public class GameStartButton : MonoBehaviour
{

    private Volume cuurentVolume;
    void Start()
    {
        cuurentVolume = Object.FindAnyObjectByType<Volume>();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Egorun", LoadSceneMode.Single);
        
    }

    public void StartMotionBlur()
    {
        if (cuurentVolume != null)
        {
            Debug.Log("モーションブラーは動作しています");
        }
      
    }
}
